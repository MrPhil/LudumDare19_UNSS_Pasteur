using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LD19
{
    public static class FadeMessageManager
    {
        public static string Message = ".";
        public static SpriteFont Font;
        private static bool showing = false;
        private static double timer;

        public static void Initialize( SpriteFont font )
        {
            Font = font;
        }

        public static void Show(string message)
        {
            Message = message;
            showing = true;
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (showing)
            {
                spriteBatch.DrawString(Font, Message, new Vector2(10, 250), Color.White);
            }
        }
        public static void Update(GameTime gameTime)
        {
            if (showing)
            {
                if (timer == -1)
                {
                    // Start the timer
                    timer = gameTime.TotalGameTime.TotalSeconds + 5;
                }
                else if (timer < gameTime.TotalGameTime.TotalSeconds)
                {
                    // Times up
                    showing = false;
                    timer = -1;
                }
            }
        }
    }
}
