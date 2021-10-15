using System.Linq;
using ElementalHearts.Items;
using ElementalHearts.Items.Consumables;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ElementalHearts
{
    public class ElementalHeartsNPC : GlobalNPC
    {
        public static int menacingHeart = -1;

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            Player closestPlayer = Main.player[Player.FindClosest(npc.position, npc.width, npc.height)];
            if (npc.type == NPCID.ChaosElemental)
            {
                npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<HeartofDiscord>(), closestPlayer.RollLuck(500), closestPlayer.RollLuck(400)));
            }
            
            if (ModLoader.TryGetMod("TheConfectionRebirth", out Mod result))
            {
                if (npc.type == result.Find<ModNPC>("Iscreamer").Type)
                {
                    npcLoot.Add(ItemDropRule.NormalvsExpert(ModContent.ItemType<DimensionalHeart>(), closestPlayer.RollLuck(500), closestPlayer.RollLuck(400)));
                }
            }

            #region Bosses
            #region Vanilla
            if (npc.type == NPCID.KingSlime)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<RoyalSlimeHeart>()));
            }
            else if (npc.type == NPCID.EyeofCthulhu)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<EyeHeart>()));
            }
            else if (npc.type == NPCID.EaterofWorldsHead)
            {
                npcLoot.Add(ItemDropRule.BossBagByCondition(new EoWHeadLast(), ModContent.ItemType<WormHeart>()));
            }
            else if (npc.type == NPCID.EaterofWorldsBody)
            {
                npcLoot.Add(ItemDropRule.BossBagByCondition(new EoWBodyLast(), ModContent.ItemType<WormHeart>()));
            }
            else if (npc.type == NPCID.EaterofWorldsTail)
            {
                npcLoot.Add(ItemDropRule.BossBagByCondition(new EoWTailLast(), ModContent.ItemType<WormHeart>()));
            }
            else if (npc.type == NPCID.BrainofCthulhu)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<BrainHeart>()));
            }
            else if (npc.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<LarvaoftheHives>()));
            }
            else if (npc.type == NPCID.SkeletronHead)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<BoneHeart>()));
            }
            else if (npc.type == ModContent.NPCType<NPCs.Menacing.MenacingHeart>())
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Items.Consumables.MenacingHeart>()));
            }
            else if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<DemonHeartMK2>()));
            }
            else if (npc.type == NPCID.Spazmatism)
            {
                npcLoot.Add(ItemDropRule.BossBagByCondition(new NoRetinazerAndExpert(), ModContent.ItemType<MechanicalCrystalPiece1>()));
            }
            else if (npc.type == NPCID.Retinazer)
            {
                npcLoot.Add(ItemDropRule.BossBagByCondition(new NoSpazmatismAndExpert(), ModContent.ItemType<MechanicalCrystalPiece1>()));
            }
            else if (npc.type == NPCID.SkeletronPrime)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<MechanicalCrystalPiece3>()));
            }
            else if (npc.type == NPCID.TheDestroyer)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<MechanicalCrystalPiece2>()));
            }
            else if (npc.type == NPCID.QueenSlimeBoss)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<VolatileHeart>()));
            }
            else if (npc.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<BulbHeart>()));
            }
            else if (npc.type == NPCID.HallowBoss)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<SoaringHeart>()));
            }
            else if (npc.type == NPCID.Golem)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<LihzhardianHeart>()));
            }
            else if (npc.type == NPCID.DukeFishron)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<TruffleHeart>()));
            }
            else if (npc.type == NPCID.CultistBoss)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<AncientHeart>()));
            }
            else if (npc.type == NPCID.MoonLordCore)
            {
                npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<CelestialHeart>()));
            }
            #endregion

            #region Qwerty Mod
            if (ModLoader.TryGetMod("QwertyMod", out Mod result2))
            {
                if (npc.type == result2.Find<ModNPC>("PolarBear").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<PenguinHeart>()));
                }
                else if (npc.type == result2.Find<ModNPC>("FortressBoss").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<DivineHeart>()));
                }
                else if (npc.type == result2.Find<ModNPC>("AncientMachine").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Ancient2Heart>()));
                }
                else if (npc.type == result2.Find<ModNPC>("CloakedDarkBoss").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<Doppleheart>()));
                }
                else if (npc.type == result2.Find<ModNPC>("Hydra").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<HydraHeart>()));
                }
                else if (npc.type == result2.Find<ModNPC>("Imperious").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<BladedHeart>()));
                }
                else if (npc.type == result2.Find<ModNPC>("RuneGhost").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<HyperRunestoneHeart>()));
                }
                else if (npc.type == result2.Find<ModNPC>("OLORDv2").Type)
                {
                    npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<DevouringHeart>()));
                }
            }
            #endregion
            #endregion
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<HeartEmptier>());
                nextSlot++;
            }
            else if (type == NPCID.PartyGirl)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BubbleHeart>());
                nextSlot++;
            }
            else if (type == NPCID.Steampunker)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<CogHeart>());
                nextSlot++;
            }
        }

        public class EoWHeadLast : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.CountNPCS(NPCID.EaterofWorldsHead) == 1 && NPC.CountNPCS(NPCID.EaterofWorldsBody) == 0 && NPC.CountNPCS(NPCID.EaterofWorldsTail) == 0 && Main.expertMode;

            public bool CanShowItemDropInUI() => Main.expertMode;

            public string GetConditionDescription() => Main.masterMode ? Language.GetTextValue("Bestiary_ItemDropConditions.IsMasterMode") : Language.GetTextValue("Bestiary_ItemDropConditions.IsExpert");
        }
        public class EoWBodyLast : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.CountNPCS(NPCID.EaterofWorldsHead) == 0 && NPC.CountNPCS(NPCID.EaterofWorldsBody) == 1 && NPC.CountNPCS(NPCID.EaterofWorldsTail) == 0 && Main.expertMode;

            public bool CanShowItemDropInUI() => Main.expertMode;

            public string GetConditionDescription() => Main.masterMode ? Language.GetTextValue("Bestiary_ItemDropConditions.IsMasterMode") : Language.GetTextValue("Bestiary_ItemDropConditions.IsExpert");
        }
        public class EoWTailLast : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.CountNPCS(NPCID.EaterofWorldsHead) == 0 && NPC.CountNPCS(NPCID.EaterofWorldsBody) == 0 && NPC.CountNPCS(NPCID.EaterofWorldsTail) == 1 && Main.expertMode;

            public bool CanShowItemDropInUI() => Main.expertMode;

            public string GetConditionDescription() => Main.masterMode ? Language.GetTextValue("Bestiary_ItemDropConditions.IsMasterMode") : Language.GetTextValue("Bestiary_ItemDropConditions.IsExpert");
        }
        public class NoRetinazerAndExpert : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.CountNPCS(NPCID.Retinazer) == 0 && Main.expertMode;

            public bool CanShowItemDropInUI() => Main.expertMode;

            public string GetConditionDescription() => Main.masterMode ? Language.GetTextValue("Bestiary_ItemDropConditions.IsMasterMode") : Language.GetTextValue("Bestiary_ItemDropConditions.IsExpert");
        }
        public class NoSpazmatismAndExpert : IItemDropRuleCondition, IProvideItemConditionDescription
        {
            public bool CanDrop(DropAttemptInfo info) => NPC.CountNPCS(NPCID.Spazmatism) == 0 && Main.expertMode;

            public bool CanShowItemDropInUI() => Main.expertMode;

            public string GetConditionDescription() => Main.masterMode ? Language.GetTextValue("Bestiary_ItemDropConditions.IsMasterMode") : Language.GetTextValue("Bestiary_ItemDropConditions.IsExpert");
        }
    }
}
