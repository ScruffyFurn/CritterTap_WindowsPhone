using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace CritterTap
{
    public partial class GamePage : PhoneApplicationPage
    {
        ContentManager contentManager;
        GameTimer timer;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        //Textures
        Texture2D backgroundTexture;
        Texture2D clockTexture;
        Texture2D starsTexture;

        List<Critter> critters = new List<Critter>();

        float gameplayTime = 61;

        

        public GamePage()
        {
            InitializeComponent();

            // Get the content manager from the application
            contentManager = (Application.Current as App).Content;

            App.CurrentScore = 0;

            // Create a timer for this page
            timer = new GameTimer();
            timer.UpdateInterval = TimeSpan.FromTicks(333333);
            timer.Update += OnUpdate;
            timer.Draw += OnDraw;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the sharing mode of the graphics device to turn on XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(true);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(SharedGraphicsDeviceManager.Current.GraphicsDevice);

            spriteFont = contentManager.Load<SpriteFont>(@"Assets\SpriteFont1");

            //Load content
            backgroundTexture = contentManager.Load<Texture2D>(@"Assets\background");
            
            starsTexture = contentManager.Load<Texture2D>(@"Assets\stars");
            clockTexture = contentManager.Load<Texture2D>(@"Assets\clock");


            //Critter creation
            for (int i = 0; i <= 8; i++)
            {
                if (i <= 2)
                {
                    
                    Critter tempCritter = new Critter(new Vector2((144 * i) + 25, 160));
                    critters.Add(tempCritter);
                    System.Threading.Thread.Sleep(100);
                }
                if (i >= 3 && i <= 5)
                {
                    Critter tempCritter = new Critter(new Vector2((144 * (i - 3)) + 25, 318));
                    critters.Add(tempCritter);
                    System.Threading.Thread.Sleep(100);
                }
                if (i >= 6 && i <= 8)
                {
                    Critter tempCritter = new Critter(new Vector2((144 * (i - 6)) + 25, 478));
                    critters.Add(tempCritter);
                    System.Threading.Thread.Sleep(100);
                }
            }

            // Start the timer
            timer.Start();

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Set the sharing mode of the graphics device to turn off XNA rendering
            SharedGraphicsDeviceManager.Current.GraphicsDevice.SetSharingMode(false);

            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Allows the page to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        private void OnUpdate(object sender, GameTimerEventArgs e)
        {
            //
            float timeDelta = (float)e.ElapsedTime.TotalSeconds;

            gameplayTime -= timeDelta;
            if (gameplayTime <= 0)
            {
                //GameOver
                App.AddLocalHighScore();
                App.AddScoreToGlobalScoreList();
                NavigationService.Navigate(new Uri("/GameOverPage.xaml", UriKind.Relative));
            }
            //Get Touches
            TouchCollection touches = TouchPanel.GetState();

            //update each critter and check if wacked 
            foreach (Critter critter in critters)
            {
                critter.Update(timeDelta);
                foreach (TouchLocation location in touches)
                {
                    if (critter.currentState == Critter.CritterState.popped &&
                        critter.critterRect.Contains((int)location.Position.X, (int)location.Position.Y))
                    {
                        //Wacked!
                        critter.currentState = Critter.CritterState.whacked;
                        App.CurrentScore += 10;
                    }
                }
            }
        }

        /// <summary>
        /// Allows the page to draw itself.
        /// </summary>
        private void OnDraw(object sender, GameTimerEventArgs e)
        {
            SharedGraphicsDeviceManager.Current.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // Draw background
            spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);

            //Draw Time / Clock
            spriteBatch.Draw(clockTexture, new Vector2(50, 10), Color.White);
            spriteBatch.DrawString(spriteFont, gameplayTime.ToString("00"), new Vector2(52 + clockTexture.Width, 10), Color.Tomato);
            //Draw Point / Stars
            spriteBatch.Draw(starsTexture, new Vector2(250, 10), Color.White);
            spriteBatch.DrawString(spriteFont, App.CurrentScore.ToString(), new Vector2(253 + starsTexture.Width, 10), Color.Tomato);

            foreach (Critter critter in critters)
                critter.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}