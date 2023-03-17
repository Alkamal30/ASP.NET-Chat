
namespace Chat.Domain.Entities;

public class Message {
	
	public int Id { get; set; }
	public String? Content { get; set; }
	public DateTime Time { get; set; }

	public int UserId { get; set; }
	public User? User { get; set; }
}
