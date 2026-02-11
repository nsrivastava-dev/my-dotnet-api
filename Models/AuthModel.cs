namespace SecureApi.Models
{
    public class AuthModel
    {
        public class BasicStudentResponse
        {
            public string? Message { get; set; }
            public int? Code { get; set; }
            public bool? Success { get; set; }
            public int? StudentID { get; set; }
            public string? Name { get; set; }
            public string? Mobile { get; set; }
            public string? Email { get; set; }
        }

        public class StudentResponseData
        {
          
            public int? StudentID { get; set; }
            public string? Name { get; set; }
            public string? Mobile { get; set; }
            public string? Email { get; set; }
        }

        public class StudentResponse
        {
            public string? Message { get; set; }
            public int? Code { get; set; }
            public bool? Success { get; set; }
            public List<StudentResponseData>? Data { get; set; }
        }
    }
}
