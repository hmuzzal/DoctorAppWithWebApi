using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Java.Lang;

namespace DhakaChoiceDoctorApp.Droid
{  
    //Set MainLauncher = true makes this Activity Shown First on Running this Application  
    //Theme property set the Custom Theme for this Activity  
    //No History= true removes the Activity from BackStack when user navigates away from the Activity  
    [Activity(Label="Splash Screen App",MainLauncher=true,Theme="@style/Theme.Splash",NoHistory=true,Icon="@drawable/icon")]  
    public class SplashScreen : Activity  
    {  
        protected override void OnCreate(Bundle bundle)  
        {  
            base.OnCreate(bundle);  
            //Display Splash Screen for 4 Sec  
            Thread.Sleep(4000);
            //Start Activity1 Activity  
            StartActivity(typeof(MainActivity));
        }  
    }  
}  