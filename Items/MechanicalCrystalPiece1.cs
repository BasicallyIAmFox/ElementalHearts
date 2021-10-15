using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace ElementalHearts.Items
{
    public class MechanicalCrystalPiece1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Crystal Fuel Tank");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.rare = -12;
            Item.value = 5000;
            Item.expert = true;
        }
    }
}
