using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace LD19
{
    public static class SoundManager
    {
        public static SoundEffect CivAlert;

        public static void Initialize(ContentManager content)
        {
            CivAlert = content.Load<SoundEffect>(@"Alerts\CivAlert");
        }
    }
}
