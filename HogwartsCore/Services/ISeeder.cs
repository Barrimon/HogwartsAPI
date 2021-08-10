using System.Threading.Tasks;

namespace HogwartsCore.Services
{
    public interface ISeeder
    {
        Task SeedPopulate();
    }
}