using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Menacing
{
    public class SmallMenacingProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Projectiles");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Fireball);
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.scale = 1.5f;
            Projectile.timeLeft = 200;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            Projectile.velocity.Y += Main.expertMode ? 0.015f : 0.01f;

            Projectile.rotation = Projectile.velocity.ToRotation();

            int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood, Projectile.velocity.X, Projectile.velocity.Y, 0, Main.DiscoColor, 1);
            int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood, Projectile.velocity.X, Projectile.velocity.Y, 0, Color.Black, 1);
            int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Blood, Projectile.velocity.X, Projectile.velocity.Y, 0, Color.White, 1);
            Main.dust[dust1].velocity /= 2f;
            Main.dust[dust2].velocity /= 2f;
            Main.dust[dust3].velocity /= 2f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Main.DiscoColor;
        }
    }
}