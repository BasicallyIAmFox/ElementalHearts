using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class FossilHeart : BaseHeart
    {
        public FossilHeart() : base((int)UniqueIDs.Fossil, 2)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.DesertFossil, TileID.Extractinator);
        }
    }
}
