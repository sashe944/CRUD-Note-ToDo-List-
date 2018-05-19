using NoteApplication.Data;
using NoteApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteApplication
{
    public partial class MainPage : ContentPage
    {
        public NoteItem Model
        {
            get { return (NoteItem)BindingContext; }
            set
            {
                BindingContext = value;
                OnPropertyChanged();
            }
        }
        public MainPage(NoteItem model)
        {

            Model = model;

            NavigationPage.SetHasNavigationBar(this, true);

            
            if (Model.ID == 0)
                Title = "New Note!";
            else
                Title = String.Format("Note #{0}", Model.ID);
      
            InitializeComponent();
            
        }
        public bool Validate()
        {
            if (string.IsNullOrEmpty(Model.Name))
            {
                DisplayAlert("Validation Error", "'Name' is empty.", "Ok");
                return false;
            }
            return true;
        }
        public void SaveNote_Clicked(object sender, EventArgs e)
        {
            if (!Validate())
                return;

            NoteItemDatabase.GetDatabase().SaveItem(Model);
            Navigation.PopAsync();
        }
        public async void DeleteNote_Clicked(object sender, EventArgs e)
        { 
            var answer = await DisplayAlert("Are You Sure?", "Are you SURE you want to delete this Note ?", "Yes", "Nope");

            if (answer)
            {
                NoteItemDatabase.GetDatabase().DeleteItem(Model.ID);
                await Navigation.PopAsync();
            }
        }
        public void OnCancel(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
