using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Views;
namespace DeepSeaWorldApp.ViewModels
{
    public class PromoViewModel
    {
        public News News { get; }

        public PromoViewModel()
        {
            News = new News
            {
                Title = "News Title",
                Lead = "Lead lorem ipsum lead lorem ipsum lead lorem ipsum",
                Image = "deep_sea.png",
                Body = "Body lorem ipsum body lorem ipsum body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum",
            };
        }
        public PromoViewModel(string name)
        {
            News = new News
            {
                Title = "News Title",
                Lead = "Lead lorem ipsum lead lorem ipsum lead lorem ipsum",
                Image = "deep_sea.png",
                Body = "Body lorem ipsum body lorem ipsum body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum",
            };
        }
    }
}