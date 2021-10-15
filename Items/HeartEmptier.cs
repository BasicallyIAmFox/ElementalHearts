using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ElementalHearts.Items
{
    public class HeartEmptier : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently Resets All Elemental Heart Stats.\nBe careful with this, it can remove a lot of progress!");
            DisplayName.SetDefault("Heart Emptier");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 1);
        }

        public override bool? UseItem(Player player)
        {
            CombatText.NewText(player.getRect(), Color.Orange, Language.GetTextValue("Mods.ElementalHearts.HeartEmptierUsed"));
            for (int i = 0; i < (int)UniqueIDs.Count; i++)
            {
                player.GetModPlayer<ElementalHeartsPlayer>().life[i] = 0;
            }
            player.statLifeMax2 = 0;
            return true;
        }
    }
}
