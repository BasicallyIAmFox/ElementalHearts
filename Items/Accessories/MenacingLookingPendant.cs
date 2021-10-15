using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Accessories
{
    public class MenacingLookingPendant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Looking Pendant");
            Tooltip.SetDefault("Increases life regen by 5\nIncreases HP by 5%");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.PanicNecklace);
            Item.rare = ItemRarityID.Expert;
            Item.expert = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 5;
            player.statLifeMax2 = (int)(player.statLifeMax2 * 1.05f);
        }
    }
}
