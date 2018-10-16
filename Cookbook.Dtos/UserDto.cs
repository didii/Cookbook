namespace Cookbook.Dtos {
    public class UserDto : IDtoBase {
        public string UserName { get; set; }
        public string Email { get; set; }
        //public string Role { get; set; }
    }

    public class UserCreate : IDtoBase {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }
    }

    public class UserAuthorize : IDtoBase {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}