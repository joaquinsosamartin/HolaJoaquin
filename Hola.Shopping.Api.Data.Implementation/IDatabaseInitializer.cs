using System.Threading.Tasks;

namespace Hola.Shopping.Api.Data.Implementation
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}