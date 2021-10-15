using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class PurpleFairyFlossHeart : BaseHeart
    {
        public PurpleFairyFlossHeart() : base((int)UniqueIDs.PurpleFairyFloss, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("PurpleFairyFloss").Type, TileID.SkyMill);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
