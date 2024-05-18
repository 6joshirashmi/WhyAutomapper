using Domain;
using Infrastructure.GenericRepositoryPattern.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProfileService : IProfileService
    {
        private IGenericRepository<UserProfile> userProfileRepository;

        public ProfileService(IGenericRepository<UserProfile> userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }
         
        UserProfile IProfileService.GetUserProfile(int id)
        {
           return userProfileRepository.GetById(id);
        }
    }
}
