
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
