namespace VolvoApp.Data {
    public class InMemoryDatabaseService : IDatabaseService {

        private readonly IEnumerable<User> _users = new List<User>() {
            new User(1,  "gendir_ceo", "Gendirceo1000", "CEO"),
            new User(2,  "secr3tary", "Secr3tary1001", "Secretary"),
            new User(3,  "ohorsec_ker", "Ohorsec2000", "HEAD of the Security Dept."),
            new User(4,  "ohorsec1", "Ohorsec2001", "Security Dept."),
            new User(5,  "ohorsec2", "Ohorsec2002", "Security Dept."),
            new User(6,  "ohorsec3", "Ohorsec2003", "Security Dept."),
            new User(7,  "kiberbepzsec1", "Ohorsec2004", "Security Dept."),
            new User(8,  "kiberbepzsec2", "Ohorsec2005", "Security Dept."),
            new User(9,  "kiberbepzsec2", "Ohorsec2006", "Security Dept."),
            new User(10, "kadryhr_ker", "Kadryhr3000", "HEAD of the HR Dept."),
            new User(11, "kadryhr1", "Kadryhr3001", "HR Dept."),
            new User(12, "kadryhr2", "Kadryhr3002", "HR Dept."),
            new User(13, "kadryhr3", "Kadryhr3003", "HR Dept."),
            new User(14, "econ3con_ker", "Econ3con4000", "HEAD of the Economics Dept."),
            new User(15, "econ3con1", "Econ3con4001", "Economics Dept."),
            new User(16, "econ3con2", "Econ3con4002", "Economics Dept."),
            new User(17, "econ3con3", "Econ3con4003", "Economics Dept."),
            new User(18, "econ3con4", "Econ3con4004", "Economics Dept."),
            new User(19, "econ3con5", "Econ3con4005", "Economics Dept."),
            new User(20, "prodservice_ker", "ServiceProd5000", "HEAD of the Car Maintenance Dept."),
            new User(21, "prodservice1", "ServiceProd5001", "Car Maintenance Dept."),
            new User(22, "prodservice2", "ServiceProd5002", "Car Maintenance Dept."),
            new User(23, "prodservice3", "ServiceProd5003", "Car Maintenance Dept."),
            new User(24, "prodservice4", "ServiceProd5004", "Car Maintenance Dept."),
            new User(25, "pryjcar_ker", "Pryjcar6000", "HEAD of the Car Reception Dept."),
            new User(26, "pryjcar1", "Pryjcar6001", "Car Reception Dept."),
            new User(27, "pryjcar2", "Pryjcar6002", "Car Reception Dept."),
            new User(28, "pryjcar3", "Pryjcar6003", "Car Reception Dept."),
            new User(29, "prodsales_ker", "Prodsales7000", "HEAD of the Sales Dept."),
            new User(30, "prodsales1", "Prodsales7001", "Sales Dept."),
            new User(31, "prodsales2", "Prodsales7002", "Sales Dept."),
            new User(32, "prodsales3", "Prodsales7003", "Sales Dept."),
            new User(33, "prodsales4", "Prodsales7004", "Sales Dept."),
            new User(34, "prodsales5", "Prodsales7005", "Sales Dept."),
            new User(35, "prodsales6", "Prodsales7006", "Sales Dept."),
        };

        public User? Login(string login, string password) {
            User? user = _users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null) {
                return null;
            }
            return user;
        }
    }
}
