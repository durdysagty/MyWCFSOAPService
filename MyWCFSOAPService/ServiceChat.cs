using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace MyWCFSOAPService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        private readonly IList<User> _users;
        int id = 1;

        public ServiceChat() { 
            _users = new List<User>();
        }

        public int Connect(string name)
        {
            User user = new User()
            {
                Id = id++,
                Name = name,
                OperationContext = OperationContext.Current
            };
            _users.Add(user);
            SendMsg($"{user.Name} is connected", 0);
            ShowUsers();
            return user.Id;
        }

        public void Disconnect(int id)
        {
            User user = GetUser(id);
            if (user != null)
            {
                _users.Remove(user);
                SendMsg($"{user.Name} - is disconnected", 0);
            }
            ShowUsers();
        }

        void ShowUsers()
        {
            Console.WriteLine($"Users count - {_users.Count}");
            Console.WriteLine(string.Join("\n", _users.Select(u => u.ToString())));
        }

        User GetUser(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public void SendMsg(string msg, int id)
        {
            string date = DateTime.Now.ToShortTimeString();
            string senderName = id == 0 ? null: GetUser(id).Name;
            foreach (User user in _users)
            {
                string answer = $"{date}: {senderName} - {msg}";
                user.OperationContext.GetCallbackChannel<IServiceChatCallBack>().MsgCallBack(answer);
            }
        }
    }
}
