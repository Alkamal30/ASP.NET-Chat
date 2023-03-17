using Chat.Persistence.Repository.Interfaces;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repository.Implementation;

public class MessageRepository : Repository<Message>, IMessageRepository {

	public MessageRepository(DbContext dbContext) : base(dbContext) { }
}
