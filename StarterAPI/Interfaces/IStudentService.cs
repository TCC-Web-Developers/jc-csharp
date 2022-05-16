using StarterAPI.Entities;

namespace StarterAPI.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> CreateStudent(Student student, CancellationToken ct);
        Task UpdateStudent(Student student, CancellationToken ct);
        Task DeleteStudent(int id, CancellationToken ct); 
    }
}
