using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHearts
{
    public class ElementalHeartsPlayer : ModPlayer
    {
        public int[] life = new int[(int)UniqueIDs.Count];
        public int[] lifeHp = new int[(int)UniqueIDs.Count];
        public bool menacingShard;

        public override void ResetEffects()
        {
            for (int i = 0; i < (int)UniqueIDs.Count; i++)
            {
                Player.statLifeMax2 += life[i] * lifeHp[i];
            }
            menacingShard = false;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)Player.whoAmI);
            for (int i = 0; i < (int)UniqueIDs.Count; i++)
            {
                packet.Write(life[i]);
                packet.Write(lifeHp[i]);
            }
            packet.Send(toWho, fromWho);
        }

        public override void SaveData(TagCompound tag)
        {
            for (int i = 0; i < (int)UniqueIDs.Count; i++)
            {
                tag[$"heart{i}"] = life[i];
                tag[$"hp{i}"] = lifeHp[i];
            }
        }

        public override void LoadData(TagCompound tag)
        {
            for (int i = 0; i < (int)UniqueIDs.Count; i++)
            {
                life[i] = (int)tag[$"heart{i}"];
                lifeHp[i] = (int)tag[$"hp{i}"];
            }
        }
    }
}
