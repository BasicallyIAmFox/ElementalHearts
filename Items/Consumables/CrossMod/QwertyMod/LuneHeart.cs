using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    public class LuneHeart : BaseHeart
    {
        public LuneHeart() : base((int)UniqueIDs.Lune, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ModLoader.GetMod(RequiredModToLoad).Find<ModItem>("LuneOre").Type);
        }

        public override string RequiredModToLoad => "QwertyMod";
    }
}
