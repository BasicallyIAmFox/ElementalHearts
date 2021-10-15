﻿using ElementalHearts.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Pets
{
    public class MenacingHeartPetBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Heart");
            Description.SetDefault("He threatens you with his sweetness!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<ElementalHeartsPlayer>().menacingShard = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<MenacingHeartPet>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y
                    + player.height
                    / 2, 0f, 0f, ModContent.ProjectileType<MenacingHeartPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
