
namespace Chat.Domain.Entities;

public class User {
	
	public int Id { get; set; }
	public String? Login { get; set; }
	public String? Password { get; set; }
	public List<Message> Messages { get; set; } = new();
}
