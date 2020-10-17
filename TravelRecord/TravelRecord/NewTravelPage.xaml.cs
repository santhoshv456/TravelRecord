﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEntry.Text))
            {
                DisplayAlert("Not Found","Please enter the Experience","Ok");
                return;
            }

            Post post = new Post() 
            { 
                Experience = txtEntry.Text 
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.databaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                if (rows > 0)
                    DisplayAlert("Success", "Experience Successfully Inserted", "Ok");
                else
                    DisplayAlert("Failure", "Experience Failed to Insert", "Ok");
            }
                
        }
    }
}