//Title: VideoPlayerDemos
//Author: Charles Petzold
//Date: 20/04/2019
//Availability: https://github.com/xamarin/xamarin-forms-samples/tree/master/CustomRenderers/VideoPlayerDemos

namespace DeepSeaWorldApp.FormsVideoLibrary
{
    public class VideoInfo
    {
        public string DisplayName { set; get; }

        public VideoSource VideoSource { set; get; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
