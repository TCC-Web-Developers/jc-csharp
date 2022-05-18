using StarterAPI.Entities;

namespace StarterAPI.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> CreateStudent(Student student, CancellationToken ct);
        Task<Student> UpdateStudent(Student student, CancellationToken ct);
        Task<bool> DeleteStudent(int id, CancellationToken ct); 
    }
}
