﻿using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ElementalHearts
{
    [Label("Settings")]
    public class ElementalHeartsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Elemental Hearts Setting")]
        [DefaultValue(1)]
        [ReloadRequired]
        [Label("Max Heart Consumption (recommended to keep at 1)")]
        public int MaxElementalHeartConfig;
    }
}
