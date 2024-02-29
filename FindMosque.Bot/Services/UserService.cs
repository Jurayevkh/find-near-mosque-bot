using FindMosque.Bot.Entity;

namespace FindMosque.Bot.Services;

public class UserService
{
    public async Task<User> GetUserAsync(long accoundId)
    {
        return new User() { LanguageCode="uz-Uz"};
    }
}

