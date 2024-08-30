using Microsoft.AspNetCore.Identity;
using Movie.Entity;
using Movie.ViewModel;

namespace Movie.Services.LoginServices
{
    public static class CheckLogin
    {
 

        public static  async Task<bool> LoginChecker(UserManager<User> userManager ,string Email , string Password) { 
var userModel= await userManager.FindByEmailAsync(Email);
            if (userModel is null) {
                return false; 
            }
     bool result= await userManager.CheckPasswordAsync(userModel,Password);
            if (!result) {
                Console.WriteLine("please enter the number ");
            return false;
            }
            return true;
        
        }
    }
}
