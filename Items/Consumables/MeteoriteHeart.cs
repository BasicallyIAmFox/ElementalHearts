using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class MeteoriteHeart : BaseHeart
    {
        public MeteoriteHeart() : base((int)UniqueIDs.Meteorite, 4)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Meteorite, TileID.Furnaces);
        }
    }
}
