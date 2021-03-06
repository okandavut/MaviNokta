using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Otiport.API.Data;
using Otiport.API.Data.Entities.Users;

namespace Otiport.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly OtiportDbContext _dbContext;
        private readonly ILogger<IUserRepository> _logger;

        public UserRepository(OtiportDbContext dbContext, ILogger<IUserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync(true);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong");
                return false;
            }
        }

        public Task<bool> IsExistsUserAsync(string username, string emailAddress)
        {
            return _dbContext.Users.AnyAsync(x => x.Username == username || x.EmailAddress == emailAddress);
        }

        public async Task<UserEntity> AddAsync(UserEntity entity)
        {
            entity.City = _dbContext.Cities.Find(entity.City.Id);
            entity.Country = _dbContext.Countries.Find(entity.Country.Id);
            entity.District = _dbContext.Districts.Find(entity.District.Id);
            entity.UserGroup = _dbContext.UserGroups.Find(entity.UserGroup.Id);
            await _dbContext.Users.AddAsync(entity);
            bool isSuccess = await SaveAsync();


            return isSuccess ? entity : null;
        }

        public Task<UserEntity> GetUserByCredentialsAsync(string emailAddress, string password)
        {
            return _dbContext.Users.SingleOrDefaultAsync(x => x.EmailAddress == emailAddress && x.Password == password);
        }
    }
}