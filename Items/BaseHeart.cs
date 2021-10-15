using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ElementalHearts.Items
{
    public abstract class BaseHeart : ModItem
    {
        protected int id;
        protected int giveHealthAmount;
        protected int rarity;
        protected int value;

        public virtual bool Expert => false;
        public virtual bool Master => false;
        public virtual string RequiredModToLoad => null;

        protected BaseHeart(int id, int giveHealthAmount, int? rarityReplaceWith = null, int value = 0)
        {
            this.id = id;
            this.giveHealthAmount = giveHealthAmount;
            if (rarityReplaceWith != null)
            {
                rarity = (int)rarityReplaceWith;
            }
            else
            {
                rarity = giveHealthAmount - 1;
            }
            this.value = value;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (RequiredModToLoad == null)
            {
                return true;
            }
            else
            {
                if (ModLoader.TryGetMod(RequiredModToLoad, out Mod result))
                {
                    return true;
                }
                return false;
            }
        }

        public sealed override string Texture
        {
            get
            {
                if (ModContent.RequestIfExists($"{Mod.Name}/Assets/Hearts/Heart_{id}", out Asset<Texture2D> asset))
                {
                    return $"{Mod.Name}/Assets/Hearts/Heart_{id}";
                }
                return "ElementalHearts/Assets/Hearts/Heart_0";
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(Language.GetTextValue($"Mods.{Mod.Name}.Heart.{id}"));
            Tooltip.SetDefault(Language.GetTextValue($"Mods.{Mod.Name}.PermamentIncrease").Replace("{0}", $"{giveHealthAmount}"));
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.LifeFruit);
            Item.rare = rarity;
            Item.value = value;

            Item.expert = Expert;
            Item.master = Master;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax > 99 && player.GetModPlayer<ElementalHeartsPlayer>().life[id] <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool? UseItem(Player player)
        {
            player.statLifeMax2 += giveHealthAmount;
            player.statLife += giveHealthAmount;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(giveHealthAmount);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().lifeHp[id] = giveHealthAmount;
            player.GetModPlayer<ElementalHeartsPlayer>().life[id] += 1;
            return true;
        }

        public static void SimpleAddRecipe(Mod mod, int type, int ingredient, int? tile = null)
        {
            var recipe = mod.CreateRecipe(type);
            recipe.AddIngredient(ingredient, 100);
            if (tile != null)
            {
                recipe.AddTile((int)tile);
            }
            else
            {
                recipe.AddTile(TileID.WorkBenches);
            }
            recipe.Register();
        }
    }
}
