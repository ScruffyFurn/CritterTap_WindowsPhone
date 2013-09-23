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

namespace CritterTap
{
    class Critter
    {
        ContentManager contentManager;
        Texture2D texture;
        Vector2 position;
        Random random = new Random(DateTime.Now.Millisecond);

        float hiddenTimer;
        float poppedTimer;
        float whackedTimer = 1;

        public Rectangle critterRect;

        public enum CritterState { hidden, popped, whacked };
        public CritterState currentState = CritterState.hidden;

        public Critter(Vector2 pos)
        {
            contentManager = (Application.Current as App).Content;
            position = pos;

            critterRect = new Rectangle((int)position.X, (int)position.Y, 144, 144);

            hiddenTimer = random.Next(1, 2);
            poppedTimer = random.Next(0, 3);

            switch (random.Next(0, 4))
            {
                case 0:
                    texture = contentManager.Load<Texture2D>(@"Assets\cat");
                    break;
                case 1:
                    texture = contentManager.Load<Texture2D>(@"Assets\dog");
                    break;
                case 2:
                    texture = contentManager.Load<Texture2D>(@"Assets\fox");
                    break;
                case 3:
                    texture = contentManager.Load<Texture2D>(@"Assets\mole");
                    break;
            }

        }

        public void Update(float timeDelta)
        {
            switch (currentState)
            {
                case CritterState.hidden:
                    hiddenTimer -= timeDelta;
                    if (hiddenTimer <= 0)
                    {
                        currentState = CritterState.popped;
                        hiddenTimer = random.Next(1, 2);
                    }
                    break;
                case CritterState.popped:
                    poppedTimer -= timeDelta;
                    if (poppedTimer <= 0)
                    {
                        currentState = CritterState.hidden;
                        poppedTimer = random.Next(0, 3);
                    }
                    break;
                case CritterState.whacked:
                    whackedTimer -= timeDelta;
                    if (whackedTimer <= 0)
                    {
                        currentState = CritterState.hidden;
                        whackedTimer = 1;
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (currentState)
            {
                case CritterState.hidden:
                    spriteBatch.Draw(texture, critterRect, new Rectangle(0, 0, 144, 144), Color.White);
                    break;
                case CritterState.popped:
                    spriteBatch.Draw(texture, critterRect, new Rectangle(0, 144, 144, 144), Color.White);
                    break;
                case CritterState.whacked:
                    spriteBatch.Draw(texture, critterRect, new Rectangle(0, 288, 144, 144), Color.White);
                    break;
            }
        }
    }
}
