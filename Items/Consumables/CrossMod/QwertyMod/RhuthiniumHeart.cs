using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class RhuthiniumHeart : BaseHeart
    {
        public RhuthiniumHeart() : base((int)UniqueIDs.Rhuthinium, 4)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("RhuthiniumOre").Type);
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
