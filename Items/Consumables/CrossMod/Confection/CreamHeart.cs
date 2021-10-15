using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class CreamHeart : BaseHeart
    {
        public CreamHeart() : base((int)UniqueIDs.Cream, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("CreamBlock").Type, TileID.Hellforge);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
