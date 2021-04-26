using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Buffet.Data
{
    public class DBHelper
    {
        public static void SeedData(UserManager<IdentityUser> um, ILogger log)
        {
            SeedReceptionUser(um, log);
            Thread.Sleep(1000);
            SeedRestaurantUser(um, log);
            Thread.Sleep(1000);
            SeedKitchenUser(um, log);
        }

        public static void SeedReceptionUser(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string receptionEmail = "recep@null";
            const string password = "Password123!";

            if (userManager.FindByNameAsync(receptionEmail).Result == null)
            {
                log.LogWarning("Seeding reception user");
                var user = new IdentityUser
                {
                    UserName = receptionEmail,
                    Email = receptionEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, password).Result;
                if (result.Succeeded)
                {
                    var claim = new Claim("Reception", "Yes");
                    userManager.AddClaimAsync(user, claim);
                }
            }
        }

        public static void SeedRestaurantUser(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string restaurantEmail = "restau@null";
            const string password = "Password123!";

            if (userManager.FindByNameAsync(restaurantEmail).Result == null)
            {
                log.LogWarning("Seeding restaurantEmail user");
                var user = new IdentityUser
                {
                    UserName = restaurantEmail,
                    Email = restaurantEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, password).Result;
                if (result.Succeeded)
                {
                    var claim = new Claim("Restaurant", "Yes");
                    userManager.AddClaimAsync(user, claim);
                }
            }
        }

        public static void SeedKitchenUser(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string kitchenEmail = "kitch@null";
            const string password = "Password123!";

            if (userManager.FindByNameAsync(kitchenEmail).Result == null)
            {
                log.LogWarning("Seeding kitchen user");
                var user = new IdentityUser
                {
                    UserName = kitchenEmail,
                    Email = kitchenEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, password).Result;
                if (result.Succeeded)
                {
                    var claim = new Claim("Kitchen", "Yes");
                    userManager.AddClaimAsync(user, claim);
                }
            }
        }
    }
}
