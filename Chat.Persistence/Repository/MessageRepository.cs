using Chat.Application.Interfaces.Repository;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repository;

public class MessageRepository : Repository<Message>, IMessageRepository
{

    public MessageRepository(DbContext dbContext) : base(dbContext) { }
}
