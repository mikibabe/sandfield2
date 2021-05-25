
# Package Installation

Install-Package Dapper -Version 2.0.90
Install-Package Microsoft.AspNet.WebApi.Cors -Version 5.2.7
 
# Configuration

App_Start > WebApiConfig.cs  > Register >  config.EnableCors(); 


Global.asax.cs > application_start > 

 AreaRegistration.RegisterAllAreas();
 [+] GlobalConfiguration.Configure(WebApiConfig.Register);
 FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
 RouteConfig.RegisterRoutes(RouteTable.Routes);
 BundleConfig.RegisterBundles(BundleTable.Bundles);
 
<connectionStrings>
  <add name="sandfieldcs" connectionString="Data Source=DESKTOP-AM4N82T\SQLEXPRESS;Initial Catalog=orangeapp2;user id=admin;Password=admin123" providerName="System.Data.SqlClient" />
</connectionStrings>
  
 
 
# Controller 

EnableCors(origins: "*", headers: "*", methods: "*")]
  
[System.Web.Http.Route("User/GetUserById/{id}")]
public string GetUserById(int id)
{
	var d = UserService.GetUserById(id);
	return JsonConvert.SerializeObject(d);
}



# Sample Indexing
 
CREATE NONCLUSTERED INDEX IX_test1
 ON dbo.shipmentsku ( orderweight) 
 include (shipmentdropid)
 where  orderweight is not null
 WITH ( DROP_EXISTING = ON );
 
 
  
# Code template

public static SqlConnection GetDBConnection()
{
	return new SqlConnection(ConfigurationManager.ConnectionStrings["sandfieldcs"].ConnectionString);
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

