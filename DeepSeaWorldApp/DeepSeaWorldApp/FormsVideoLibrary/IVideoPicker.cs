//Title: VideoPlayerDemos
//Author: Charles Petzold
//Date: 20/04/2019
//Availability: https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/VideoPlayerDemos
using System;
using System.Threading.Tasks;

namespace DeepSeaWorldApp.FormsVideoLibrary
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
