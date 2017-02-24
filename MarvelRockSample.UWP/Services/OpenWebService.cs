using MarvelRockSample.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

[assembly: Xamarin.Forms.Dependency(typeof(OpenWebService))]
namespace MarvelRockSample.UWP.Services
{
    public class OpenWebService : IOpenWebService
    {
        public void OpenUrl(string url)
        {
            Launcher.LaunchUriAsync(new Uri(url));
        }
    }
}
