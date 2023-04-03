using Microsoft.AspNetCore.Mvc;
using DotnetAPI.Data;
using DotnetAPI.Models;
using DotnetAPI.Dtos;
using AutoMapper;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    IUserRepository _userRepository;

    IMapper _mapper;

    public UserEFController(IConfiguration config, IUserRepository userRepository)
    {
        //By running a request, we create this controller and this constructor runs which runs the console write below
       Console.WriteLine(config.GetConnectionString("DefaultConnection"));
   
       _mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<UserToAddTo, User>(); 
       }));

       _userRepository = userRepository;
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        return _userRepository.GetUsers();
    } 

    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        return _userRepository.GetSingleUser(userId);
    } 

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        User? userDb = _userRepository.GetSingleUser(user.UserId);
        
        if(userDb != null)
        {
            userDb.Active = user.Active;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;
            userDb.Gender = user.Gender;

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to update user!");
        }
        throw new Exception("Failed to get user!");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserToAddTo user)
    {
        User userDb = _mapper.Map<User>(user);

        _userRepository.AddEntity<User>(userDb);
        if(_userRepository.SaveChanges())
        {
            return Ok();
        }

        throw new Exception("Failed to add user!");
    }


    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        User? userDb = _userRepository.GetSingleUser(userId);;
        
        if(userDb != null)
        {
            _userRepository.RemoveEntity<User>(userDb);

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to delete user!");
        }
        throw new Exception("Failed to get user!");
    }

    [HttpGet("GetSingleUserJob/{userId}")]
    public UserJobInfo GetSingleUserJob(int userId)
    {
        return _userRepository.GetSingleUserJob(userId);
    }

    [HttpPut("EditUserJob")]
    public IActionResult EditUserJob(UserJobInfo userJob)
    {
        UserJobInfo? userJobDb = _userRepository.GetSingleUserJob(userJob.UserId);
        
        if(userJobDb != null)
        {
            userJobDb.JobTitle = userJob.JobTitle;
            userJobDb.Department = userJob.Department;

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to update userJob!");
        }
        throw new Exception("Failed to get userJob!");
    }

    [HttpPost("AddUserJob")]
    public IActionResult AddUserJob(UserJobInfo userJobInfo)
    {
        UserJobInfo userJobInfoDb = new UserJobInfo();

        userJobInfoDb.UserId = userJobInfo.UserId;
        userJobInfoDb.JobTitle = userJobInfo.JobTitle;
        userJobInfoDb.Department = userJobInfo.Department;

        _userRepository.AddEntity<UserJobInfo>(userJobInfoDb);
        if(_userRepository.SaveChanges())
        {
            return Ok();
        }

        throw new Exception("Failed to add userJob!");
    }

    [HttpDelete("DeleteUserJob/{userId}")]
    public IActionResult DeleteUserJob(int userId)
    {
        UserJobInfo? userJobInfoDb = _userRepository.GetSingleUserJob(userId);
        
        if(userJobInfoDb != null)
        {
            _userRepository.RemoveEntity<UserJobInfo>(userJobInfoDb);

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to delete userJob!");
        }
        throw new Exception("Failed to get userJob!");
    }

    [HttpGet("GetSingleUserSalary/{userId}")]
    public UserSalary GetSingleUserSalary(int userId)
    {
        return _userRepository.GetSingleUserSalary(userId);
    }

    [HttpPut("EditUserSalary")]
    public IActionResult EditUserSalary(UserSalary userSalary)
    {
        UserSalary? userSalaryDb = _userRepository.GetSingleUserSalary(userSalary.UserId);
        
        if(userSalaryDb != null)
        {
            userSalaryDb.Salary = userSalary.Salary;

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to update salary!");
        }
        throw new Exception("Failed to get user Salary!");
    }

    [HttpPost("AddUserSalary")]
    public IActionResult AddUserSalary(UserSalary userSalary)
    {
        UserSalary userSalaryDb = new UserSalary();

        userSalaryDb.UserId = userSalary.UserId;
        userSalaryDb.Salary = userSalary.Salary;

        _userRepository.AddEntity<UserSalary>(userSalaryDb);
        if(_userRepository.SaveChanges())
        {
            return Ok();
        }

        throw new Exception("Failed to add user salary!");
    }
    
    [HttpDelete("DeleteUserSalary/{userId}")]
    public IActionResult DeleteUserSalary(int userId)
    {
        UserSalary? userSalaryDb = _userRepository.GetSingleUserSalary(userId);
        
        if(userSalaryDb != null)
        {
            _userRepository.RemoveEntity<UserSalary>(userSalaryDb);

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to delete user Salary!");
        }
        throw new Exception("Failed to get user Salary!");
    }

}  
