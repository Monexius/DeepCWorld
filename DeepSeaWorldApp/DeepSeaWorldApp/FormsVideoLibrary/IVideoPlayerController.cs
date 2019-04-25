//Title: VideoPlayerDemos
//Author: Charles Petzold
//Date: 20/04/2019
//Availability: https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/VideoPlayerDemos
using System;

namespace DeepSeaWorldApp.FormsVideoLibrary
{ 
    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }
    }
}
