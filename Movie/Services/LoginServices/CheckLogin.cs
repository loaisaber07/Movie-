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
<<<<<<< HEAD
                Console.WriteLine("please enter the number ");
            return false;
=======
                Console.WriteLine("please enter te right one ");
                Console.WriteLine("for  testing ");
                return false;
>>>>>>> 1faba3ac657e3857ebad6c57bd0849c95bb333b1
            }
            return true;
        
        }
    }
}
