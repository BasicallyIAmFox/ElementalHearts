using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Projectiles.Friendly
{
    public class SeekingFriendlyMenacingProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.scale = .5f;
        }

        public override void AI()
        {


            Vector2 move = Vector2.Zero;
            float distance = 400f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - Projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
                AdjustMagnitude(ref Projectile.velocity);
            }

            //Gravity         
            Projectile.velocity.Y += Projectile.ai[0];

            //Face Toward Velocity
            Projectile.rotation = Projectile.velocity.ToRotation();
            //^Not Not Enabled Because It Does Not Work

            //Acceleration Effect
            Projectile.velocity *= 1.003f;

            //Dust
            if (Main.rand.NextBool(2))
            {
                if (Main.rand.NextBool(2))
                {
                    int dust1 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Blood, Projectile.velocity.X, Projectile.velocity.Y, 0, Main.DiscoColor, 1);
                    Main.dust[dust1].velocity /= 2f;
                }
                if (Main.rand.NextBool(2))
                {
                    int dust2 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Blood, Projectile.velocity.X, Projectile.velocity.Y, 0, Color.Black, 1);
                    Main.dust[dust2].velocity /= 2f;

                }
                if (Main.rand.NextBool(2))
                {
                    int dust3 = Dust.NewDust(Projectile.Center, 1, 1, DustID.Blood, Projectile.velocity.X, Projectile.velocity.Y, 0, Color.White, 1);
                    Main.dust[dust3].velocity /= 2f;
                }
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.ai[0] += 0.1f;
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                Projectile.velocity *= 0.69f;
                SoundEngine.PlaySound(SoundID.Item35, Projectile.position);
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(Projectile.Center + Projectile.velocity, 1, 1, DustID.Blood, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
            SoundEngine.PlaySound(SoundID.Item25, Projectile.position);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.type != NPCID.TargetDummy)
            {
                int healAmount = damage / (10 + (int)Main.rand.NextFloat(4));
                healAmount /= 1 + (int)Main.rand.NextFloat(4);
                Main.player[Projectile.owner].HealEffect(healAmount, true);
                Main.player[Projectile.owner].statLife += healAmount;
                Projectile.Kill();
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Main.DiscoColor;
        }
    }
}