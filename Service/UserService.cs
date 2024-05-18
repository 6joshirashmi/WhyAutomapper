using Domain;
using Infrastructure.GenericRepositoryPattern.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> userRepository;
        private IGenericRepository<UserProfile> userProfileRepository;

        public UserService(IGenericRepository<User> _userRepository, IGenericRepository<UserProfile> _userProfileRepository)
        {
            this.userRepository = _userRepository;
            this.userProfileRepository = _userProfileRepository;
        }
        void IUserService.DeleteUser(int id)
        {
            UserProfile userProfile = userProfileRepository.GetById(id);
            userProfileRepository.Delete(userProfile);
            User user = userRepository.GetById(id);
            userRepository.Delete(user);
        }

        User IUserService.GetUser(int id)
        {
            return userRepository.GetById(id);
        }

        IEnumerable<User> IUserService.GetUsers()
        {
            return userRepository.GetAll();
        }

        void IUserService.InsertUser(User user)
        {
            userRepository.Add(user);
        }

        void IUserService.UpdateUser(User user)
        {
             userRepository.Update(user);
        }
    }
}
