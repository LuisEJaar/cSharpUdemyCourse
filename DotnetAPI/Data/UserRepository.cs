using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public class UserRepository : IUserRepository
    {
        DataContextEF _entityFramework; 

        public UserRepository(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);
        }

        public bool SaveChanges() 
        {
            return _entityFramework.SaveChanges() > 0;
        }

        public void AddEntity<T>(T EntityToAdd)
        {
            if(EntityToAdd != null)
            {
                _entityFramework.Add(EntityToAdd);
            } 
        }

        public void RemoveEntity<T>(T EntityToRemove)
        {
            if(EntityToRemove != null)
            {
                _entityFramework.Remove(EntityToRemove);
            } 
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _entityFramework.Users.ToList<User>();
            return users;
        } 

        public User GetSingleUser(int userId)
        {
            User? user = _entityFramework.Users
                .Where(u => u.UserId == userId)
                .FirstOrDefault<User>();
            
            if(user != null)
            {
                return user;
            }
            throw new Exception("Failed to get user!");
        } 

        public UserJobInfo GetSingleUserJob(int userId)
        {
            UserJobInfo? userJob = _entityFramework.UserJobInfo
                .Where(u => u.UserId == userId)
                .FirstOrDefault<UserJobInfo>();
            
            if(userJob != null)
            {
                return userJob;
            }
            throw new Exception("Failed to get user job!");
        }

        public UserSalary GetSingleUserSalary(int userId)
        {
            UserSalary? userSalary = _entityFramework.UserSalary
                .Where(u => u.UserId == userId)
                .FirstOrDefault<UserSalary>();
            
            if(userSalary != null)
            {
                return userSalary;
            }
            throw new Exception("Failed to get user job!");
        }
    }
}