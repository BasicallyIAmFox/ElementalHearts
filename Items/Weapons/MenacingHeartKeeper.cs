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
    class MenacingHeartKeeper : ModItem
    {
        public int shootCountInt;
        public bool speedEffect;
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A mystic bow forged out of ancient life quartz.\nSeeking heart shaped projectiles, which accompany arrows, suck life from anything it touches.");
            //Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Ranged;
            Item.crit = 12;
            Item.width = 26;
            Item.height = 36;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 8;
            Item.value = 6775;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item5;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Arrow;
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

            if (shootCountInt == 1)
            {
                Projectile.NewProjectile(source, position, velocity, ProjectileType<SeekingFriendlyMenacingProjectile>(), damage, knockback, Main.myPlayer);
                shootCountInt = 0;
            }
            else
            {
                if (shootCountInt == 0)
                {
                    shootCountInt = 1;
                }
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void HoldItem(Player player)
        {
            if (Item.shootSpeed > 12)
            {
                speedEffect = false;
            }
            else if (Item.shootSpeed < 6)
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
        }
    }
}
