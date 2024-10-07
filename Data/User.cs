namespace VolvoApp.Data {
    public class User {
        public User(int id, string login, string password, string department) {
            Id = id;
            Login = login;
            Password = password;
            Department = department;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
    }
}
