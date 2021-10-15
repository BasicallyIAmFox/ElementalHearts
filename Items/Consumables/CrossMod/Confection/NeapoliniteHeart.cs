using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class NeapoliniteHeart : BaseHeart
    {
        public NeapoliniteHeart() : base((int)UniqueIDs.Neapolinite, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("NeapoliniteOre").Type, TileID.MythrilAnvil);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
