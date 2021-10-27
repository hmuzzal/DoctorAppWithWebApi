using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DhakaChoiceDoctorApp.ViewModels;
using Refit;

namespace DhakaChoiceDoctorApp.APIs
{
    interface API
    {
        [Post("api/register")]
        Task<string> RegisterUser([Body] RegisterViewModel user); 
        
        [Post("api/login")]
        Task<string> LoginUser([Body] RegisterViewModel user);
    }
}
