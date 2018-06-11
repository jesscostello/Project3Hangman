using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project3Hangman
{
    class DataAdapter : BaseAdapter<words>
    {
        private readonly Activity context;
        private readonly List<words> items;

        public DataAdapter(Activity context, List<words> items)
        {
            this.context = context;
            this.items = items;
        }

        public override words this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            //if (view == null)
                //view = context.LayoutInflater.Inflate(Resource.Id.textView1, null);
                //view.FindViewById<ListView>(Resource.Id.list_item) = "this is a test";
                //view = context.LayoutInflater.Inflate(Resource.Layout.Game, null);
                //view = context.LayoutInflater.Inflate(Resource.Layout.listView1, null);

                //view = context.LayoutInflater.Inflate(Resource.Layout.CustomRowScore, null);
                //view.FindViewById<TextView>(Resource.Id.lblName).Text = item.Word;

            return view;
        }
    }
}