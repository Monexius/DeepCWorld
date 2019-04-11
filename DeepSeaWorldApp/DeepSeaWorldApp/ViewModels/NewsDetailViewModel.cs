﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DeepSeaWorldApp.Models;
using DeepSeaWorldApp.Views;
using DeepSeaWorldApp.Services;

namespace DeepSeaWorldApp.ViewModels
{
    public class NewsDetailViewModel
    {
        public News News { get; }

        public NewsDetailViewModel()
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
        public NewsDetailViewModel(string name)
        {
            //get item by "name" (image source name) and fill contents
            News = new News
            {
                Title = name,
                Lead = "Lead lorem ipsum lead lorem ipsum lead lorem ipsum",
                Image = "deep_sea.png",
                Body = "Body lorem ipsum body lorem ipsum body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum",
            };
        }
        public NewsDetailViewModel(News news)
        {
            //get item by "name" (image source name) and fill contents
            News = new News
            {
                Title = news.Title,
                Lead = "Lead lorem ipsum lead lorem ipsum lead lorem ipsum",
                Image = "deep_sea.png",
                Body = "Body lorem ipsum body lorem ipsum body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum" +
                    "body lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsumbody lorem ipsum",
            };
        }
    }
}