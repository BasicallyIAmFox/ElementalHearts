using Terraria;
using Terraria.ID;

namespace ElementalHearts.Items.Consumables
{
    public class BubbleHeart : BaseHeart
    {
        public BubbleHeart() : base((int)UniqueIDs.Bubble, 1, ItemRarityID.Blue, Item.buyPrice(gold: 2))
        {
        }
    }
}
