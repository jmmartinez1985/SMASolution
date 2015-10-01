using Android.Content;
using Android.Net;

namespace SMAMobile.Droid.Providers
{
    public static class NetworkProvider
    {
        public static bool IsNetworkAvailable(Context context)
        {
            var connectivityManager = context.GetSystemService(Context.ConnectivityService) as ConnectivityManager;
            if (connectivityManager == null)
                return false;

            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            return activeNetworkInfo != null && activeNetworkInfo.IsConnected;
        }
    }
}