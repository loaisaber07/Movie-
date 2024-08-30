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
                Console.WriteLine("this comment for master ");
                Console.WriteLine("conflic resolved "); 


                Console.WriteLine("please enter the number ");
            return false;

                Console.WriteLine("please enter te right one ");
                Console.WriteLine("for  testing ");
                Console.WriteLine("for  testing ");
                return false;

            }
            return true;
        
        }
    }
}
