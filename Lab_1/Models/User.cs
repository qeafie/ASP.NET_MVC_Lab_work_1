using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_1.Models
{
    public class User
    {
        private static Dictionary<String, User> dictionary = new Dictionary<string, User>() {
            { "cat", new User("cat", "123","cat@mail.ru",22)},
            { "dog", new User("dog", "123","dog@gmail.ru",28)},
            { "rat", new User("rat", "123","rat@ya.ru",36)},
        };

        
        private const string V = "[a - zA - z])(.+)([a - zA - z])@((g)? mail|yahoo|rambler|yandex|ya)[\\.](ru|com)$)]";

        [Required(ErrorMessage ="Некоректный логин")]
        [RegularExpression (@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$", ErrorMessage = "Используете только латинские буквы и цифры")]
        //[StringLength (25, ErrorMessage = "Логин не должен быть более 25 символов")]
        public string Login;

        [Required(ErrorMessage = "Некоректный пароль")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$", ErrorMessage = "Используете только латинские буквы и цифры")]
        public string Password;

        [Required(ErrorMessage = "Некоректный email")]
        [RegularExpression (V, ErrorMessage = "Некоректный email")]
        public string Email;

        [Required(ErrorMessage = "Некоректный возраст")]
        [Range (18,65,ErrorMessage ="Возраст должен быть в диапазоне от 18 до 65")]
        public int Age;

        
        public string GetLogin()
        {
            return Login;
        }
        public string GetPassword()
        {
            return Password;
        }
        public string GetEmail()
        {
            return Email;
        }

        public int GetAge()
        {
            return Age;
        }


        public User(string login, string password, string email, int age) {
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Age = age;
        }


        public User() { }


        public static bool IsValid(String login, String password) {
            login = login.ToLower();
            if (dictionary.ContainsKey(login))
            {
                if (dictionary[login].GetPassword().Equals(password)) {                
                    return true;
                }
            }
            return false;
        }

        public static void SetUser(User user)
        {
            dictionary.Add(user.Login.ToLower(),user);
        }
        public static User GetUser(string key)
        {
            return dictionary[key];
        }
        
    }
}