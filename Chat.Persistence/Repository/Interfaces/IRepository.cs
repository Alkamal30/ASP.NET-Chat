
namespace Chat.Persistence.Repository.Interfaces;

public interface IRepository<T> where T : class {
	
	IEnumerable<T> GetAll();
	T? GetFirstOrDefault(Func<T, bool> predicate);

	void Add(T entity);
	void Update(T entity);
	void Remove(T entity);
}
