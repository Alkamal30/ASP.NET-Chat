using Chat.Application.Interfaces.Repository;
using Chat.Domain.Entities;
using Chat.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.Repository;

public class UnitOfWorks : IUnitOfWorks
{

    public UnitOfWorks(ChatDbContext dbContext)
    {
        _dbContext = dbContext;

        UserRepository = new UserRepository(dbContext);
        MessageRepository = new MessageRepository(dbContext);
    }


    public IUserRepository UserRepository { get; }
    public IMessageRepository MessageRepository { get; }

    private DbContext _dbContext;


    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
