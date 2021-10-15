using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class EctoplasmHeart : BaseHeart
    {
        public EctoplasmHeart() : base((int)UniqueIDs.Ectoplasm, 8)
        {
        }

        public override void AddRecipes()
        {
            SimpleAddRecipe(Mod, Type, ItemID.Ectoplasm, TileID.BoneWelder);
        }
    }
}
