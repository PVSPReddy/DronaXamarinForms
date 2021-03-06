﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
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
        FirebaseAuth authInstance;
        public AndroidFireBaseAuthenticationService()
        {
            Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
            authInstance = FirebaseAuth.GetInstance(fireBaseApp);
        }

        public async Task<bool> AuthenticateUserWithEmailAndPassword()
        {
            bool isAuthenticated = false;
            try
            {

                FirebaseUser currentUser = authInstance.CurrentUser;
                if (currentUser == null)
                {
                    authInstance.CreateUserWithEmailAndPassword("pvsivapr@gmail.com", "sivaprasadreddy").AddOnSuccessListener(this).AddOnFailureListener(this).AddOnCompleteListener(this);
                }
                else
                {
                    var eee1 = currentUser.Email;
                    var eee2 = currentUser.DisplayName;
                    var eee3 = currentUser.IsEmailVerified;
                    var eee4 = currentUser.PhoneNumber; 
                    var eee5 = currentUser.PhotoUrl;
                    var eee6 = currentUser.Uid;


                    //var sdf = currentUser.
                }

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

        public async Task<bool> AuthenticateUserWithGoogleAccount()
        {
            bool isAuthenticated = false;
            try
            {

                FirebaseUser currentUser = authInstance.CurrentUser;

                //Android.Gms.Auth.Api.SignIn.GoogleSignInOptions googleSignInOptions = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn).RequestIdToken("").
                Android.Gms.Auth.Api.SignIn.GoogleSignInOptions googleSignInOptions = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn).RequestEmail().Build();

                //GoogleSignInAccount.

                //var mGoogleSignInClient = GoogleSignInAccount.lient(this, gso);

                //Intent signInIntent = mGoogleSignInClient.getSignInIntent();
                //startActivityForResult(signInIntent, RC_SIGN_IN);



                if (currentUser == null)
                {
                    authInstance.CreateUserWithEmailAndPassword("pvsivapr@gmail.com", "sivaprasadreddy").AddOnSuccessListener(this).AddOnFailureListener(this).AddOnCompleteListener(this);
                }
                else
                {
                    var eee1 = currentUser.Email;
                    var eee2 = currentUser.DisplayName;
                    var eee3 = currentUser.IsEmailVerified;
                    var eee4 = currentUser.PhoneNumber;
                    var eee5 = currentUser.PhotoUrl;
                    var eee6 = currentUser.Uid;
                }
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