using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper; 

    public UserController(IConfiguration config)
    {
        //By running a request, we create this controller and this constructor runs which runs the console write below
       Console.WriteLine(config.GetConnectionString("DefaultConnection"));

       _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    // [HttpGet("ExecuteSql")]
    // public bool ExecuteSql()
    // {
    //     return _dapper.ExecuteSql("SELECT *");
    // }

    // [HttpGet("ExecuteWithRowCount")]
    // public int ExecuteWithRowCount()
    // {
    //     return _dapper.ExecuteWithRowCount("SELECT *");
    // }

    [HttpGet("GetUsers/{testValue}")]
    public IEnumerable<User> GetUsers(string testValue)
    {
        string sql = @"
            SELECT  [UserId],
                    [FirstName],
                    [LastName],
                    [Email],
                    [Gender],
                    [Active] 
            FROM TutorialAppSchema.Users";

            IEnumerable<User> users = _dapper.LoadData<User>(sql);
            return users;
    } 

    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        string sql = @"
            SELECT  [UserId],
                    [FirstName],
                    [LastName],
                    [Email],
                    [Gender],
                    [Active] 
            FROM TutorialAppSchema.Users
            WHERE UserId = " + userId.ToString();

        User user = _dapper.LoadDataSingle<User>(sql);
        return user;
    } 

}  
