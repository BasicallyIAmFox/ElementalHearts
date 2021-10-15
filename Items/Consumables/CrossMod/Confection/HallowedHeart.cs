using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class HallowedHeart : BaseHeart
    {
        public HallowedHeart() : base((int)UniqueIDs.Hallowed, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("HallowedOre").Type, TileID.MythrilAnvil);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
