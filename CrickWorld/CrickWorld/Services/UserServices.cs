using CrickWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.RestClient;

namespace CrickWorld
{
 public   class UserServices
    {

        async public Task<List<UserDetails>> GetUsersAsync()
        {
            RestClient<UserDetails> restClient=new RestClient<UserDetails>();
            var lstUser = await restClient.GetAsync();
            return lstUser;
        }

        async public Task postUsersAsync(UserDetails userDetails)
        {
            RestClient<UserDetails> restClient = new RestClient<UserDetails>();
            var lstUser = await restClient.PostAsync(userDetails);
            //return lstUser;
        }

    }
}
