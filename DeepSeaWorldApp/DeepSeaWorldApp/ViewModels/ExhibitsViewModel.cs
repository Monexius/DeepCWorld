using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Views;

namespace DeepSeaWorldApp.ViewModels
{
    public class ExhibitsViewModel : BaseViewModel2
    {
        public ObservableCollection<Exhibit> Exhibits { get; set; }
        public Command LoadExhibitsCommand { get; set; }

        public ExhibitsViewModel()
        {
            Title = "Deep Sea World";
            Exhibits = new ObservableCollection<Exhibit>();
            LoadExhibitsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewExhibitPage, Exhibit>(this, "AddExhibit", async (obj, exhibit) =>
            //{
            //    var newExhibit = exhibit as Exhibit;
            //    Exhibits.Add(newExhibit);
            //    await DataStore.AddItemAsync(newExhibit);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Exhibits.Clear();
                var exhibits = await DataStore.GetItemsAsync(true);
                foreach (var exhibit in exhibits)
                {
                    Exhibits.Add(exhibit);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}