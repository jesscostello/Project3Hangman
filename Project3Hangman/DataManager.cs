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
        {
            //Set the DB connection string
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

        public static List<scores> ViewAllAnimalsScores()
        {
            try
            {
                return db.Query<scores>("SELECT * FROM scores WHERE Category = 'ANIMALS' ORDER BY score DESC");
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

        public static List<scores> ViewAllCountriesScores()
        {
            try
            {
                return db.Query<scores>("SELECT * FROM scores WHERE Category = 'COUNTRIES' ORDER BY score DESC");
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
    }
}