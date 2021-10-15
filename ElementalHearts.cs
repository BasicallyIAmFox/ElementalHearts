using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts
{
	public class ElementalHearts : Mod
    {
        public static ElementalHearts Instance;

        public ElementalHearts()
        {
            Instance = this;
        }

        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> screenRef = new();
                Filters.Scene["TeleportShockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["TeleportShockwave"].Load();
                Filters.Scene["PhaseChangeShockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["PhaseChangeShockwave"].Load();
                Filters.Scene["BasicShockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["BasicShockwave"].Load();
            }
        }
    }
}