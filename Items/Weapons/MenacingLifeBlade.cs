using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Weapons
{
    class MenacingLifeBlade : ModItem
    {
        public bool speedEffect;
        public float speedValue;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sharp sword forged out of ancient life quartz.\nThe blade sucks life from anything it touches.");
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.width = 46;
            Item.crit = 12;
            Item.height = 50;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 8;
            Item.value = 6775;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.useTurn = true;
            //item.shoot = ProjectileType<FriendlyMenacingProjectile>();
            //item.shootSpeed = 6f;
            Item.autoReuse = true;

            speedEffect = true;
            speedValue = 0;
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
            if (Item.useTime >= 36)
            {
                speedEffect = true;
            }
            else if (Item.useTime <= 18)
            {
                speedEffect = false;
            }

            if (speedEffect)
            {
                speedValue += 0.25f;
            }
            else if (!speedEffect)
            {
                speedValue -= 0.25f;
            }

            if (speedValue >= 1)
            {
                Item.useTime -= 1;
                Item.useAnimation -= 1;
                speedValue = 0;
            }
            else if (speedValue <= -1)
            {
                Item.useTime += 1;
                Item.useAnimation += 1;
                speedValue = 0;
            }

            base.HoldItem(player);
        }

        //Heal Player On Hit
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.type != NPCID.TargetDummy)
            {
                int healAmount = damage / (10 + (int)Main.rand.NextFloat(4));
                healAmount /= 1 + (int)Main.rand.NextFloat(4);
                player.HealEffect(healAmount, true);
                player.statLife += healAmount;
                SoundEngine.PlaySound(SoundID.Item35, target.position);
            }
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
    }
}
