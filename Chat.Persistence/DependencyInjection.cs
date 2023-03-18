using Chat.Application.Interfaces.Repository;
using Chat.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Persistence;

public static class DependencyInjection {

	public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration) {
		
		serviceCollection.AddDbContext<ChatDbContext>(
			options => options.UseNpgsql(
				configuration.GetConnectionString("Default")
			)
		);

		serviceCollection.AddScoped<IUnitOfWorks, UnitOfWorks>();

		return serviceCollection;
	}
}
