using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LD19
{
    public static class EncounterManager
    {
        public static bool EncounterActive = false;
        public static SpriteFont Font;
        private static bool highlightAction1 = true;
        private static SpaceTile lastEncounter = null;
        private static double keyPause = 0;

        public static void Initialize(SpriteFont spriteFont)
        {
            Font = spriteFont;
        }

        public static bool CanEncounter( SpaceTile spaceTile)
        {
            if (EncounterActive || lastEncounter == spaceTile || spaceTile.Encounter == false)
            {
                return false;
            }

            // Clear last encounter
            lastEncounter = null;

            return true;
        }

        public static void Start(SpaceTile spaceTile)
        {
            if( spaceTile == null )
            {
                 // Do Nothing
            }
            else if(CanEncounter(spaceTile))
            {
                EncounterActive = true;
                lastEncounter = spaceTile;
            }
        }
        public static void Update(GameTime gameTime)
        {
            if (EncounterActive)
            {
                if (keyPause <= gameTime.TotalGameTime.TotalSeconds)
                {
                    KeyboardState keyState = Keyboard.GetState();
                    if (lastEncounter.IsAction2() && (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up)
                        || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down)))
                    {
                        highlightAction1 = !highlightAction1;
                        keyPause = gameTime.TotalGameTime.TotalSeconds + .3;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    lastEncounter.EncounterResult(highlightAction1);
                    FrameClear.IsClear = gameTime.TotalGameTime.TotalSeconds + 0.3;
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            int lineHeight = 22;
            int offset = 40;
            if (EncounterActive)
            {
                spriteBatch.DrawString(Font, "Encounter", new Vector2(10, 10), Color.White);

                string text = lastEncounter.GetEncounterText();
                spriteBatch.DrawString(Font, text, new Vector2(10, offset), Color.White);

                
                string[] split = text.Split(new string[] { "\r\n"}, StringSplitOptions.None );
                int startY = split.Length * lineHeight + offset; 
                if (highlightAction1)
                {
                    spriteBatch.DrawString(Font, lastEncounter.GetAction1Text() + " (Press Enter)", new Vector2(10, startY), Color.Yellow);

                    if (lastEncounter.IsAction2())
                    {
                        spriteBatch.DrawString(Font, lastEncounter.GetAction2Text(), new Vector2(10, startY + lineHeight), Color.White);
                    }
                }
                else
                {
                    spriteBatch.DrawString(Font, lastEncounter.GetAction1Text(), new Vector2(10, startY), Color.White);
                    spriteBatch.DrawString(Font, lastEncounter.GetAction2Text() + " (Press Enter)", new Vector2(10, startY + lineHeight), Color.Yellow);
                }
            }
        }
    }
}