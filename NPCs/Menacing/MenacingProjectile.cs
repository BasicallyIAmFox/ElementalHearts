using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Menacing
{
    public class MenacingProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Projectile");
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.width = 44;
            Projectile.height = 44;
            Projectile.alpha = 0;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 500;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.velocity *= 1.02f;

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