using Microsoft.Data.SqlClient;
using SecureApi.Data.Interface;
using Dapper;
using static SecureApi.Models.AuthModel;
using System.Data;

namespace SecureApi.Data.Repository
{
    public class AuthRepository : IAuthInterface
    {
        private readonly string _configuration;
        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("SecureApi");
        }

        public async Task<StudentResponse> StudentList()
        {
            var response = new StudentResponse();
            response.Data = new List<StudentResponseData>();
            bool RunOnce = true;
            #region Parameters

            #endregion

            try
                {
                    using(IDbConnection connection = new SqlConnection(_configuration))
                    {
                    var responseAllData = await connection.QueryAsync<BasicStudentResponse>("API_ListOfStudent", null, null, null, CommandType.StoredProcedure);
                        if (responseAllData != null)
                        {
                            foreach(var item in responseAllData)
                            {
                                if (RunOnce)
                                {
                                    response.Message = item.Message;    
                                    response.Code = item.Code;    
                                    response.Success = item.Success;    
                                }
                                StudentResponseData data = new StudentResponseData();
                                data.StudentID = item.StudentID;
                                data.Name = item.Name;
                                data.Email = item.Email;
                                data.Mobile = item.Mobile;  
                                response.Data.Add(data);
                            }
                        }
                    }
                    return response;
                }
                catch(Exception ex) 
                {
                response.Success = false;
                response.Message=ex.Message;
                response.Code = 999;
                return response;
                }
           

        }
    }
}
