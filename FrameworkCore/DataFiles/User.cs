using System.Collections.Generic;

namespace FrameworkCore.DataFiles
{
    public class User
    {

        public static readonly User USER1 = new User("iince", "Almanya2016");
        public static readonly User USER2 = new User("oturkakin", "ho17%#AK");
        public static readonly User NoUserName = new User("", "ho17%#AK");
        public static readonly User NoPassword = new User("oturkakin", "");
        public static readonly User UnValidUserName = new User("oturkakinn", "ho17%#AK");
        public static readonly User UnValidPassword = new User("oturkakin", "ho17%#A");

        //public static readonly User GAP_USER = new User("gap.autouser@alliedsolutions.net", "welcome1");
        //public static IEnumerable<User> Values
        //{
        //    get
        //    {
        //        yield return EXTERNAL_ADMIN_USER1;
        //        yield return EXTERNAL_ADMIN_USER2;
        //        //yield return GAP_USER;
        //    }
        //}
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
