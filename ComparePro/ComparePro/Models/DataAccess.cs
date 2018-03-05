using ComparePro.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ComparePro
{
    class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();      //Nos instancia una configuracion dependiendo de cada plataforma
            connection = new SQLiteConnection(config.Platform, System.IO.Path.Combine(config.DirectoryDB, "ComparePro.db3"));   //db3 pq es el estandar en Sqlite
            connection.CreateTable<User>();
        }

        public void InsertUser(User user)
        {
            connection.Insert(user);
        }

        public void UpdateUser(User user)
        {
            connection.Update(user);
        }

        public void DeleteEmpleado(User user)
        {
            connection.Delete(user);
        }

        public User GetUser(int IdUser)
        {
            return connection.Table<User>().FirstOrDefault(c => c.IdUser == IdUser);
        }

        public List<User> GetUsers()
        {
            return connection.Table<User>().OrderBy(c => c.UserName).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

    }
}
