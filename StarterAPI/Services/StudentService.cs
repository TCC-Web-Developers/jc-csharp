using StarterAPI.Entities;
using StarterAPI.Interfaces;

namespace StarterAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext _context;

        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(new object[] { id });

            return student;
        }

        public async Task<Student> CreateStudent(Student student, CancellationToken ct)
        {
            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                EmailAddress = student.EmailAddress,
                BirthDate = student.BirthDate,
                DateEnrolled = student.DateEnrolled,
            };

            _context.Students.Add(newStudent);

            await _context.SaveChangesAsync(ct);

            string generatedStudentNo
                = Convert.ToDateTime(student.DateEnrolled).ToString("yyyddMM") + "-" + newStudent.StudentId;

            newStudent.StudentNo = generatedStudentNo;

            await _context.SaveChangesAsync(ct);

            return newStudent;
        }

        public async Task UpdateStudent(Student student, CancellationToken ct)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync(ct);
        }

        public async Task DeleteStudent(int id, CancellationToken ct)
        {
            var student = await _context.Students.FindAsync(new object[] { id }, ct);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync(ct);
        }
    }
}
