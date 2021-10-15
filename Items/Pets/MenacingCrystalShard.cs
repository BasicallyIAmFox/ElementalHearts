using ElementalHearts.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Pets
{
    public class MenacingCrystalShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Crystal Shard");
            Tooltip.SetDefault("Summons a Baby Heart\n'It stares at you menacingly'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<MenacingHeartPet>();
            Item.buffType = ModContent.BuffType<MenacingHeartPetBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }

    }
}
