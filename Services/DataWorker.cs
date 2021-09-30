﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Praktika.Models;
using Praktika.Models.Data;

namespace Praktika.Services
{
    public static class DataWorker
    {

        #region Пользователи

        #region Создание

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="_Login"></param>
        /// <param name="_Password"></param>
        /// <param name="_Role"></param>
        /// <param name="_FIO"></param>
        public static void CreateUser(string _Login, string _Password, string _Role, string _FIO)
        {

            using (AppDbCOntext db = new AppDbCOntext())
            {
                //check the user is exist
                bool checkIsExist = db.Users.Any(el => el.Login == _Login);
                if (!checkIsExist)
                {
                    User newUser = new User
                    {
                        Login = _Login,
                        Password = _Password,
                        Role = _Role,
                        FIO = _FIO
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

            }
        }

        #endregion

        #region Авторизация

        public static bool Authorization(string _Login, string _Password)
        {

            using (AppDbCOntext db = new AppDbCOntext())
            {
                return db.Users.Any(el => el.Login == _Login && el.Password == _Password);
            }
        }


        #endregion


        #endregion


    }
}