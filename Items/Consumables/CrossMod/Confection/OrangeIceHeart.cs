using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class OrangeIceHeart : BaseHeart
    {
        public OrangeIceHeart() : base((int)UniqueIDs.OrangeIce, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("OrangeIce").Type, TileID.IceMachine);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
