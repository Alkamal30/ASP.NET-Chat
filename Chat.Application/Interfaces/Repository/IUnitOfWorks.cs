
namespace Chat.Application.Interfaces.Repository;

public interface IUnitOfWorks {
	
	public IUserRepository UserRepository { get; }
	public IMessageRepository MessageRepository { get; }


	void Save();
}

