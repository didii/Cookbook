namespace Cookbook.Infrastructure {
    public interface IHashGenerator {
        byte[] GetSalt();
        byte[] Generate(string password, out byte[] salt);
        byte[] Generate(string password, byte[] salt);
    }
}
