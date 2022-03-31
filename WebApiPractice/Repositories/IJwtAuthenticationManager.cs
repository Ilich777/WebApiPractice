namespace WebApiPractice.Repositories
{
    public interface IJwtAuthenticationManager
    {        
        string Authenticate(string username, string password);

    }
}
