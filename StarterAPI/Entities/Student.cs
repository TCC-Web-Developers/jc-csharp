namespace StarterAPI.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentNo { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime? DateEnrolled { get; set; }
        public DateTime Birthdate { get; set; }
        public string Course { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;
    }


}
