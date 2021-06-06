using System.Collections.Generic;

namespace FrameworkCore.DataFiles
{
    public class User
    {

        public static readonly User USER1 = new User("PimsAutomationTester", "kh3n1og0NuZw");
        public static readonly User USER2 = new User("PimsAutomationTester", "kh3n1og0NuZw");
        public static readonly User NoUserName = new User("", "kh3n1og0NuZw");
        public static readonly User NoPassword = new User("PimsAutomationTester", "");
        public static readonly User inValidUserName = new User("PimsAutomationTesterr", "kh3n1og0NuZw");
        public static readonly User inValidPassword = new User("PimsAutomationTester", "kh3n1og0NuZ");


        public string UserName { get; private set; }
        public string Password { get; private set; }
        private User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string GetUserName() { return UserName; }
        public string GetPassword() { return Password; }
    }
}
