using NoteApplication.Data;
using NoteApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApplication
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        //IEnumerable is an generic interface for collections
        private IEnumerable<NoteItem> NoteItems;
        // An observable property is any property that calls OnPropertyChanged
        public IEnumerable<NoteItem> Items
        {
            get { return NoteItems; }
            set
            {
                // equality check
                if (Equals(NoteItems, value))
                    return;
                // set the backing field
                NoteItems = value;
                // Notify view of a new value
                OnPropertyChanged();
            }
        }
        public ListViewPage()
        {
            // Connect this view to its xaml
            InitializeComponent();

           
            NavigationPage.SetHasNavigationBar(this, true);
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //refresh our items list
            Items = NoteItemDatabase.GetDatabase().GetItems();
        }

        public void OnAdd(object sender, EventArgs e)
        {
            var model = new NoteItem();
            var view = new MainPage(model);
            Navigation.PushAsync(view, true);
        }

        public void OnSelect(object sender, SelectedItemChangedEventArgs e)
        {
            
            var model = (NoteItem)e.SelectedItem;
            var view = new MainPage(model);
            Navigation.PushAsync(view, true);
        }
    }
}