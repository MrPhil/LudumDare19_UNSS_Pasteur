using Microsoft.Xna.Framework;

namespace LD19
{
    public class EmptyStar : StarTile
    {
        public EmptyStar(Vector2 worldLocation)
            : base(worldLocation)
        {
        }

        public override string GetEncounterText()
        {
            return "You discover nothing of interest";
        }

        public override void EncounterResult(bool action1Selected)
        {
            EncounterManager.EncounterActive = false;

            LongRangeScanned = true;
            
            BaseSprite.TintColor = Color.Gray;

            Encounter = false;
        }
        public override string GetAction1Text()
        {
            return "Oh, well let's get going then.";
        }
        public override string GetAction2Text()
        {
            return "";
        }
        public override bool IsAction2()
        {
            return false;
        }
    }
}
