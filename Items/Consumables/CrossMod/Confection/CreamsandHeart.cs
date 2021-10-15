using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class CreamsandHeart : BaseHeart
    {
        public CreamsandHeart() : base((int)UniqueIDs.Creamsand, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("Creamsand").Type, TileID.Hellforge);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
