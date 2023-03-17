using Microsoft.EntityFrameworkCore;
using Chat.Domain.Entities;

namespace Chat.Persistence;

public class ChatDbContext : DbContext {

	public ChatDbContext(DbContextOptions<ChatDbContext> options) 
		: base(options) { }


	public DbSet<User> Users { get; set; }
	public DbSet<Message> Messages { get; set; }
}
