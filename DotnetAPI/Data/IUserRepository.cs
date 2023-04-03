using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public interface IUserRepository
    {
        public bool SaveChanges();

        public void AddEntity<T>(T EntityToAdd);

        public void RemoveEntity<T>(T EntityToRemove);

        public IEnumerable<User> GetUsers();

        public User GetSingleUser(int userId);

        public UserJobInfo GetSingleUserJob(int userId);

        public UserSalary GetSingleUserSalary(int userId);
    }
}