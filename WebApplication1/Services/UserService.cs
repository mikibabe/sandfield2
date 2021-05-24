using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        public static User GetUserById(int id)
        { 
            User user;
            using (var conn = Helpers.DBConnection.GetDBConnection())
            {
                user = conn.Query<User>("usp_GetUserById", new { @Id = id },  
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return user;
        }

        public static List<User> GetUserList()
        {
            List<User> lst;
            using (var conn = Helpers.DBConnection.GetDBConnection())
            {
                lst = conn.Query<User>("usp_GetAllUser", commandType: CommandType.StoredProcedure).ToList();
            }
            return lst;
        }

        public static string GetUserAccessLevelById(int id)
        {
            string userAccessLevel;
            using (var conn = Helpers.DBConnection.GetDBConnection())
            {
                var p = new DynamicParameters();
                p.Add("@Id", id);
                p.Add("@UserAccessLevel", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);

                var user = conn.Query<int>("usp_GetUserAccessLevel", p,
                    commandType: CommandType.StoredProcedure);


                userAccessLevel = p.Get<string>("@UserAccessLevel"); 
            }
            return userAccessLevel;
        }

        public static bool EditUser(Models.User dto)
        { 
            using (var conn = Helpers.DBConnection.GetDBConnection())
            {
                var p = new DynamicParameters();
                p.Add("@Id", dto.Id);
                p.Add("@UserId", dto.UserId);
                p.Add("@Password", dto.Password);
                p.Add("@Group", dto.Group);
                p.Add("@Role", dto.Role);

                int result = conn.Execute("usp_EditUser", p, commandType: CommandType.StoredProcedure); 
                return (result > 0);
            } 
        }

    }
}