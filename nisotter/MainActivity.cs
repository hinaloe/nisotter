using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CoreTweet;

namespace nisotter
{
    [Activity(Label = "ﾆｰｿｷﾓﾁｲｲｲｲｲｲｲｲｲ", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //CoreTweet初期化
        public OAuth.OAuthSession session;
        public Tokens token;
        public ISharedPreferences prefs;
        public string AccessToken;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            prefs = GetSharedPreferences("pref", FileCreationMode.Private);
            AccessToken = prefs.GetString("AccessToken", "");
            Console.WriteLine("Debug:"+AccessToken);
            if (AccessToken=="")
            {
                auth();
            }
            else
            {
                layout1();
            }

        }
        void auth()
        {
            Console.WriteLine("Debug:OK");
            //初回起動時
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            EditText pin = FindViewById<EditText>(Resource.Id.editText1);
            string code;
            button.Click += (sender, e) =>
            {
                //token発行
                session = OAuth.Authorize(twitter.ConsumerKey, twitter.ConsumerSecret);
                string url = session.AuthorizeUri.ToString();
                var uri = Android.Net.Uri.Parse(url);
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
                pin.Enabled = true;
            };
            pin.TextChanged += (sender, e) =>
            {
                code = pin.Text;
                int n;
                if (code.Length == 7 && int.TryParse(code, out n) && button1.Enabled == false)
                {
                    button1.Enabled = true;
                }
                else if (button1.Enabled == true)
                {
                    button1.Enabled = false;
                }
            };
            button1.Click += (sender, e) =>
            {
                code = pin.Text;
                try
                {
                    token = session.GetTokens(code);
                }
                catch (TwitterException ex)
                {
                    Toast.MakeText(this, "エラーが発生しました、もう一度やり直してください\n" + ex.Message, ToastLength.Long).Show();
                    return;
                }
                catch (System.Net.WebException ex)
                {
                    Toast.MakeText(this, "エラーが発生しました、もう一度やり直してください\n" + ex.Message, ToastLength.Long).Show();
                    return;
                }

                var editor = prefs.Edit();
                editor.PutString("AccessToken", token.AccessToken);
                editor.PutString("AccessTokenSecret", token.AccessTokenSecret);
                editor.Commit();
                //Dispose();
                layout1();
            };
        }
        void layout1()
        {
            SetContentView(Resource.Layout.layout1);
            //ボタン類
            Button tana3n = FindViewById<Button>(Resource.Id.button1);
            Button Numaochi_LJMn = FindViewById<Button>(Resource.Id.button2);
            Button PENPEN_PENDUAL = FindViewById<Button>(Resource.Id.button3);
            Button yuutosi_hiyuu = FindViewById<Button>(Resource.Id.button4);
            Button Xperia_neko = FindViewById<Button>(Resource.Id.button5);
            Button tar_xz = FindViewById<Button>(Resource.Id.button6);
            Button atuage70 = FindViewById<Button>(Resource.Id.button7);
            Button myskng = FindViewById<Button>(Resource.Id.button8);
            Button knws_vx = FindViewById<Button>(Resource.Id.button9);
            Button nulltic = FindViewById<Button>(Resource.Id.button10);
            Button R1UMiN = FindViewById<Button>(Resource.Id.button11);
            Button CLPSSDX99 = FindViewById<Button>(Resource.Id.button12);
            Button sudosan = FindViewById<Button>(Resource.Id.button13);
            //設定再読み出し
            prefs = GetSharedPreferences("pref", FileCreationMode.Private);
            AccessToken = prefs.GetString("AccessToken", "");
            var AccessTokenSecret = prefs.GetString("AccessTokenSecret", "");
            //トークン発行
            token = Tokens.Create(twitter.ConsumerKey, twitter.ConsumerSecret, AccessToken, AccessTokenSecret);
            //イベントハンドラ
            tana3n.Click += (sender, e) => 
            {
                tana3n.Enabled = false;
                retweet(niso.tana3n,"@sudosan");
                tana3n.Enabled = true;
            };
            Numaochi_LJMn.Click += (sender, e) =>
            {
                Numaochi_LJMn.Enabled = false;
                retweet(niso.Numaochi_LJMn, "@Numaochi_LJMn");
                Numaochi_LJMn.Enabled = true;
            };
            PENPEN_PENDUAL.Click += (sender, e) =>
            {
                PENPEN_PENDUAL.Enabled = false;
                retweet(niso.PENPEN_PENDUAL, "@PENPEN_PENDUAL");
                PENPEN_PENDUAL.Enabled = true;
            };
            yuutosi_hiyuu.Click += (sender, e) =>
            {
                yuutosi_hiyuu.Enabled = false;
                retweet(niso.yuutosi_hiyuu, "@yuutosi_hiyuu");
                yuutosi_hiyuu.Enabled = true;
            };
            Xperia_neko.Click += (sender, e) =>
            {
                Xperia_neko.Enabled = false;
                retweet(niso.Xperia_neko, "@Xperia_neko");
                Xperia_neko.Enabled = true;
            };
            tar_xz.Click += (sender, e) =>
            {
                tar_xz.Enabled = false;
                retweet(niso.tar_xz, "@tar_xz");
                tar_xz.Enabled = true;
            };
            atuage70.Click += (sender, e) =>
            {
                atuage70.Enabled = false;
                retweet(niso.atuage70, "@atuage70");
                atuage70.Enabled = true;
            };
            myskng.Click += (sender, e) =>
            {
                myskng.Enabled = false;
                retweet(niso.myskng, "@myskng");
                myskng.Enabled = true;
            };
            knws_vx.Click += (sender, e) =>
            {
                knws_vx.Enabled = false;
                retweet(niso.knws_vx, "@knws_vx");
                knws_vx.Enabled = true;
            };
            nulltic.Click += (sender, e) =>
            {
                nulltic.Enabled = false;
                retweet(niso.nulltic, "@nulltic");
                nulltic.Enabled = true;
            };
            R1UMiN.Click += (sender, e) =>
            {
                R1UMiN.Enabled = false;
                retweet(niso.R1UMiN, "@R1UMiN");
                R1UMiN.Enabled = true;
            };
            CLPSSDX99.Click += (sender, e) =>
            {
                CLPSSDX99.Enabled = false;
                retweet(niso.CLPSSDX99, "@CLPSSDX99");
                CLPSSDX99.Enabled = true;
            };
            sudosan.Click += (sender, e) =>
            {
                sudosan.Enabled = false;
                retweet(niso.sudosan, "宣伝");
                sudosan.Enabled = true;
            };
        }
        void retweet(long kurorekishi,string user)
        {
            try
            {
                //リツイート
                token.Statuses.Retweet(id => kurorekishi);
            }
            catch (TwitterException)
            {
                try
                {
                    //Toast.MakeText(this, "既にリツイート済みのツイートです。自動的に処理されますのでしばらくお待ち下さい", ToastLength.Long).Show();
                    //リツイート済みの場合
                    var retweetid = token.Statuses.Show(id => kurorekishi, include_my_retweet => "true").CurrentUserRetweet;
                    //リツイート取り消し
                    token.Statuses.Destroy(id => retweetid);
                    //リツイート
                    token.Statuses.Retweet(id => kurorekishi);
                }
                catch (TwitterException ex)
                {
                    Toast.MakeText(this, "エラーが発生しました、ブロックされているかツイートが存在しません\n" + ex.Message, ToastLength.Long).Show();
                    return;
                }
                catch (System.Net.WebException ex)
                {
                    Toast.MakeText(this, "エラーが発生しました、もう一度やり直してください\n" + ex.Message, ToastLength.Long).Show();
                    return;
                }
                catch (NullReferenceException ex)
                {
                    Toast.MakeText(this, "自分自身のツイートはリツイートできません\n" + ex.Message, ToastLength.Long).Show();
                    return;
                }
            }
            catch (System.Net.WebException ex)
            {
                Toast.MakeText(this, "エラーが発生しました、もう一度やり直してください\n" + ex.Message, ToastLength.Long).Show();
                return;
            }
            Toast.MakeText(this, user + "さんの黒歴史を掘り返しました", ToastLength.Long).Show();
        }
    }
}

