namespace api.models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TagLine { get; set; }
        public string Type => typeof(User).Name;
    }
}