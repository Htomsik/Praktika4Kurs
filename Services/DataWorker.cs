﻿using System.Collections.Generic;
using System.Linq;
using Praktika.Models;
using Praktika.Models.Data;
using Praktika.Viewmodels;

namespace Praktika.Services
{
    public static class DataWorker
    {
        #region Пользователи

        #region Создание пользователя

        /// <summary>
        ///     Создание пользователя true-пользователь успешно создан
        /// </summary>
        /// <param name="_Login"></param>
        /// <param name="_Password"></param>
        /// <param name="_Role"></param>
        /// <param name="_FIO"></param>
        public static bool CreateUser(string _Login, string _Password, string _FIO, string _Role)
        {
            using (var db = new AppDbContext())
            {
                //check the user is exist
                var checkIsExist = db.Users.Any(el => el.Login == _Login);
                if (!checkIsExist)
                {
                    var newUser = new User
                    {
                        Login = _Login,
                        Password = _Password,
                        Role = _Role,
                        FIO = _FIO
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Авторизация

        /// <summary>
        ///     Авторизация вручную
        /// </summary>
        /// <param name="_Login"></param>
        /// <param name="_Password"></param>
        /// <returns></returns>
        public static bool Authorization(string _Login, string _Password)
        {
            using (var db = new AppDbContext())
            {
                var s1 = UserSingltonViewmodel.Initialize;

                var _checkuser = db.Users.FirstOrDefault(el => el.Login == _Login && el.Password == _Password);

                if (_checkuser != default)
                {
                    s1.CurrentUser = _checkuser;
                    var js = new JsonWorker();
                    js.SaveUser();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Авторизация из файла
        /// </summary>
        /// <returns></returns>
        public static bool Authorization()
        {
            using (var db = new AppDbContext())
            {
                var JsUser = UserSingltonViewmodel.Initialize;

                return db.Users.Any(el =>
                    el.Login == JsUser.CurrentUser.Login && el.Password == JsUser.CurrentUser.Password);
            }

        }

        #endregion

        #region Работа с видеокартами

        #region Вывод списка видеокарт (list)

        public static List<Videocard> GetAllVideocards()
        {
            using (var db = new AppDbContext())
            {
                return db.Videocards.ToList();
            }
        }

        #endregion

        #region Создать видеокарту

        public static int CreateVideocard(string _Company, string _Name, string _Core, byte _TechProcess,
            string _MemoryType, string _Interface)
        {
            using (var db = new AppDbContext())
            {
                var checkIsExist = db.Videocards.Any(el => el.Name == _Name);

                if (!checkIsExist)
                {
                    var newVideocard = new Videocard
                    {
                        Company = _Company,
                        Name = _Name,
                        Core = _Core,
                        TechProcess = _TechProcess,
                        MemoryType = _MemoryType,
                        Interface = _Interface
                    };

                    db.Videocards.Add(newVideocard);
                    db.SaveChanges();

                    return db.Videocards.FirstOrDefault(el => el.Name == _Name).ID;
                }

                return default;
            }
        }

        #endregion

        #region Удалить видеокату

        public static bool DeleteVideoCard(Videocard DelVideocard)
        {
            using (var db = new AppDbContext())
            {
                var checkIsExist = db.Videocards.FirstOrDefault(el => el.ID == DelVideocard.ID && el.Name == DelVideocard.Name);

                if (checkIsExist!=default)
                {
                    db.Videocards.Remove(checkIsExist);
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        #endregion

        #endregion

        #endregion
    }
}