using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class PinkFairyFlossHeart : BaseHeart
    {
        public PinkFairyFlossHeart() : base((int)UniqueIDs.PinkFairyFloss, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("PinkFairyFloss").Type, TileID.SkyMill);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
