using System;
using System.Collections.Generic;
using System.IO;
using ElementalHearts.Items;
using ElementalHearts.Items.Pets;
using ElementalHearts.Items.Placeables;
using ElementalHearts.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Filters = Terraria.Graphics.Effects.Filters;

namespace ElementalHearts.NPCs.Menacing
{
    [AutoloadBossHead]
    public class MenacingHeart : ModNPC
    {
        public float bossPhaseHealth;

        public float timeLeftTillDespawn;

        public float P1;
        public float P2;
        public float P3;
        public float P4;

        public bool P1P;
        public bool P2P;
        public bool P3P;
        public bool P4P;

        public bool BP1;
        public bool BP2;
        public bool BP3;
        public bool BP4;

        public bool bossLeaveBool;

        public Vector2 futurePosition;
        public Vector2 clonePosition;

        public float tpPosRand1;
        public float tpPosRand2;
        public float tpPosRand3;
        public float tpPosRand4;

        public Vector2 moveDirectionVelocity;

        public bool Spawn = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Heart");
            Main.npcFrameCount[NPC.type] = 14;

            //ElementalHeartsNPC.AddDebuffImmunity(Type, new int[] { BuffID.Confused });

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new(0)
            {
                PortraitPositionYOverride = -0.02f,
                Scale = 0.4f,
                Frame = 2
            };
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        public override void SetDefaults()
        {
            NPC.SpawnWithHigherTime(30);
            NPC.aiStyle = 0;
            NPC.width = 128;
            NPC.height = 128;
            NPC.damage = 69;
            NPC.defense = 13;
            NPC.lifeMax = 9000;
            NPC.HitSound = SoundID.Item35;
            NPC.DeathSound = SoundID.Item25;
            NPC.value = 50000;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.npcSlots = 10f;
            NPC.boss = true;
            NPC.netAlways = true;
            NPC.timeLeft = 0;

            if (Main.expertMode)
            {
                bossPhaseHealth = NPC.lifeMax * 2 / 4;
            }
            else if (!Main.expertMode)
            {
                bossPhaseHealth = NPC.lifeMax / 4;
            }
            BossBag = ItemType<MenacingHeartBag>();

            if (!Main.dedServ)
            {
                //Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/MenacingHeartBossMusic");
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement>
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("The most ancient living creature made out of crystals was defeated by you."),
            });
        }

        public static int[] headSlots = new int[4];
        public override void Load()
        {
            headSlots[0] = Mod.AddBossHeadTexture($"{BossHeadTexture}", -1);
            headSlots[1] = Mod.AddBossHeadTexture($"{BossHeadTexture}2", -1);
            headSlots[2] = Mod.AddBossHeadTexture($"{BossHeadTexture}3", -1);
            headSlots[3] = Mod.AddBossHeadTexture($"{BossHeadTexture}4", -1);
        }

        public override void BossHeadSlot(ref int index)
        {
            if (BP1)
            {
                index = headSlots[0];
            }
            else if (BP2)
            {
                index = headSlots[1];
            }
            else if (BP3)
            {
                index = headSlots[2];
            }
            else if (BP4)
            {
                index = headSlots[3];
            }
        }

        public override void UpdateLifeRegen(ref int damage)
        {
            if (BP1)
            {
                NPC.lifeRegen = 50 / 5;

            }
            else if (BP2)
            {
                NPC.lifeRegen = 125 / 6;

            }
            else if (BP3)
            {
                NPC.lifeRegen = 250 / 7;

            }
            else if (BP4)
            {
                NPC.lifeRegen = 500 / 8;

            }
            base.UpdateLifeRegen(ref damage);
        }
        public override void DrawEffects(ref Color drawColor)
        {
            if (BP4)
            {
                drawColor = new Color(Main.DiscoR * 0.4f, Main.DiscoG * 0.4f, Main.DiscoB * 0.4f, 255);
            }
            base.DrawEffects(ref drawColor);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.75f;
            return null;
        }

        public void ProjectilesLeft()
        {
            //Facing Left Projectiles
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 20 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 20 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 20 * 2, 1f, Main.myPlayer);
        }

        public void ProjectilesRight()
        {
            //Facing Right Projectiles
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 20 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 20 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 20 * 2, 1f, Main.myPlayer);
        }

        public void ProjectilesUp()
        {
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 30 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 30 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 30 * 2, 1f, Main.myPlayer);
        }

        public void ProjectilesDown()
        {
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 30 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 30 * 2, 1f, Main.myPlayer);
            Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 30 * 2, 1f, Main.myPlayer);
        }

        public void RandomMoveBoss()
        {
            moveDirectionVelocity = new Vector2(Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f));
            moveDirectionVelocity.Normalize();
            moveDirectionVelocity += new Vector2(Main.rand.NextFloat(.25f, .5f), Main.rand.NextFloat(.25f, .5f));
            moveDirectionVelocity += new Vector2(Main.rand.NextFloat(-.25f, -.5f), Main.rand.NextFloat(-.25f, -.5f));
            moveDirectionVelocity *= Main.rand.NextFloat(2f, 4f);

            if (Math.Abs((int)moveDirectionVelocity.LengthSquared()) <= 6)
            {
                if (Main.rand.Next(4) > 0)
                {
                }
                else
                {
                    moveDirectionVelocity *= Main.rand.NextFloat(2f, 4f);
                }
            }
        }

        public override void AI()
        {
            ElementalHeartsNPC.menacingHeart = NPC.whoAmI;
            Lighting.AddLight(NPC.Center, new Vector3(1, 0, 0));

            if (Spawn != true)
            {
                if (Main.netMode != NetmodeID.Server && !Filters.Scene["BasicShockwave"].IsActive())
                {
                    //Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 0), ProjectileType<ShockwaveBasic>(), 0, 0f, Main.myPlayer);
                }
                Spawn = true;


            }

            if (!AnyPlayerAlive)
            {
                NPC.color = Color.Gray;

                if (bossLeaveBool == false)
                {
                    NPC.velocity = new Vector2(0, -0.5f);
                    bossLeaveBool = true;
                }
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Sandstorm, 0, 5, 0, Main.DiscoColor, 2);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Sandstorm, 0, 5, 0, Color.Red, 1);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Sandstorm, 0, 5, 0, Color.Black, 1);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Sandstorm, 0, 5, 0, Color.White, 1);

                NPC.velocity *= 1.04f;

                if (timeLeftTillDespawn > 30)
                {
                    NPC.active = false;
                }
                else
                {
                    timeLeftTillDespawn += .1f;
                }
            }
            else
            {
                NPC.velocity = moveDirectionVelocity;

                moveDirectionVelocity.X -= moveDirectionVelocity.X * (0.00314159265359f * Main.rand.NextFloat(5f, 10f));
                moveDirectionVelocity.Y -= moveDirectionVelocity.Y * (0.00314159265359f * Main.rand.NextFloat(5f, 10f));

                if (NPC.life > bossPhaseHealth * 3)
                {
                    NPC.ai[0] = 1;
                    BP1 = true;
                    BP2 = false;
                    BP3 = false;
                    BP4 = false;

                    NPC.scale = 0.8f;
                    NPC.width = 103;
                    NPC.height = 103;

                    if (Main.netMode != NetmodeID.MultiplayerClient && P1P == false)
                    {
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        SoundEngine.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), NPC.Center);
                        if (Main.netMode != NetmodeID.Server && !Filters.Scene["PhaseChangeShockwave"].IsActive())
                        {
                            //Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 0), ProjectileType<PhaseChangeShockwave>(), 0, 0f, Main.myPlayer);
                        }
                        P1P = true;
                    }
                }
                else if (NPC.life > bossPhaseHealth * 2)
                {
                    NPC.ai[0] = 2;
                    BP1 = false;
                    BP2 = true;
                    BP3 = false;
                    BP4 = false;

                    NPC.scale = 1f;
                    NPC.width = 128;
                    NPC.height = 128;

                    if (Main.netMode != NetmodeID.MultiplayerClient && P2P == false)
                    {
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        SoundEngine.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), NPC.Center);
                        if (Main.netMode != NetmodeID.Server && !Filters.Scene["PhaseChangeShockwave"].IsActive())
                        {
                            //Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 0), ProjectileType<PhaseChangeShockwave>(), 0, 0f, Main.myPlayer);
                        }
                        P2P = true;
                    }
                }
                else if (NPC.life > bossPhaseHealth * 1)
                {
                    NPC.ai[0] = 3;
                    BP1 = false;
                    BP2 = false;
                    BP3 = true;
                    BP4 = false;

                    NPC.scale = 1.2f;
                    NPC.width = 154;
                    NPC.height = 154;

                    if (Main.netMode != NetmodeID.MultiplayerClient && P3P == false)
                    {
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        SoundEngine.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), NPC.Center);
                        if (Main.netMode != NetmodeID.Server && !Filters.Scene["PhaseChangeShockwave"].IsActive())
                        {
                            //Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 0), ProjectileType<PhaseChangeShockwave>(), 0, 0f, Main.myPlayer);
                        }
                        P3P = true;
                    }
                }
                else if (NPC.life > bossPhaseHealth * 0)
                {
                    NPC.ai[0] = 4;
                    BP1 = false;
                    BP2 = false;
                    BP3 = false;
                    BP4 = true;

                    NPC.scale = 1.4f;
                    NPC.width = 180;
                    NPC.height = 180;

                    if (Main.netMode != NetmodeID.MultiplayerClient && P4P == false)
                    {
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(4, 4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(4, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(4, -4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, -4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-4, -4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-4, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(-4, 4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        SoundEngine.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), NPC.Center);
                        if (Main.netMode != NetmodeID.Server && !Filters.Scene["PhaseChangeShockwave"].IsActive())
                        {
                            //Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 0), ProjectileType<PhaseChangeShockwave>(), 0, 0f, Main.myPlayer);
                        }
                        P4P = true;
                    }
                }

                if (NPC.ai[0] == 1)
                {
                    P1++;
                }
                else if (NPC.ai[0] == 2)
                {
                    P2++;
                }
                else if (NPC.ai[0] == 3)
                {
                    P3++;
                }
                else if (NPC.ai[0] == 4)
                {
                    P4++;
                }

                if (Main.netMode != NetmodeID.MultiplayerClient && P1 == 110)
                {
                    NPC.TargetClosest(true);

                    tpPosRand1 = Main.rand.NextFloat(8);

                    if (tpPosRand1 > 6)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(175, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand1 > 4)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, 175);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand1 > 2)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(-175, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand1 > 0)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, -175);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                }

                if (Main.netMode != NetmodeID.MultiplayerClient && P1 == 210)
                {
                    RandomMoveBoss();

                    NPC.Center = futurePosition;

                    if (tpPosRand1 > 6)
                    {
                        ProjectilesLeft();

                        //Gravity Projectiles
                        if (Main.rand.NextBool(3))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        //Clone 1
                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                        }
                    }
                    else
                    if (tpPosRand1 > 4)
                    {
                        ProjectilesUp();

                        //No Gravity Projectiles

                        //Clone 2
                        if (Main.rand.NextBool(2))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                    }
                    else
                    if (tpPosRand1 > 2)
                    {
                        ProjectilesRight();

                        //Gravity Projectiles
                        if (Main.rand.NextBool(3))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        //Clone 3
                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                        }
                    }
                    else
                    if (tpPosRand1 > 0)
                    {
                        ProjectilesDown();

                        //Gravity Projectiles
                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        //Clone 4
                        if (Main.rand.NextBool(4))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                    }
                    P1 = 0;
                    SpawnHealHearts(4);
                }
                else
            //Phase 2.
            if (Main.netMode != NetmodeID.MultiplayerClient && P2 == 90)
                {
                    NPC.TargetClosest(true);

                    tpPosRand2 = Main.rand.NextFloat(8);

                    if (tpPosRand2 > 6)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(200, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand2 > 4)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, 200);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand2 > 2)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(-200, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand2 > 0)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, -200);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                }

                if (Main.netMode != NetmodeID.MultiplayerClient && P2 == 170)
                {
                    RandomMoveBoss();

                    NPC.Center = futurePosition;

                    if (tpPosRand2 > 6)
                    {
                        ProjectilesLeft();

                        if (Main.rand.NextBool(3))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                        }
                        P2 = 0;
                    }
                    else
                    if (tpPosRand2 > 4)
                    {
                        ProjectilesUp();

                        if (Main.rand.NextBool(2))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                        P2 = 0;
                    }
                    else
                    if (tpPosRand2 > 2)
                    {
                        ProjectilesRight();

                        if (Main.rand.NextBool(3))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                        }
                        P2 = 0;
                    }
                    else
                    if (tpPosRand2 > 0)
                    {
                        ProjectilesDown();

                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(4))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                        P2 = 0;
                    }

                    SpawnHealHearts(4);
                }
                else
            if (Main.netMode != NetmodeID.MultiplayerClient && P3 == 70)
                {
                    NPC.TargetClosest(true);

                    tpPosRand3 = Main.rand.NextFloat(8);

                    if (tpPosRand3 > 6)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(225, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand3 > 4)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, 225);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand3 > 2)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(-225, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand3 > 0)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, -225);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                }

                if (Main.netMode != NetmodeID.MultiplayerClient && P3 == 130)
                {
                    RandomMoveBoss();

                    NPC.Center = futurePosition;

                    if (tpPosRand3 > 6)
                    {
                        ProjectilesLeft();

                        if (Main.rand.NextBool(3))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                        }
                        P3 = 0;
                    }
                    else
                    if (tpPosRand3 > 4)
                    {
                        ProjectilesUp();

                        if (Main.rand.NextBool(2))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                        P3 = 0;
                    }
                    else
                    if (tpPosRand3 > 2)
                    {
                        ProjectilesRight();

                        if (Main.rand.NextBool(3))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                        }
                        P3 = 0;
                    }
                    else
                    if (tpPosRand3 > 0)
                    {
                        ProjectilesDown();

                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(4))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                        P3 = 0;
                    }

                    SpawnHealHearts(4);
                }
                else
            if (Main.netMode != NetmodeID.MultiplayerClient && P4 == 50)
                {
                    NPC.TargetClosest(true);

                    tpPosRand4 = Main.rand.NextFloat(8);

                    if (tpPosRand4 > 6)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(250, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand4 > 4)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, 250);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand4 > 2)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(-250, 0);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                    else if (tpPosRand4 > 0)
                    {
                        clonePosition = Main.player[NPC.target].Center;
                        futurePosition = Main.player[NPC.target].Center + new Vector2(0, -250);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                        Dust.NewDust(futurePosition, 16, 16, DustID.Pixie, 0, 0, 0, Main.DiscoColor, 3);
                    }
                }

                if (Main.netMode != NetmodeID.MultiplayerClient && P4 == 125)
                {
                    RandomMoveBoss();

                    NPC.Center = futurePosition;

                    if (tpPosRand4 > 6)
                    {
                        ProjectilesLeft();

                        if (Main.rand.NextBool(4))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                        }
                        P4 = 0;

                    }
                    else
                    if (tpPosRand4 > 4)
                    {
                        ProjectilesUp();

                        if (Main.rand.NextBool(2))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                        P4 = 0;
                    }
                    else
                    if (tpPosRand4 > 2)
                    {
                        ProjectilesRight();

                        if (Main.rand.NextBool(4))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(3))
                        {
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, -50 + (int)clonePosition.Y + -175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                        }
                        P4 = 0;
                    }
                    else
                    if (tpPosRand4 > 0)
                    {
                        ProjectilesDown();

                        if (Main.rand.NextBool(3))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }

                        if (Main.rand.NextBool(4))
                        {
                            NPC.NewNPC(0 + (int)clonePosition.X + 0, 50 + (int)clonePosition.Y + 175, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(-50 + (int)clonePosition.X + -175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                            NPC.NewNPC(50 + (int)clonePosition.X + 175, 0 + (int)clonePosition.Y + 0, NPCType<MenacingHeartClone>());
                        }
                        P4 = 0;
                    }
                    SpawnHealHearts(4);
                }
            }
            base.AI();
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, NPC.velocity.X, NPC.velocity.Y, 0, Color.DarkRed, 2);
            base.HitEffect(hitDirection, damage);
        }

        private const int Frame_P1 = 0;
        private const int Frame_P2 = 1;
        private const int Frame_P3 = 2;

        private const int Frame_P4_1 = 3;
        private const int Frame_P4_2 = 4;
        private const int Frame_P4_3 = 5;
        private const int Frame_P4_4 = 6;
        private const int Frame_P4_5 = 7;
        private const int Frame_P4_6 = 8;
        private const int Frame_P4_7 = 9;
        private const int Frame_P4_8 = 10;
        private const int Frame_P4_9 = 11;
        private const int Frame_P4_10 = 12;
        private const int Frame_P4_11 = 13;
        public override void FindFrame(int frameHeight)
        {
            if (BP1 == true)
            {
                NPC.frame.Y = Frame_P1 * frameHeight;
            }
            else if (BP2 == true)
            {
                NPC.frame.Y = Frame_P2 * frameHeight;
            }
            else if (BP3 == true)
            {
                NPC.frame.Y = Frame_P3 * frameHeight;
            }
            else if (BP4 == true)
            {
                NPC.frameCounter++;
                if (NPC.frameCounter < 5)
                {
                    NPC.frame.Y = Frame_P4_1 * frameHeight;
                }
                else if (NPC.frameCounter < 10)
                {
                    NPC.frame.Y = Frame_P4_2 * frameHeight;
                }
                else if (NPC.frameCounter < 15)
                {
                    NPC.frame.Y = Frame_P4_3 * frameHeight;
                }
                else if (NPC.frameCounter < 20)
                {
                    NPC.frame.Y = Frame_P4_4 * frameHeight;
                }
                else if (NPC.frameCounter < 25)
                {
                    NPC.frame.Y = Frame_P4_5 * frameHeight;
                }
                else if (NPC.frameCounter < 30)
                {
                    NPC.frame.Y = Frame_P4_6 * frameHeight;
                }
                else if (NPC.frameCounter < 35)
                {
                    NPC.frame.Y = Frame_P4_7 * frameHeight;
                }
                else if (NPC.frameCounter < 40)
                {
                    NPC.frame.Y = Frame_P4_8 * frameHeight;
                }
                else if (NPC.frameCounter < 45)
                {
                    NPC.frame.Y = Frame_P4_9 * frameHeight;
                }
                else if (NPC.frameCounter < 50)
                {
                    NPC.frame.Y = Frame_P4_10 * frameHeight;
                }
                else if (NPC.frameCounter < 55)
                {
                    NPC.frame.Y = Frame_P4_11 * frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0;
                }
            }
            base.FindFrame(frameHeight);
        }
        public void GravityProjectiles(int randChance)
        {
            if (Main.rand.NextBool(randChance))
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int amount = Math.Min((int)(2f * NPC.lifeMax / NPC.life), 10);

                    if (Main.expertMode)
                    {
                        amount += 2;
                    }

                    float degrees = 9f;
                    Vector2 direction = -Vector2.UnitY;

                    float distanceX = Main.player[NPC.target].Center.X + Main.player[NPC.target].velocity.X - NPC.Center.X;
                    int sign = (distanceX > 0).ToDirectionInt();
                    float tilt = 20 * Math.Min(1f, Math.Abs(distanceX) / 600);

                    direction = direction.RotatedBy(MathHelper.ToRadians(sign * tilt));
                    direction = direction.RotatedBy(-MathHelper.ToRadians(-degrees / 2 + degrees * amount / 2));
                    int damage = (int)(NPC.damage / 15 * 25);
                    damage *= 10;
                    for (int i = 0; i < amount; i++)
                    {
                        Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Top, direction * 10f, ProjectileType<SmallMenacingProjectile>(), damage, 0f, Main.myPlayer);
                        direction = direction.RotatedBy(MathHelper.ToRadians(degrees));
                    }
                }
            }
        }

        public void SpawnHealHearts(int chance)
        {
            if (Main.rand.NextBool(chance * 2))
            {
                Item.NewItem(NPC.position, ItemID.Heart);
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(NPC.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(NPC.position, ItemID.Heart);
                    }
                }
            }
            else if (Main.rand.NextBool(chance * 4))
            {
                Item.NewItem(NPC.position, ItemID.Heart);
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(NPC.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(NPC.position, ItemID.Heart);
                    }
                }
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(NPC.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(NPC.position, ItemID.Heart);
                    }
                }
            }
            else if (Main.rand.NextBool(chance * 8))
            {
                Item.NewItem(NPC.position, ItemID.Heart);
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(NPC.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(NPC.position, ItemID.Heart);
                    }
                }
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(NPC.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(NPC.position, ItemID.Heart);
                    }
                }
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(NPC.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(NPC.position, ItemID.Heart);
                    }
                }
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            //Phase
            writer.Write(P1);
            writer.Write(P2);
            writer.Write(P3);
            writer.Write(P4);

            //Phase Attack
            writer.Write(P1P);
            writer.Write(P2P);
            writer.Write(P3P);
            writer.Write(P4P);

            //Phase Bool
            writer.Write(BP1);
            writer.Write(BP2);
            writer.Write(BP3);
            writer.Write(BP4);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            //Phase
            P1 = reader.ReadInt32();
            P2 = reader.ReadInt32();
            P3 = reader.ReadInt32();
            P4 = reader.ReadInt32();

            //Phase Attack
            P1P = reader.ReadBoolean();
            P2P = reader.ReadBoolean();
            P3P = reader.ReadBoolean();
            P4P = reader.ReadBoolean();

            //Phase Bool
            BP1 = reader.ReadBoolean();
            BP2 = reader.ReadBoolean();
            BP3 = reader.ReadBoolean();
            BP4 = reader.ReadBoolean();
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemType<MenacingHeartTrophy>(), 10));
            npcLoot.Add(ItemDropRule.BossBag(BossBag));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ItemType<MenacingHeartRelic>()));
            npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ItemType<MenacingCrystalShard>()));

            LeadingConditionRule notExpertRule = new(new Conditions.NotExpert());
            //notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<MenacingHeartMask>(), 7));
            notExpertRule.OnSuccess(ItemDropRule.OneFromOptionsNotScalingWithLuck(3, ItemType<MenacingLifeStaff>(), ItemType<MenacingLifeBlade>(), ItemType<MenacingHeartKeeper>()));
            npcLoot.Add(notExpertRule);
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref ElementalHeartsSystem.downedMenacingHeart, -1);

            /*if (Main.netMode != NetmodeID.Server && !Filters.Scene["PhaseChangeShockwave"].IsActive())
            {
                Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 0), ProjectileType<PhaseChangeShockwave>(), 0, 0f, Main.myPlayer);
            }
            if (Main.netMode != NetmodeID.Server && !Filters.Scene["BasicShockwave"].IsActive())
            {
                Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), NPC.Center, new Vector2(0, 0), ProjectileType<ShockwaveBasic>(), 0, 0f, Main.myPlayer);
            }*/
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
        public static bool AnyPlayerAlive
        {
            get
            {
                Player p;
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    p = Main.LocalPlayer;
                    return p.active && !(p.dead || p.ghost);
                }
                for (int i = 0; i < Main.player.Length; i++)
                {
                    p = Main.player[i];
                    if (p.active && !p.dead)
                        return true;
                }
                return false;
            }
        }

    }
}