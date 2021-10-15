using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class BlueFairyFlossHeart : BaseHeart
    {
        public BlueFairyFlossHeart() : base((int)UniqueIDs.BlueFairyFloss, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("BlueFairyFloss").Type, TileID.SkyMill);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
