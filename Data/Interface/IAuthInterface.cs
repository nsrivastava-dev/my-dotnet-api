using static SecureApi.Models.AuthModel;

namespace SecureApi.Data.Interface
{
    public interface IAuthInterface
    {
        Task<StudentResponse> StudentList();
    }
}
