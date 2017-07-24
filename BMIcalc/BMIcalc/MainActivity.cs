using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace BMIcalc
{
    [Activity(Label = "BMIcalc", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //Get handles to controls

            Button calcBMI = FindViewById<Button>(Resource.Id.calcBMI);
            Button clear = FindViewById<Button>(Resource.Id.clear);
            EditText feet = FindViewById<EditText>(Resource.Id.feet);
            EditText inches = FindViewById<EditText>(Resource.Id.inches);
            EditText pounds = FindViewById<EditText>(Resource.Id.pounds);



            calcBMI.Click += delegate
            {

                // check the lenght of the amountEditText control
                if (feet.Text.Length < 1 || inches.Text.Length < 1 || pounds.Text.Length < 1)
                {
                    return;
                }
                else
                {
                    int numFeet;
                    int numInches;
                    double numPounds;
                    int totalInches;
                    double meters;
                    double kilograms;
                    double BMI;
                    try
                    {
                        numFeet = Convert.ToInt32(feet.Text);
                        numInches = Convert.ToInt32(inches.Text);
                        numPounds = Convert.ToDouble(pounds.Text);
                        totalInches = (numFeet * 12) + numInches;
                        meters = totalInches * .025;
                        kilograms = numPounds * .45;
                        meters *= meters;
                        BMI = kilograms / meters;
                        var strBMI = Convert.ToString(BMI);
                        Toast.MakeText(this, "Your BMI is " + strBMI, ToastLength.Long).Show();

                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, "Please enter a number!!!!", ToastLength.Long).Show();
                        feet.Text = "";
                        inches.Text = "";
                        pounds.Text = "";
                        Console.WriteLine("Error - conversion: " + ex.Message);
                    }
                }
            };
            clear.Click += delegate
            {
                feet.Text = "";
                inches.Text = "";
                pounds.Text = "";  

            };
        }
    }
}

