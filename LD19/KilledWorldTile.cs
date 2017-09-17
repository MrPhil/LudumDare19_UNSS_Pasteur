using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LD19
{
    class KilledWorldTile : StarTile
    {
        public KilledWorldTile(Vector2 worldLocation)
            : base(worldLocation)
        {
        }

        public override string GetEncounterText()
        {
            return "You discover a once inhabited world.\r\nIt appears no one is left?\r\nShould we investigate further?";
        }

        public override void EncounterResult(bool action1Selected)
        {
            if (action1Selected)
            {
                int roll = Random.Next(1, 30);

                string message = "You find nothing but a hauntingly empty planet.";
                switch (roll)
                {
                    case 1:
                        message = "You accidently bring a computer virus back to the ship.\r\nIt damages the sensors before being nuetralized, scanner range decreased 40%!";
                        Player.LongRange -= (int)(Player.LongRange * 0.40);
                        break;
                    case 2:
                        message = "An automated defensive system hacker the computer and uploads a virus.\r\nDamage to the sensors reduces range by 25%!";
                        Player.LongRange -= (int)(Player.LongRange * 0.25);
                        break;
                    case 3:
                        message = "Several crew men are exposed to ERL,\r\nluckily quarantine procedures worked and the mission is not harmed.";
                        break;
                    case 4:
                        message = "Due to a quarantine failure the entire crew has been exposed to a new strain of ERL.\r\nThe entire crew eventually dies.\r\nYou’ve failed and humanity has been completely whipped out.";
                        Game1.Failure = true;
                        break;
                    case 5:
                        message = "You discover that the planet was suffering from ERL too.\r\nAstoundingly, they managed to study the disease for two CENTRIES before succumbing!\r\nTheir treatments will slow the progress of the disease tremendously and save billions of lives.\r\nCongratulations, the mission is a success.  You are a hero.\r\nHumanity learns to manage the disease and eventually after fourteen centuries develops a cure.\r\n\r\nIts origins still remain a mystery.";
                        Game1.Success = true;
                        break;
                }
                FadeMessageManager.Show(message);
            }

            EncounterManager.EncounterActive = false;

            BaseSprite.TintColor = Color.Gray;

            Encounter = false;
        }
        public override string GetAction1Text()
        {
            return "Yes, we need more information.";
        }
        public override string GetAction2Text()
        {
            return "No, shouldn't risk contamination.";
        }
        public override bool IsAction2()
        {
            return true;
        }
    }
}
