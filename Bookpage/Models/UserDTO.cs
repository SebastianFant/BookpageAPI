namespace Bookpage.Models
{
    public class UserDTO
    {
        public UserDTO()
        {
        }

        public UserDTO(int id, string name, string token)
        {
            Id = id;
            Name = name;
            Token = token;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        

        public string? Token { get; set; }
    }
}
