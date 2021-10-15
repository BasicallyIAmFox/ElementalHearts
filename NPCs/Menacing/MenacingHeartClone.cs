using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Menacing
{
    public class MenacingHeartClone : ModNPC
    {
        public float cloneTimeLeft;

        public override string Texture => base.Texture.Replace("Clone", "");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Heart");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[ModContent.NPCType<MenacingHeart>()];
        }

        public override void SetDefaults()
        {
            NPC.aiStyle = 0;
            NPC.alpha = 128;
            NPC.width = 0;
            NPC.height = 0;
            NPC.defense = -10;
            NPC.lifeMax = 10;
            NPC.HitSound = SoundID.Item35;
            NPC.DeathSound = SoundID.Item25;
            NPC.value = 10000;
            NPC.buffImmune[BuffID.Confused] = true;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.dontTakeDamage = true;

            cloneTimeLeft = 420;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return base.DrawHealthBar(hbPosition, ref scale, ref position);
        }

        public override void AI()
        {
            NPC.frame = Main.npc[ElementalHeartsNPC.menacingHeart].frame;

            Lighting.AddLight(NPC.Center, new Vector3(1, 0, 0));

            NPC.alpha = (int)(255 - (cloneTimeLeft));
            if (cloneTimeLeft < 0)
            {
                NPC.active = false;
            }
            else
            {
                cloneTimeLeft -= 5;
            }
        }
    }
}