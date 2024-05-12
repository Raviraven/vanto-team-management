namespace Vanto.Application;

public sealed class RandomUserResponse
{
    public RandomUser[] Results { get; set; } = Array.Empty<RandomUser>();
    
    public class RandomUser
    {
        public NameProp Name { get; set; } = null!;
        public RegisteredProp Registered { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        
        
        public class NameProp
        {
            public string First { get; set; } = null!;
            public string Last { get; set; } = null!;
        }
        
        public class RegisteredProp
        {
            public DateTime Date { get; set; }
        }
    }
}