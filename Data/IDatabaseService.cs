namespace VolvoApp.Data {
    public interface IDatabaseService {
        User? Login(string login, string password) => null;
    }
}
