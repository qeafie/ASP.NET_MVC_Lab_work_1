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
            { "cat", new User("cat", "a123","cat@mail.ru",22)},
            { "dog", new User("dog", "b123","dog@gmail.ru",28)},
            { "rat", new User("rat", "c123","rat@ya.ru",36)},
        };

        
        
        

        [Required(ErrorMessage = "Некоректный логин")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$", ErrorMessage = "Используете только латинские буквы и цифры")]
        [Display(Name = "Логин")]
        //[StringLength (25, ErrorMessage = "Логин не должен быть более 25 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Некоректный пароль")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$", ErrorMessage = "Используете только латинские буквы и цифры")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Некоректный пароль")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Пароли должны совпадать")]
        public string PasswordRepeat { get; set; }

        [Required(ErrorMessage = "Некоректный email")]
        [RegularExpression (@"([a-zA-z])(.+)([a-zA-z])@((g)?mail|yahoo|rambler|yandex|ya)[\.](ru|com)$", ErrorMessage = "Некоректный email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Некоректный возраст")]
        [Range (18,65,ErrorMessage ="Возраст должен быть в диапазоне от 18 до 65")]
        public int Age { get; set; }





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
                if (dictionary[login].Password.Equals(password)) {                
                    return true;
                }
            }
            return false;
        }

        public static bool SetUser(User user)
        {
            if (dictionary[user.Login] != null) {
                dictionary.Add(user.Login.ToLower(), user);
                return true;
            }
            return false;
            
        }
        public static User GetUser(string key)
        {
            return dictionary[key];
        }
        
        public static bool CheckUser(string key)
        {
            return dictionary.ContainsKey(key);
        }
    }
}