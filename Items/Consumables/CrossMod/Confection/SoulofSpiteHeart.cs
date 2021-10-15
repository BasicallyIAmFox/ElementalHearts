using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class SoulofSpiteHeart : BaseHeart
    {
        public SoulofSpiteHeart() : base((int)UniqueIDs.SoulofSpite, 4, ItemRarityID.Pink)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("SoulofSpite").Type, TileID.CrystalBall);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
