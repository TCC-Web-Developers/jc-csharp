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

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            return student;
        }

        public async Task<Student> CreateStudent(Student request, CancellationToken ct)
        {
            var newStudent = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                BirthDate = request.BirthDate,
                DateEnrolled = request.DateEnrolled,
                Address = request.Address,
                Course = request.Course,
                ContactNo = request.ContactNo,
                Profile = request.Profile,
            };

            _context.Students.Add(newStudent);

            await _context.SaveChangesAsync(ct);

            string generatedStudentNo
                = Convert.ToDateTime(request.DateEnrolled).ToString("yyyddMM") + "-" + newStudent.StudentId;

            newStudent.StudentNo = generatedStudentNo;

            await _context.SaveChangesAsync(ct);

            return newStudent;
        }

        public async Task<Student> UpdateStudent(Student request, CancellationToken ct)
        {
            var student = await _context.Students.FindAsync(new object[] { request.StudentId });

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Address = request.Address;
            student.EmailAddress = request.EmailAddress;
            student.BirthDate = request.BirthDate;
            student.Course = request.Course;
            student.ContactNo = request.ContactNo;
            student.Profile = request.Profile;

            await _context.SaveChangesAsync(ct);

            return student;
        }

        public async Task<bool> DeleteStudent(int id, CancellationToken ct)
        {
            var student = await _context.Students.FindAsync(new object[] { id });

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            _context.Students.Remove(student);

            await _context.SaveChangesAsync(ct);

            return true;
        }
    }
}
