﻿using SQLite.Net.Interop;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(ComparePro.iOS.Config))]
namespace ComparePro.iOS
{
    public class Config : IConfig       //No me reconoce la Interfaz creada !!!!
    {
        private string directoryDB;
        private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    var directory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directoryDB = System.IO.Path.Combine(directory,"--","Library");
                }
                return directoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if(platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return platform;
            }
        }

    }
}