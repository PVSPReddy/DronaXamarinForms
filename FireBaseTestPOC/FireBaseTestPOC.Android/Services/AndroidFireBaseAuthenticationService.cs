using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Tasks;
using Firebase.Auth;
using FireBaseTestPOC.Droid.Services;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFireBaseAuthenticationService))]
namespace FireBaseTestPOC.Droid.Services
{
    public class AndroidFireBaseAuthenticationService : Java.Lang.Object, IFireBaseAuthenticationService, IOnSuccessListener, IOnCompleteListener, IOnFailureListener
    {
        //FirebaseAuth authInstance;
        public AndroidFireBaseAuthenticationService()
        {
            Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
            //authInstance = FirebaseAuth.GetInstance(fireBaseApp);
        }

        public async Task<bool> AuthenticateUser()
        {
            bool isAuthenticated = false;
            try
            {
                /*
                FirebaseUser currentUser = authInstance.CurrentUser;
                if (currentUser == null)
                {
                    authInstance.CreateUserWithEmailAndPassword("pvsivapr@gmail.com", "sivaprasadreddy").AddOnSuccessListener(this).AddOnFailureListener(this).AddOnCompleteListener(this);
                }
                else
                {
                    //var sdf = currentUser.
                }
                */
                //AuthCredential authCredential = AuthCredential.;
                //authInstance.SignInWithCredentialAsync()

                //// Choose authentication providers
                //List<AuthUI.IdpConfig> providers = Arrays.asList(
                //new AuthUI.IdpConfig.EmailBuilder().build(),
                //new AuthUI.IdpConfig.PhoneBuilder().build(),
                //new AuthUI.IdpConfig.GoogleBuilder().build(),
                //new AuthUI.IdpConfig.FacebookBuilder().build(),
                //new AuthUI.IdpConfig.TwitterBuilder().build());

                //// Create and launch sign-in intent
                //startActivityForResult(
                //AuthUI.getInstance()
                //        .createSignInIntentBuilder()
                //        .setAvailableProviders(providers)
                //        .build(),
                //RC_SIGN_IN);
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return isAuthenticated;
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            try
            {
                if (task.IsSuccessful)
                {

                }
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
}

