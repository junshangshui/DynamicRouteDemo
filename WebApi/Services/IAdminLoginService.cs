using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IAdminLoginService
    {
        User FindByUsername(string username);

        bool ValidateAdminUser(User user, string loginPassword);
    }
}
