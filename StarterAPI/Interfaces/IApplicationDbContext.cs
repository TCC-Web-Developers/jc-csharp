using Microsoft.EntityFrameworkCore;
using StarterAPI.Entities;


namespace StarterAPI.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; }
    }
}
