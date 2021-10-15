using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class CreamwoodHeart : BaseHeart
    {
        public CreamwoodHeart() : base((int)UniqueIDs.Creamwood, 5)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("CreamWood").Type);
        }

        public override string RequiredModToLoad => "TheConfectionRebirth";
    }
}
