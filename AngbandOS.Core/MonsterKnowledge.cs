// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using System.Text;

namespace AngbandOS
{
    [Serializable]
    internal class MonsterKnowledge
    {
        public readonly int[] RBlows = new int[4];
        public int RCastInate; 
        public int RCastSpell;
        public int RDeaths;
        public int RDropGold;
        public int RDropItem;
        public bool Guardian;
        public bool OnlyGuardian;
        public uint RFlags1;
        public uint RFlags2;
        public uint RFlags3;
        public MonsterSpellList RSpells = new MonsterSpellList();
        public uint RFlags4;
        public uint RFlags5;
        public uint RFlags6;
        public int RIgnore;
        public int RPkills;
        public bool RProbed;
        public int RSights;
        public int RTkills;
        public int RWake;
        private readonly MonsterRace _monsterType;
        private readonly string[] _wdHe = { "it", "he", "she" };
        private readonly string[] _wdHeCap = { "It", "He", "She" };
        private readonly string[] _wdHis = { "its", "his", "her" };
        private StringBuilder _description;
        private readonly SaveGame SaveGame;

        public MonsterKnowledge(SaveGame saveGame, MonsterRace monsterType)
        {
            SaveGame = saveGame;
            _monsterType = monsterType;
        }

        public void Display()
        {
            SaveGame.MsgPrint(null);
            SaveGame.Erase(1, 0, 255);
            DisplayBody(Colour.White);
            DisplayHeader();
        }

        public void DisplayBody(Colour bodyColour)
        {
            int m;
            int msex = 0;
            string[] vp = new string[64];
            MonsterKnowledge knowledge = this;
            _description = new StringBuilder();
            if (SaveGame.Player.IsWizard)
            {
                knowledge = new MonsterKnowledge(SaveGame, _monsterType);
                if (_monsterType.Attacks != null)
                {
                    for (m = 0; m < _monsterType.Attacks.Length; m++)
                    {
                        if (_monsterType.Attacks[m].Effect != null || _monsterType.Attacks[m].Method != 0)
                        {
                            knowledge.RBlows[m] = Constants.MaxUchar;
                        }
                    }
                }
                knowledge.RProbed = true;
                knowledge.RWake = Constants.MaxUchar;
                knowledge.RIgnore = Constants.MaxUchar;
                knowledge.RDropItem = (_monsterType.Drop_4D2 ? 8 : 0) +
                                      (_monsterType.Drop_3D2 ? 6 : 0) +
                                      (_monsterType.Drop_2D2 ? 4 : 0) +
                                      (_monsterType.Drop_1D2 ? 2 : 0) +
                                      (_monsterType.Drop90 ? 1 : 0) +
                                      (_monsterType.Drop60 ? 1 : 0);
                knowledge.RDropGold = knowledge.RDropItem;
                if (_monsterType.OnlyDropGold)
                {
                    knowledge.RDropItem = 0;
                }
                if (_monsterType.OnlyDropItem)
                {
                    knowledge.RDropGold = 0;
                }
                knowledge.RCastInate = Constants.MaxUchar;
                knowledge.RCastSpell = Constants.MaxUchar;
                knowledge.RFlags1 = _monsterType.Flags1;
                knowledge.RFlags2 = _monsterType.Flags2;
                knowledge.RFlags3 = _monsterType.Flags3;
                knowledge.RSpells = _monsterType.Spells;
            }
            if (_monsterType.Female)
            {
                msex = 2;
            }
            else if (_monsterType.Male)
            {
                msex = 1;
            }
            uint flags1 = _monsterType.Flags1 & knowledge.RFlags1;
            uint flags2 = _monsterType.Flags2 & knowledge.RFlags2;
            uint flags3 = _monsterType.Flags3 & knowledge.RFlags3;
            MonsterSpellList combinedSpells = _monsterType.Spells.Add(knowledge.RSpells);
            if (_monsterType.Unique)
            {
                flags1 |= MonsterFlag1.Unique;
            }
            if (_monsterType.Guardian)
            {
                Guardian = true;
            }
            if (_monsterType.Male)
            {
                flags1 |= MonsterFlag1.Male;
            }
            if (_monsterType.Female)
            {
                flags1 |= MonsterFlag1.Female;
            }
            if (_monsterType.Friends)
            {
                flags1 |= MonsterFlag1.Friends;
            }
            if (_monsterType.Escorted)
            {
                flags1 |= MonsterFlag1.Escorted;
            }
            if (_monsterType.EscortsGroup)
            {
                flags1 |= MonsterFlag1.EscortsGroup;
            }
            if (knowledge.RTkills != 0 || knowledge.RProbed)
            {
                if (_monsterType.Orc)
                {
                    flags3 |= MonsterFlag3.Orc;
                }
                if (_monsterType.Troll)
                {
                    flags3 |= MonsterFlag3.Troll;
                }
                if (_monsterType.Giant)
                {
                    flags3 |= MonsterFlag3.Giant;
                }
                if (_monsterType.Dragon)
                {
                    flags3 |= MonsterFlag3.Dragon;
                }
                if (_monsterType.Demon)
                {
                    flags3 |= MonsterFlag3.Demon;
                }
                if (_monsterType.Cthuloid)
                {
                    flags3 |= MonsterFlag3.Cthuloid;
                }
                if (_monsterType.Undead)
                {
                    flags3 |= MonsterFlag3.Undead;
                }
                if (_monsterType.Evil)
                {
                    flags3 |= MonsterFlag3.Evil;
                }
                if (_monsterType.Good)
                {
                    flags3 |= MonsterFlag3.Good;
                }
                if (_monsterType.Animal)
                {
                    flags3 |= MonsterFlag3.Animal;
                }
                if (_monsterType.GreatOldOne)
                {
                    flags3 |= MonsterFlag3.GreatOldOne;
                }
                if (_monsterType.ForceMaxHp)
                {
                    flags1 |= MonsterFlag1.ForceMaxHp;
                }
            }
            string buf = _monsterType.Description;
            _description.Append(buf);
            _description.Append(" ");
            bool old = false;
            if (_monsterType.Level == 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" lives in the town");
                old = true;
            }
            else if (knowledge.RTkills != 0 || knowledge.RProbed)
            {
                _description.Append(_wdHeCap[msex]).Append(" is normally found at level ").Append(_monsterType.Level);
                old = true;
            }
            if (old)
            {
                _description.Append(", and ");
            }
            else
            {
                _description.Append(_wdHeCap[msex]).Append(' ');
                old = true;
            }
            _description.Append("moves");
            if ((flags1 & MonsterFlag1.RandomMove50) != 0 || (flags1 & MonsterFlag1.RandomMove25) != 0)
            {
                if ((flags1 & MonsterFlag1.RandomMove50) != 0 && (flags1 & MonsterFlag1.RandomMove25) != 0)
                {
                    _description.Append(" extremely");
                }
                else if ((flags1 & MonsterFlag1.RandomMove50) != 0)
                {
                    _description.Append(" somewhat");
                }
                else if ((flags1 & MonsterFlag1.RandomMove25) != 0)
                {
                    _description.Append(" a bit");
                }
                _description.Append(" erratically");
                if (_monsterType.Speed != 110)
                {
                    _description.Append(", and");
                }
            }
            if (_monsterType.Speed > 110)
            {
                if (_monsterType.Speed > 130)
                {
                    _description.Append(" incredibly");
                }
                else if (_monsterType.Speed > 120)
                {
                    _description.Append(" very");
                }
                _description.Append(" quickly");
                _description.Append(" (").Append(GlobalData.ExtractEnergy[_monsterType.Speed] / 10.0).Append(" actions per turn)");
            }
            else if (_monsterType.Speed < 110)
            {
                if (_monsterType.Speed < 90)
                {
                    _description.Append(" incredibly");
                }
                else if (_monsterType.Speed < 100)
                {
                    _description.Append(" very");
                }
                _description.Append(" slowly");
                _description.Append(" (").Append(GlobalData.ExtractEnergy[_monsterType.Speed] / 10.0).Append(" actions per turn)");
            }
            else
            {
                _description.Append(" at normal speed");
            }
            if ((flags1 & MonsterFlag1.NeverMove) != 0)
            {
                if (old)
                {
                    _description.Append(", but ");
                }
                else
                {
                    _description.Append(_wdHe[msex]).Append(' ');
                    old = true;
                }
                _description.Append("does not deign to chase intruders");
            }
            if (old)
            {
                _description.Append(". ");
            }
            string? q;
            string? p;
            if (knowledge.RTkills != 0 || knowledge.RProbed)
            {
                _description.Append((flags1 & MonsterFlag1.Unique) != 0 ? "Killing this" : "A kill of this");
                if ((flags2 & MonsterFlag2.EldritchHorror) != 0)
                {
                    _description.Append(" sanity-blasting");
                }
                if ((flags3 & MonsterFlag3.Animal) != 0)
                {
                    _description.Append(" natural");
                }
                if ((flags3 & MonsterFlag3.Evil) != 0)
                {
                    _description.Append(" evil");
                }
                if ((flags3 & MonsterFlag3.Good) != 0)
                {
                    _description.Append(" good");
                }
                if ((flags3 & MonsterFlag3.Undead) != 0)
                {
                    _description.Append(" undead");
                }
                if ((flags3 & MonsterFlag3.Dragon) != 0)
                {
                    _description.Append(" dragon");
                }
                else if ((flags3 & MonsterFlag3.Demon) != 0)
                {
                    _description.Append(" demon");
                }
                else if ((flags3 & MonsterFlag3.Giant) != 0)
                {
                    _description.Append(" giant");
                }
                else if ((flags3 & MonsterFlag3.Troll) != 0)
                {
                    _description.Append(" troll");
                }
                else if ((flags3 & MonsterFlag3.Orc) != 0)
                {
                    _description.Append(" orc");
                }
                else if ((flags3 & MonsterFlag3.GreatOldOne) != 0)
                {
                    _description.Append(" Great Old One");
                }
                else
                {
                    _description.Append(" creature");
                }
                int i = _monsterType.Mexp * _monsterType.Level / SaveGame.Player.Level;
                int j = ((_monsterType.Mexp * _monsterType.Level % SaveGame.Player.Level * 1000 /
                         SaveGame.Player.Level) + 5) / 10;
                if (i > 0)
                {
                    _description.Append(" is worth ").AppendFormat("{0:n0}", i).Append("xp");
                }
                else if (j > 0)
                {
                    _description.Append(" is worth negligible xp");
                }
                else
                {
                    _description.Append(" is worth no xp");
                }
                p = "th";
                i = SaveGame.Player.Level % 10;
                if (SaveGame.Player.Level / 10 == 1)
                {
                }
                else if (i == 1)
                {
                    p = "st";
                }
                else if (i == 2)
                {
                    p = "nd";
                }
                else if (i == 3)
                {
                    p = "rd";
                }
                q = "";
                i = SaveGame.Player.Level;
                if (i == 8 || i == 11 || i == 18)
                {
                    q = "n";
                }
                _description.Append(" for a").Append(q).Append(' ').Append(i).Append(p).Append(" level character. ");
            }
            if ((flags2 & MonsterFlag2.FireAura) != 0 && (flags2 & MonsterFlag2.LightningAura) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" is surrounded by flames and electricity. ");
            }
            else if ((flags2 & MonsterFlag2.FireAura) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" is surrounded by flames. ");
            }
            else if ((flags2 & MonsterFlag2.LightningAura) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" is surrounded by electricity. ");
            }
            if ((flags2 & MonsterFlag2.Reflecting) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" reflects bolt spells. ");
            }
            if ((flags1 & MonsterFlag1.Escorted) != 0 || (flags1 & MonsterFlag1.EscortsGroup) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" usually appears with escorts. ");
            }
            else if ((flags1 & MonsterFlag1.Friends) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" usually appears in groups. ");
            }
            int vn = 0;
            if (combinedSpells.Contains(typeof(ShriekMonsterSpell)))
            {
                vp[vn++] = "shriek for help";
            }
            if (combinedSpells.Contains(typeof(ShardBallMonsterSpell)))
            {
                vp[vn++] = "produce shard balls";
            }
            if (combinedSpells.Contains(typeof(Arrow1D6MonsterSpell)))
            {
                vp[vn++] = "fire an arrow";
            }
            if (combinedSpells.Contains(typeof(Arrow3D6MonsterSpell)))
            {
                vp[vn++] = "fire arrows";
            }
            if (combinedSpells.Contains(typeof(Arrow5D6MonsterSpell)))
            {
                vp[vn++] = "fire a missile";
            }
            if (combinedSpells.Contains(typeof(Arrow7D6MonsterSpell)))
            {
                vp[vn++] = "fire missiles";
            }
            int n;
            if (vn != 0)
            {
                _description.Append(_wdHeCap[msex]);
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" may ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" or ");
                    }
                    _description.Append(vp[n]);
                }
                _description.Append(". ");
            }
            vn = 0;
            if (combinedSpells.Contains(typeof(BreatheAcidMonsterSpell)))
            {
                vp[vn++] = "acid";
            }
            if (combinedSpells.Contains(typeof(BreatheLightningMonsterSpell)))
            {
                vp[vn++] = "lightning";
            }
            if (combinedSpells.Contains(typeof(BreatheFireMonsterSpell)))
            {
                vp[vn++] = "fire";
            }
            if (combinedSpells.Contains(typeof(BreatheColdMonsterSpell)))
            {
                vp[vn++] = "frost";
            }
            if (combinedSpells.Contains(typeof(BreathePoisonMonsterSpell)))
            {
                vp[vn++] = "poison";
            }
            if (combinedSpells.Contains(typeof(BreatheNetherMonsterSpell)))
            {
                vp[vn++] = "nether";
            }
            if (combinedSpells.Contains(typeof(BreatheLightMonsterSpell)))
            {
                vp[vn++] = "light";
            }
            if (combinedSpells.Contains(typeof(BreatheDarkMonsterSpell)))
            {
                vp[vn++] = "darkness";
            }
            if (combinedSpells.Contains(typeof(BreatheConfusionMonsterSpell)))
            {
                vp[vn++] = "confusion";
            }
            if (combinedSpells.Contains(typeof(BreatheSoundMonsterSpell)))
            {
                vp[vn++] = "sound";
            }
            if (combinedSpells.Contains(typeof(BreatheChaosMonsterSpell)))
            {
                vp[vn++] = "chaos";
            }
            if (combinedSpells.Contains(typeof(BreatheDisenchantMonsterSpell)))
            {
                vp[vn++] = "disenchantment";
            }
            if (combinedSpells.Contains(typeof(BreatheNexusMonsterSpell)))
            {
                vp[vn++] = "nexus";
            }
            if (combinedSpells.Contains(typeof(BreatheTimeMonsterSpell)))
            {
                vp[vn++] = "time";
            }
            if (combinedSpells.Contains(typeof(BreatheInertiaMonsterSpell)))
            {
                vp[vn++] = "inertia";
            }
            if (combinedSpells.Contains(typeof(BreatheGravityMonsterSpell)))
            {
                vp[vn++] = "gravity";
            }
            if (combinedSpells.Contains(typeof(BreatheShardsMonsterSpell)))
            {
                vp[vn++] = "shards";
            }
            if (combinedSpells.Contains(typeof(BreathePlasmaMonsterSpell)))
            {
                vp[vn++] = "plasma";
            }
            if (combinedSpells.Contains(typeof(BreatheForceMonsterSpell)))
            {
                vp[vn++] = "force";
            }
            if (combinedSpells.Contains(typeof(BreatheManaMonsterSpell)))
            {
                vp[vn++] = "mana";
            }
            if (combinedSpells.Contains(typeof(BreatheRadiationMonsterSpell)))
            {
                vp[vn++] = "toxic waste";
            }
            if (combinedSpells.Contains(typeof(BreatheDisintegrationMonsterSpell)))
            {
                vp[vn++] = "disintegration";
            }
            bool breath = false;
            if (vn != 0)
            {
                breath = true;
                _description.Append(_wdHeCap[msex]);
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" may breathe ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" or ");
                    }
                    _description.Append(vp[n]);
                }
            }
            vn = 0;
            if (combinedSpells.Contains(typeof(AcidBallMonsterSpell)))
            {
                vp[vn++] = "produce acid balls";
            }
            if (combinedSpells.Contains(typeof(LightningBallMonsterSpell)))
            {
                vp[vn++] = "produce lightning balls";
            }
            if (combinedSpells.Contains(typeof(FireBallMonsterSpell)))
            {
                vp[vn++] = "produce fire balls";
            }
            if (combinedSpells.Contains(typeof(ColdBallMonsterSpell)))
            {
                vp[vn++] = "produce frost balls";
            }
            if (combinedSpells.Contains(typeof(PoisonBallMonsterSpell)))
            {
                vp[vn++] = "produce poison balls";
            }
            if (combinedSpells.Contains(typeof(NetherBallMonsterSpell)))
            {
                vp[vn++] = "produce nether balls";
            }
            if (combinedSpells.Contains(typeof(WaterBallMonsterSpell)))
            {
                vp[vn++] = "produce water balls";
            }
            if (combinedSpells.Contains(typeof(RadiationBallMonsterSpell)))
            {
                vp[vn++] = "produce balls of radiation";
            }
            if (combinedSpells.Contains(typeof(ManaBallMonsterSpell)))
            {
                vp[vn++] = "invoke mana storms";
            }
            if (combinedSpells.Contains(typeof(DarkBallMonsterSpell)))
            {
                vp[vn++] = "invoke darkness storms";
            }
            if (combinedSpells.Contains(typeof(ChaosBallMonsterSpell)))
            {
                vp[vn++] = "invoke raw chaos";
            }
            if (combinedSpells.Contains(typeof(DreadCurseMonsterSpell)))
            {
                vp[vn++] = "invoke the Dread Curse of Azathoth";
            }
            if (combinedSpells.Contains(typeof(DrainManaMonsterSpell)))
            {
                vp[vn++] = "drain mana";
            }
            if (combinedSpells.Contains(typeof(MindBlastMonsterSpell)))
            {
                vp[vn++] = "cause mind blasting";
            }
            if (combinedSpells.Contains(typeof(BrainSmashMonsterSpell)))
            {
                vp[vn++] = "cause brain smashing";
            }
            if (combinedSpells.Contains(typeof(CauseLightWoundsMonsterSpell)))
            {
                vp[vn++] = "cause light wounds and cursing";
            }
            if (combinedSpells.Contains(typeof(CauseSeriousWoundsMonsterSpell)))
            {
                vp[vn++] = "cause serious wounds and cursing";
            }
            if (combinedSpells.Contains(typeof(CauseCriticalWoundsMonsterSpell)))
            {
                vp[vn++] = "cause critical wounds and cursing";
            }
            if (combinedSpells.Contains(typeof(CauseMortalWoundsMonsterSpell)))
            {
                vp[vn++] = "cause mortal wounds";
            }
            if (combinedSpells.Contains(typeof(AcidBoltMonsterSpell)))
            {
                vp[vn++] = "produce acid bolts";
            }
            if (combinedSpells.Contains(typeof(LightningBoltMonsterSpell)))
            {
                vp[vn++] = "produce lightning bolts";
            }
            if (combinedSpells.Contains(typeof(FireBoltMonsterSpell)))
            {
                vp[vn++] = "produce fire bolts";
            }
            if (combinedSpells.Contains(typeof(ColdBoltMonsterSpell)))
            {
                vp[vn++] = "produce frost bolts";
            }
            if (combinedSpells.Contains(typeof(PoisonBoltMonsterSpell)))
            {
                vp[vn++] = "produce poison bolts";
            }
            if (combinedSpells.Contains(typeof(NetherBoltMonsterSpell)))
            {
                vp[vn++] = "produce nether bolts";
            }
            if (combinedSpells.Contains(typeof(WaterBoltMonsterSpell)))
            {
                vp[vn++] = "produce water bolts";
            }
            if (combinedSpells.Contains(typeof(ManaBoltMonsterSpell)))
            {
                vp[vn++] = "produce mana bolts";
            }
            if (combinedSpells.Contains(typeof(PlasmaBoltMonsterSpell)))
            {
                vp[vn++] = "produce plasma bolts";
            }
            if (combinedSpells.Contains(typeof(IceBoltMonsterSpell)))
            {
                vp[vn++] = "produce ice bolts";
            }
            if (combinedSpells.Contains(typeof(MagicMissileMonsterSpell)))
            {
                vp[vn++] = "produce magic missiles";
            }
            if (combinedSpells.Contains(typeof(ScareMonsterSpell)))
            {
                vp[vn++] = "terrify";
            }
            if (combinedSpells.Contains(typeof(BlindnessMonsterSpell)))
            {
                vp[vn++] = "blind";
            }
            if (combinedSpells.Contains(typeof(ConfuseMonsterSpell)))
            {
                vp[vn++] = "confuse";
            }
            if (combinedSpells.Contains(typeof(SlowMonsterSpell)))
            {
                vp[vn++] = "slow";
            }
            if (combinedSpells.Contains(typeof(HoldMonsterSpell)))
            {
                vp[vn++] = "paralyze";
            }
            if (combinedSpells.Contains(typeof(HasteMonsterSpell)))
            {
                vp[vn++] = "haste-self";
            }
            if (combinedSpells.Contains(typeof(HealMonsterSpell)))
            {
                vp[vn++] = "heal-self";
            }
            if (combinedSpells.Contains(typeof(BlinkMonsterSpell)))
            {
                vp[vn++] = "blink-self";
            }
            if (combinedSpells.Contains(typeof(TeleportSelfMonsterSpell)))
            {
                vp[vn++] = "teleport-self";
            }
            if (combinedSpells.Contains(typeof(TeleportToMonsterSpell)))
            {
                vp[vn++] = "teleport to";
            }
            if (combinedSpells.Contains(typeof(TeleportAwayMonsterSpell)))
            {
                vp[vn++] = "teleport away";
            }
            if (combinedSpells.Contains(typeof(TeleportLevelMonsterSpell)))
            {
                vp[vn++] = "teleport level";
            }
            if (combinedSpells.Contains(typeof(DarknessMonsterSpell)))
            {
                vp[vn++] = "create darkness";
            }
            if (combinedSpells.Contains(typeof(CreateTrapsMonsterSpell)))
            {
                vp[vn++] = "create traps";
            }
            if (combinedSpells.Contains(typeof(ForgetMonsterSpell)))
            {
                vp[vn++] = "cause amnesia";
            }
            if (combinedSpells.Contains(typeof(SummonMonsterMonsterSpell)))
            {
                vp[vn++] = "summon a monster";
            }
            if (combinedSpells.Contains(typeof(SummonMonstersMonsterSpell)))
            {
                vp[vn++] = "summon monsters";
            }
            if (combinedSpells.Contains(typeof(SummonKinMonsterSpell)))
            {
                vp[vn++] = "summon aid";
            }
            if (combinedSpells.Contains(typeof(SummonAntMonsterSpell)))
            {
                vp[vn++] = "summon ants";
            }
            if (combinedSpells.Contains(typeof(SummonSpiderMonsterSpell)))
            {
                vp[vn++] = "summon spiders";
            }
            if (combinedSpells.Contains(typeof(SummonHoundMonsterSpell)))
            {
                vp[vn++] = "summon hounds";
            }
            if (combinedSpells.Contains(typeof(SummonHydraMonsterSpell)))
            {
                vp[vn++] = "summon hydras";
            }
            if (combinedSpells.Contains(typeof(SummonCthuloidMonsterSpell)))
            {
                vp[vn++] = "summon a Cthuloid entity";
            }
            if (combinedSpells.Contains(typeof(SummonDemonMonsterSpell)))
            {
                vp[vn++] = "summon a demon";
            }
            if (combinedSpells.Contains(typeof(SummonUndeadMonsterSpell)))
            {
                vp[vn++] = "summon an undead";
            }
            if (combinedSpells.Contains(typeof(SummonDragonMonsterSpell)))
            {
                vp[vn++] = "summon a dragon";
            }
            if (combinedSpells.Contains(typeof(SummonHiUndeadMonsterSpell)))
            {
                vp[vn++] = "summon Greater Undead";
            }
            if (combinedSpells.Contains(typeof(SummonHiDragonMonsterSpell)))
            {
                vp[vn++] = "summon Ancient Dragons";
            }
            if (combinedSpells.Contains(typeof(SummonReaverMonsterSpell)))
            {
                vp[vn++] = "summon Black Reavers";
            }
            if (combinedSpells.Contains(typeof(SummonGreatOldOneMonsterSpell)))
            {
                vp[vn++] = "summon Great Old Ones";
            }
            if (combinedSpells.Contains(typeof(SummonUniqueMonsterSpell)))
            {
                vp[vn++] = "summon Unique Monsters";
            }
            bool magic = false;
            if (vn != 0)
            {
                magic = true;
                _description.Append(breath ? ", and is also" : $"{_wdHeCap[msex]} is");
                _description.Append(" magical, casting spells");
                if ((flags2 & MonsterFlag2.Smart) != 0)
                {
                    _description.Append(" intelligently");
                }
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" which ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" or ");
                    }
                    _description.Append(vp[n]);
                }
            }
            if (breath || magic)
            {
                m = knowledge.RCastInate + knowledge.RCastSpell;
                n = _monsterType.FrequencyChance;
                if (m > 100)
                {
                    _description.Append("; 1 time in ").Append(100 / n);
                }
                else if (m != 0)
                {
                    n = (n + 9) / 10 * 10;
                    _description.Append("; about 1 time in ").Append(100 / n);
                }
                _description.Append(". ");
            }
            if (KnowArmour(_monsterType, knowledge))
            {
                _description.Append(_wdHeCap[msex]).Append(" is AC ").Append(_monsterType.ArmourClass);
                if (_monsterType.Hdice == 1 && _monsterType.Hside == 1)
                {
                    _description.Append(" and has 1hp. ");
                }
                else
                {
                    _description.Append((flags1 & MonsterFlag1.ForceMaxHp) != 0
                        ? $" and has {_monsterType.Hdice * _monsterType.Hside:n0}hp. "
                        : $" and has {_monsterType.Hdice}d{_monsterType.Hside}hp. ");
                }
            }
            vn = 0;
            if ((flags2 & MonsterFlag2.OpenDoor) != 0)
            {
                vp[vn++] = "open doors";
            }
            if ((flags2 & MonsterFlag2.BashDoor) != 0)
            {
                vp[vn++] = "bash down doors";
            }
            if ((flags2 & MonsterFlag2.PassWall) != 0)
            {
                vp[vn++] = "pass through walls";
            }
            if ((flags2 & MonsterFlag2.KillWall) != 0)
            {
                vp[vn++] = "bore through walls";
            }
            if ((flags2 & MonsterFlag2.MoveBody) != 0)
            {
                vp[vn++] = "push past weaker monsters";
            }
            if ((flags2 & MonsterFlag2.KillBody) != 0)
            {
                vp[vn++] = "destroy weaker monsters";
            }
            if ((flags2 & MonsterFlag2.TakeItem) != 0)
            {
                vp[vn++] = "pick up objects";
            }
            if ((flags2 & MonsterFlag2.KillItem) != 0)
            {
                vp[vn++] = "destroy objects";
            }
            if (vn != 0)
            {
                _description.Append(_wdHeCap[msex]);
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" can ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" and ");
                    }
                    _description.Append(vp[n]);
                }
                _description.Append(". ");
            }
            if ((flags2 & MonsterFlag2.Invisible) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" is invisible. ");
            }
            if ((flags2 & MonsterFlag2.ColdBlood) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" is cold blooded. ");
            }
            if ((flags2 & MonsterFlag2.EmptyMind) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" is not detected by telepathy. ");
            }
            if ((flags2 & MonsterFlag2.WeirdMind) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" is rarely detected by telepathy. ");
            }
            if ((flags2 & MonsterFlag2.Multiply) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" breeds explosively. ");
            }
            if ((flags2 & MonsterFlag2.Regenerate) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" regenerates quickly. ");
            }
            vn = 0;
            if ((flags3 & MonsterFlag3.HurtByRock) != 0)
            {
                vp[vn++] = "rock remover";
            }
            if ((flags3 & MonsterFlag3.HurtByLight) != 0)
            {
                vp[vn++] = "bright light";
            }
            if ((flags3 & MonsterFlag3.HurtByFire) != 0)
            {
                vp[vn++] = "fire";
            }
            if ((flags3 & MonsterFlag3.HurtByCold) != 0)
            {
                vp[vn++] = "cold";
            }
            if (vn != 0)
            {
                _description.Append(_wdHeCap[msex]);
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" is hurt by ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" and ");
                    }
                    _description.Append(vp[n]);
                }
                _description.Append(". ");
            }
            vn = 0;
            if ((flags3 & MonsterFlag3.ImmuneAcid) != 0)
            {
                vp[vn++] = "acid";
            }
            if ((flags3 & MonsterFlag3.ImmuneLightning) != 0)
            {
                vp[vn++] = "lightning";
            }
            if ((flags3 & MonsterFlag3.ImmuneFire) != 0)
            {
                vp[vn++] = "fire";
            }
            if ((flags3 & MonsterFlag3.ImmuneCold) != 0)
            {
                vp[vn++] = "cold";
            }
            if ((flags3 & MonsterFlag3.ImmunePoison) != 0)
            {
                vp[vn++] = "poison";
            }
            if (vn != 0)
            {
                _description.Append(_wdHeCap[msex]);
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" resists ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" and ");
                    }
                    _description.Append(vp[n]);
                }
                _description.Append(". ");
            }
            vn = 0;
            if ((flags3 & MonsterFlag3.ResistNether) != 0)
            {
                vp[vn++] = "nether";
            }
            if ((flags3 & MonsterFlag3.ResistWater) != 0)
            {
                vp[vn++] = "water";
            }
            if ((flags3 & MonsterFlag3.ResistPlasma) != 0)
            {
                vp[vn++] = "plasma";
            }
            if ((flags3 & MonsterFlag3.ResistNexus) != 0)
            {
                vp[vn++] = "nexus";
            }
            if ((flags3 & MonsterFlag3.ResistDisenchant) != 0)
            {
                vp[vn++] = "disenchantment";
            }
            if ((flags3 & MonsterFlag3.ResistTeleport) != 0)
            {
                vp[vn++] = "teleportation";
            }
            if (vn != 0)
            {
                _description.Append(_wdHeCap[msex]);
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" resists ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" and ");
                    }
                    _description.Append(vp[n]);
                }
                _description.Append(". ");
            }
            vn = 0;
            if ((flags3 & MonsterFlag3.ImmuneStun) != 0)
            {
                vp[vn++] = "stunned";
            }
            if ((flags3 & MonsterFlag3.ImmuneFear) != 0)
            {
                vp[vn++] = "frightened";
            }
            if ((flags3 & MonsterFlag3.ImmuneConfusion) != 0)
            {
                vp[vn++] = "confused";
            }
            if ((flags3 & MonsterFlag3.ImmuneSleep) != 0)
            {
                vp[vn++] = "slept";
            }
            if (vn != 0)
            {
                _description.Append(_wdHeCap[msex]);
                for (n = 0; n < vn; n++)
                {
                    if (n == 0)
                    {
                        _description.Append(" cannot be ");
                    }
                    else if (n < vn - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(" or ");
                    }
                    _description.Append(vp[n]);
                }
                _description.Append(". ");
            }
            if (knowledge.RWake * knowledge.RWake > _monsterType.Sleep || knowledge.RIgnore == Constants.MaxUchar ||
                (_monsterType.Sleep == 0 && (knowledge.RTkills >= 10 || knowledge.RProbed)))
            {
                string act;
                if (_monsterType.Sleep > 200)
                {
                    act = "prefers to ignore";
                }
                else if (_monsterType.Sleep > 95)
                {
                    act = "pays very little attention to";
                }
                else if (_monsterType.Sleep > 75)
                {
                    act = "pays little attention to";
                }
                else if (_monsterType.Sleep > 45)
                {
                    act = "tends to overlook";
                }
                else if (_monsterType.Sleep > 25)
                {
                    act = "takes quite a while to see";
                }
                else if (_monsterType.Sleep > 10)
                {
                    act = "takes a while to see";
                }
                else if (_monsterType.Sleep > 5)
                {
                    act = "is fairly observant of";
                }
                else if (_monsterType.Sleep > 3)
                {
                    act = "is observant of";
                }
                else if (_monsterType.Sleep > 1)
                {
                    act = "is very observant of";
                }
                else if (_monsterType.Sleep > 0)
                {
                    act = "is vigilant for";
                }
                else
                {
                    act = "is ever vigilant for";
                }
                _description.Append(
                    _wdHeCap[msex]).Append(' ').Append(act).Append(" intruders, which ").Append(_wdHe[msex]).Append(" may notice from ").AppendFormat("{0:n0}", 10 * _monsterType.NoticeRange).Append(" feet. ");
            }
            if (knowledge.RDropGold != 0 || knowledge.RDropItem != 0)
            {
                bool sin = false;
                _description.Append(_wdHeCap[msex]).Append(" may carry");
                n = Math.Max(knowledge.RDropGold, knowledge.RDropItem);
                if (n == 1)
                {
                    _description.Append(" a");
                    sin = true;
                }
                else if (n == 2)
                {
                    _description.Append(" one or two");
                }
                else
                {
                    _description.Append(" up to ").Append(n);
                }
                if ((flags1 & MonsterFlag1.DropGreat) != 0)
                {
                    p = " exceptional";
                }
                else if ((flags1 & MonsterFlag1.DropGood) != 0)
                {
                    p = " good";
                    sin = false;
                }
                else
                {
                    p = null;
                }
                if (knowledge.RDropItem != 0)
                {
                    if (sin)
                    {
                        _description.Append("n");
                    }
                    sin = false;
                    if (!string.IsNullOrEmpty(p))
                    {
                        _description.Append(p);
                    }
                    _description.Append(" object");
                    if (n != 1)
                    {
                        _description.Append("s");
                    }
                    p = " or";
                }
                if (knowledge.RDropGold != 0)
                {
                    if (string.IsNullOrEmpty(p))
                    {
                        sin = false;
                    }
                    if (sin)
                    {
                        _description.Append("n");
                    }
                    if (!string.IsNullOrEmpty(p))
                    {
                        _description.Append(p);
                    }
                    _description.Append(" treasure");
                    if (n != 1)
                    {
                        _description.Append("s");
                    }
                }
                _description.Append(". ");
            }
            n = 0;
            if (_monsterType.Attacks != null)
            {
                for (m = 0; m < _monsterType.Attacks.Length; m++)
                {
                    if (_monsterType.Attacks[m].Method == 0)
                    {
                        continue;
                    }
                    if (knowledge.RBlows[m] != 0)
                    {
                        n++;
                    }
                }
            }
            int r = 0;
            if (_monsterType.Attacks != null)
            {
                for (m = 0; m < _monsterType.Attacks.Length; m++)
                {
                    if (_monsterType.Attacks[m].Method == 0)
                    {
                        continue;
                    }
                    if (knowledge.RBlows[m] == 0)
                    {
                        continue;
                    }
                    AttackType method = _monsterType.Attacks[m].Method;
                    BaseAttackEffect? effect = _monsterType.Attacks[m].Effect;
                    int d1 = _monsterType.Attacks[m].DDice;
                    int d2 = _monsterType.Attacks[m].DSide;
                    p = null;
                    switch (method)
                    {
                        case AttackType.Hit:
                            p = "hit";
                            break;

                        case AttackType.Touch:
                            p = "touch";
                            break;

                        case AttackType.Punch:
                            p = "punch";
                            break;

                        case AttackType.Kick:
                            p = "kick";
                            break;

                        case AttackType.Claw:
                            p = "claw";
                            break;

                        case AttackType.Bite:
                            p = "bite";
                            break;

                        case AttackType.Sting:
                            p = "sting";
                            break;

                        case AttackType.Butt:
                            p = "butt";
                            break;

                        case AttackType.Crush:
                            p = "crush";
                            break;

                        case AttackType.Engulf:
                            p = "engulf";
                            break;

                        case AttackType.Charge:
                            p = "charge";
                            break;

                        case AttackType.Crawl:
                            p = "crawl on you";
                            break;

                        case AttackType.Drool:
                            p = "drool on you";
                            break;

                        case AttackType.Spit:
                            p = "spit";
                            break;

                        case AttackType.Gaze:
                            p = "gaze";
                            break;

                        case AttackType.Wail:
                            p = "wail";
                            break;

                        case AttackType.Spore:
                            p = "release spores";
                            break;

                        case AttackType.Worship:
                            p = "hero worship";
                            break;

                        case AttackType.Beg:
                            p = "beg";
                            break;

                        case AttackType.Insult:
                            p = "insult";
                            break;

                        case AttackType.Moan:
                            p = "moan";
                            break;

                        case AttackType.Show:
                            p = "sing";
                            break;
                    }
                    if (effect == null)
                        q = null;
                    else
                        q = effect.Description;

                    if (r == 0)
                    {
                        _description.Append(_wdHeCap[msex]).Append(" can ");
                    }
                    else if (r < n - 1)
                    {
                        _description.Append(", ");
                    }
                    else
                    {
                        _description.Append(", and ");
                    }
                    if (string.IsNullOrEmpty(p))
                    {
                        p = "do something weird";
                    }
                    _description.Append(p);
                    if (!string.IsNullOrEmpty(q))
                    {
                        _description.Append(" to ");
                        _description.Append(q);
                        if (d1 != 0 && d2 != 0 && KnowDamage(_monsterType, knowledge, m))
                        {
                            _description.Append(" for ").Append(d1).Append('d').Append(d2).Append(" damage");
                        }
                    }
                    r++;
                }
            }
            if (r != 0)
            {
                _description.Append(". ");
            }
            else if ((flags1 & MonsterFlag1.NeverAttack) != 0)
            {
                _description.Append(_wdHeCap[msex]).Append(" has no physical attacks. ");
            }
            else
            {
                _description.Append("Nothing is known about ").Append(_wdHis[msex]).Append(" attack. ");
            }
            if ((flags1 & MonsterFlag1.Unique) != 0)
            {
                bool dead = _monsterType.MaxNum == 0;
                if (knowledge.RDeaths != 0)
                {
                    _description.Append(_wdHe[msex]).Append(" has slain ").AppendFormat("{0:n0}", knowledge.RDeaths).Append(" of your ancestors");
                    if (dead)
                    {
                        _description.Append(", but you have avenged them! ");
                    }
                    else
                    {
                        string remain = knowledge.RDeaths == 1 ? "remains" : "remain";
                        _description.Append(", who ").Append(remain).Append(" unavenged. ");
                    }
                }
                else if (dead)
                {
                    _description.Append("You have slain this foe. ");
                }
            }
            else if (knowledge.RDeaths != 0)
            {
                string has = knowledge.RDeaths == 1 ? "has" : "have";
                _description.AppendFormat("{0:n0}", knowledge.RDeaths).Append(" of your ancestors ").Append(has).Append(" been killed by this creature, ");
                if (knowledge.RPkills != 0)
                {
                    _description.Append(
                        "and you have exterminated at least ").AppendFormat("{0:n0}", knowledge.RPkills).Append(" of the creatures. ");
                }
                else if (knowledge.RTkills != 0)
                {
                    _description.Append(
                        "and your ancestors have exterminated at least ").AppendFormat("{0:n0}", knowledge.RTkills).Append(" of the creatures. ");
                }
                else
                {
                    _description.Append("and ").Append(_wdHe[msex]).Append(" is not ever known to have been defeated. ");
                }
            }
            else
            {
                if (knowledge.RPkills != 0)
                {
                    _description.Append("You have killed at least ").AppendFormat("{0:n0}", knowledge.RPkills).Append(" of these creatures. ");
                }
                else if (knowledge.RTkills != 0)
                {
                    _description.Append(
                        "Your ancestors have killed at least ").AppendFormat("{0:n0}", knowledge.RTkills).Append(" of these creatures. ");
                }
                else
                {
                    _description.Append("No battles to the death are recalled. ");
                }
            }
            if (Guardian)
            {
                _description.Append("You feel an intense desire to kill this monster... ");
            }
            SaveGame.PrintWrap(bodyColour, _description.ToString());
        }

        private void DisplayHeader()
        {
            char c1 = _monsterType.Character;
            Colour a1 = _monsterType.Colour;
            SaveGame.Erase(0, 0, 255);
            SaveGame.Goto(0, 0);
            if (!_monsterType.Unique)
            {
                SaveGame.Print(Colour.White, "The ", -1);
            }
            SaveGame.Print(Colour.White, _monsterType.Name, -1);
            SaveGame.Print(Colour.White, " ('", -1);
            SaveGame.Print(a1, c1);
            SaveGame.Print(Colour.White, "')", -1);
        }

        private bool KnowArmour(MonsterRace monsterType, MonsterKnowledge knowledge)
        {
            int kills = knowledge.RTkills;
            if ((kills > 304 / (4 + monsterType.Level)) || knowledge.RProbed)
            {
                return true;
            }
            if (!monsterType.Unique)
            {
                return false;
            }
            return kills > 304 / (38 + (5 * monsterType.Level / 4));
        }

        private bool KnowDamage(MonsterRace monsterType, MonsterKnowledge knowledge, int i)
        {
            int a = knowledge.RBlows[i];
            int d1 = monsterType.Attacks[i].DDice;
            int d2 = monsterType.Attacks[i].DSide;
            int d = d1 * d2;
            if ((4 + monsterType.Level) * a > 80 * d)
            {
                return true;
            }
            if (!monsterType.Unique)
            {
                return false;
            }
            return (4 + monsterType.Level) * 2 * a > 80 * d;
        }
    }
}