using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.Util;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Environment = Android.OS.Environment;

namespace Project3Hangman
{
    class Database
    {
        SQLiteConnection db;
        //private static string databasePath;
        //private static string databaseName;
        //Random chaos = new Random();

        public Database()
        {
            DBConnect();

            //db.CreateTable<words>();
        }

        private void DBConnect()
        {
            //databaseName = "Hangman.db";
            //databasePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), databaseName);
            db = new SQLiteConnection(Path.Combine(Environment.ExternalStorageDirectory.ToString(), "Hangman.db"));
        }

        //public IEnumerable<words> GetWords()
        //{
        //    if (db.Table<words>().Count() > 0)
        //    {
        //        return db.Query<words>("SELECT * FROM words");
        //    }
        //    else
        //    {
        //        // make a fake word to stop the system from crashing when the DB doesn't connect
        //        List<words> fakeword = new List<words>();
        //        // make a single word
        //        words word = new words();
        //        word = FakeEntry();
        //        fakeword.AddRange(new[] { word }); // add it to the fake words list
        //        return fakeword;

        //    }
        //}

        public IEnumerable<words> ViewAll()
        {
            //try
            //{
                return db.Query<words>("SELECT * FROM words");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error:" + e.Message);

            //    //making some fake items to stop the system from crashing when the DB doesn't connect
            //    List<words> fakeword = new List<words>();
            //    //make a single item
            //    words word = new words();
            //    word.Id = 100;
            //    word.Word = "Fake word";
            //    fakeword.AddRange(new[] { word }); //add it to the fake item list

            //    return fakeword;
            //}
        }

        public IEnumerable<words> GetWords()
        {
            return db.Query<words>("SELECT * FROM words");
        }

        //public static words FakeEntry()
        //{
        //    words word = new words();
        //    word.Id = 1;
        //    word.Word = "Fake word";
        //    return word;
        //}

        //public static string SelectWord()
        //{
        //    string result = "blank";

        //    try
        //    {
        //        result = db.Query<words>("SELECT Word FROM words WHERE Id = 2").ToString();
        //    }
        //    catch (Exception e)
        //    {

        //        result = e.Message;
        //    }

        //    return result;
        //}

        //public string GetRandomWord()
        //{
        //    string returnWord = "?ERROR?";
        //    SQLiteConnection db = new SQLiteConnection(databasePath);
        //    //db.CreateTable<words>();
        //    //var table = db.Table<words>();

        //    //returnWord = table.ElementAt(chaos.Next(1, 4)).word;
        //    return returnWord;
        //}
    }
}