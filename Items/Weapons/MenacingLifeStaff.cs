using ElementalHearts.Projectiles.Friendly;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Weapons
{
    class MenacingLifeStaff : ModItem
    {
        public bool speedEffect;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A mystic staff forged out of ancient life quartz.\nCasts heart shaped projectiles that suck life from anything it touches.");
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.crit = 12;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 8;
            Item.value = 6775;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item9;
            Item.shoot = ProjectileType<FriendlyMenacingProjectile>();
            Item.shootSpeed = 6f;
            Item.autoReuse = true;

            speedEffect = true;
        }

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Dust.NewDust(position, 16, 16, 112, 0, 0, 0, Main.DiscoColor, 2);
            Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
            Dust.NewDust(position, 8, 8, 2, 0, 0, 0, Main.DiscoColor, 2);
            Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
            Dust.NewDust(position, 8, 8, 2, 0, 0, 0, Main.DiscoColor, 2);
            Dust.NewDust(position, 8, 8, 1, 0, 0, 0, Main.DiscoColor, 1);
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void HoldItem(Player player)
        {
            if (Item.shootSpeed > 12)
            {
                speedEffect = false;
            }
            else
            if (Item.shootSpeed < 6)
            {
                speedEffect = true;
            }

            if (speedEffect)
            {
                Item.shootSpeed += 0.1f;
            }
            else
            {
                Item.shootSpeed -= 0.1f;
            }
            base.HoldItem(player);
        }
    }
}
