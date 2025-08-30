using ModLoader;
using UnityEngine;

namespace ScreenshotMod
{
    public class Main : Mod
    {
        public override string ModNameID => "screenshotmod";
        public override string DisplayName => "Screenshot Mod";
        public override string Author => "GT1650CS";
        public override string MinimumGameVersionNecessary => "1.5.10.2";
        public override string ModVersion => "1.0.4";
        public override string Description => "A mod that allows the user to take a screenshot by pressing F10. The resulting screenshot is saved to the user's Pictures/Screenshots/SFS folder.";
        public override string IconLink => "https://raw.githubusercontent.com/GT1650CS/ScreenshotMod/refs/heads/main/Screenshot%20Mod.png";

        public override void Early_Load() {}
        public override void Load()
        {
            // Singleton instance to avoid duplicates
            if (Object.FindObjectOfType<ScreenshotManager>() == null)
            {
                var gameobject = new GameObject(nameof(ScreenshotManager));
                Object.DontDestroyOnLoad(gameobject);
                gameobject.AddComponent<ScreenshotManager>();
            }
        }
    }
}
