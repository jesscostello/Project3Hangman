using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Project3Hangman
{
    public static class DataManager
    {
        public static SQLiteConnection db;
        public static string databasePath;
        public static string databaseName;
        static DataManager()
        {//Set the DB connection string
            databaseName = "HangmanScores.db";
            databasePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), databaseName);
            db = new SQLiteConnection(databasePath);

            db.CreateTable<scores>();
        }
        public static List<scores> ViewAll()
        {
            try
            {
                return db.Query<scores>("SELECT * FROM scores ORDER BY score DESC");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                //making some fake items to stop the system from crashing when the DB doesn't connect
                List<scores> fakeitem = new List<scores>();
                //make a single item
                scores item = new scores();
                item.Id = 1000;
                item.Name = "No Scores Yet";
                item.Score = 0;
                fakeitem.AddRange(new[] { item }); //add it to the fake item list
                return fakeitem;
            }
        }

        public static void AddItem(string name, int score, string category)
        {
            try
            {
                var addThis = new scores() { Name = name, Score = score, Category = category };
                db.Insert(addThis);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        public static void ResetScores()
        {
            try
            {
                db.Query<scores>("DELETE FROM scores");
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error:" + e.Message);
            }
        }

        //public static void CopyTheDB()
        //{
        //    // Check if your DB has already been extracted. If the file does not exist move it.
        //    //WARNING!!!!!!!!!!! If your DB changes from the first time you install it, ie: you change the tables, and you get errors then comment out the if wrapper so that it is FORCED TO UPDATE.
        //    //Otherwise you spend hours staring at code that should run OK but the db, that you can’t see inside of on your phone, is diffferent from the db you are coding to.
        //    if (!File.Exists(DataManager.databasePath))
        //    {
        //        AssetManager Assets = Android.App.Application.Context.Assets;
        //        using (BinaryReader br = new BinaryReader(Assets.Open(DataManager.databaseName)))
        //        {
        //            using (BinaryWriter bw = new BinaryWriter(new FileStream(DataManager.databasePath, FileMode.Create)))
        //            {
        //                byte[] buffer = new byte[2048];
        //                int len = 0;
        //                while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
        //                {
        //                    bw.Write(buffer, 0, len);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}