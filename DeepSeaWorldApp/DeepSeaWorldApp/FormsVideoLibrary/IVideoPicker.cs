using System;
using System.Threading.Tasks;

namespace DeepSeaWorldApp.FormsVideoLibrary
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
