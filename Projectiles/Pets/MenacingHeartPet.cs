using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts.Projectiles.Pets
{
    public class MenacingHeartPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Heart");
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.netImportant = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            ElementalHeartsPlayer modPlayer = player.GetModPlayer<ElementalHeartsPlayer>();
            Vector2 vectorToPlayer = player.Center - Projectile.Center;
            float distance = vectorToPlayer.Length();
            if (player.dead)
            {
                modPlayer.menacingShard = false;
            }
            if (modPlayer.menacingShard)
            {
                Projectile.timeLeft = 2;
            }

            Projectile.localAI[1] += 1f / 60;
            Projectile.frame = (int)Projectile.localAI[0];
            float timeForTeleport = 10f;
            int distant = 128;
            if (player.statLife > player.statLifeMax2 * 0.75)
            {
                timeForTeleport = 5f;
                distant = 128;
                Projectile.localAI[0] = 0f;
            }
            else if (player.statLife > player.statLifeMax2 * 0.50)
            {
                distant = 96;
                timeForTeleport = 7.5f / 2;
                Projectile.localAI[0] = 1f;
            }
            else if (player.statLife > player.statLifeMax2 * 0.25)
            {
                distant = 64;
                timeForTeleport = 2.5f;
                Projectile.localAI[0] = 2f;
            }
            else if (player.statLife < player.statLifeMax2 * 0.25)
            {
                distant = 32;
                timeForTeleport = 2.5f / 2;
                Projectile.localAI[0] = 3f;
            }
            if (Projectile.localAI[1] > timeForTeleport)
            {
                if (Main.rand.NextBool(4))
                {
                    Projectile.Center = player.Center + new Vector2(0, distant);
                }
                else if (Main.rand.NextBool(4))
                {
                    Projectile.Center = player.Center - new Vector2(0, distant);
                }
                else if (Main.rand.NextBool(4))
                {
                    Projectile.Center = player.Center + new Vector2(distant, 0);
                }
                else
                {
                    Projectile.Center = player.Center - new Vector2(distant, 0);
                }
                Projectile.localAI[1] = 0f;
            }
            if (Projectile.Center.X < player.Center.X)
            {
                Projectile.spriteDirection = 1;
            }
            else
            {
                Projectile.spriteDirection = -1;
            }
        }
    }
}
