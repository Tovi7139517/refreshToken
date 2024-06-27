namespace Common
{
    public class Users
    {
        public int Code { get; set; }
        public string Name { get; set; }  
        public string Email { get; set; }
        public int CoursesNum { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime LastView { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public DateTime registrationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        //public UserDetails() { }
    }
}