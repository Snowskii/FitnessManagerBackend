using Backend.Models;
using Backend.Models.RequestModels;
using Microsoft.AspNetCore.Identity;

namespace Backend.DB
{
    public static class DBInitializer
    {
        public static void Initialize(ApplicationDataContext context)
        {
            if (context.Exercises.Any())
            {
                return;
            }
            var hasher = new PasswordHasher<User>();

            var globalUser = new User()
            {
                Name = "Global",
                Surname = "User",
                Email = "global@email.com",
                Role = Role.Admin,
            };
            globalUser.Password = hasher.HashPassword(globalUser, "GlobalPassword123456789");

            var admin = new User()
            {
                Name = "Admin",
                Surname = "Admin",
                Email = "Admin@email.com",
                Role = Role.Admin,
            };
            admin.Password = hasher.HashPassword(admin, "AdminPassword123456789");

            var misko = new User()
            {
                Name = "Michal",
                Surname = "Kiral",
                Email = "somemisko@email.com",
                Role = Role.User,
            };
            misko.Password = hasher.HashPassword(misko, "mojeheslolol");

            var adam = new User()
            {
                Name = "Adam",
                Surname = "Kattar",
                Email = "someKattar@email.com",
                Role = Role.User,
            };
            adam.Password = hasher.HashPassword(adam, "kattaroveheslolol");

            var globalexercise1 = new Exercise()
            {
                Name = "Kliky",
                Sets = 3,
                Type = ExerciseType.Amount,
                TypeAmount = 30
            };

            var globalexercise2 = new Exercise()
            {
                Name = "Drepy",
                Sets = 3,
                Type = ExerciseType.Amount,
                TypeAmount = 30
            };

            var globalexercise3 = new Exercise()
            {
                Name = "Brušáky",
                Sets = 3,
                Type = ExerciseType.Amount,
                TypeAmount = 30
            };
            globalexercise1.User = globalUser;
            globalexercise2.User = globalUser;
            globalexercise3.User = globalUser;

            var miskoWorkout = new Workout()
            {
                Name = "OnePunchMan",
                Description = "Zo serialu One punch man",
                Exercises = new List<Exercise>()
                {
                    globalexercise1,
                    globalexercise2,
                    globalexercise3
                },
                User = misko
            };

            context.AddRange(globalUser, admin, misko, adam);
            context.AddRange(globalexercise1, globalexercise2, globalexercise3);
            context.AddRange(miskoWorkout);
            context.SaveChanges();
        }
    }
}
