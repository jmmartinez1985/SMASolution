using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace SMAMobile.Droid.Activities
{
    //Set MainLauncher = true makes this Activity Shown First on Running this Application  
    //Theme property set the Custom Theme for this Activity  
    //No History= true removes the Activity from BackStack when user navigates away from the Activity  
    [Activity(Label = "Service Market", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Thread.Sleep(10000); // Simulate a long loading process on app startup.

            // Create your application here
            //if (NetworkProvider.IsNetworkAvailable(this))
            //{
            //    try
            //    {
            //        // Service
            //        //InspectoresService service = new InspectoresService();

            //        // Get Task Result
            //        //Task<bool> syncTask = service.DownloadSync();

            //        // When all tasks are done validate if-else
            //        //await Task.WhenAll(syncTask);

            //        var sincronizacionSatisfactoria = false;

            //        if (!sincronizacionSatisfactoria)
            //        {
            //            Toast.MakeText(this, this.Resources.GetString(Resource.String.anunciosSyncError), ToastLength.Short).Show();
            //        }
            //        else
            //        {
            //            Toast.MakeText(this, this.Resources.GetString(Resource.String.anunciosSyncError), ToastLength.Short).Show();
            //        }
            //    }
            //    catch (System.Exception)
            //    {
            //        Toast.MakeText(this, this.Resources.GetString(Resource.String.anunciosSyncError), ToastLength.Short).Show();
            //    }
            //}

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}