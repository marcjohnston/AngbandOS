// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text;

namespace AngbandOS.Core;

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
    public MonsterCharacteristics Characteristics = new MonsterCharacteristics();
    public MonsterSpellList RSpells = new MonsterSpellList();
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
        SaveGame.Screen.Erase(1, 0);
        DisplayBody(ColourEnum.White);
        DisplayHeader();
    }

    public void DisplayBody(ColourEnum bodyColour)
    {
        int m;
        int msex = 0;
        string[] vp = new string[64];
        MonsterKnowledge knowledge = this;
        _description = new StringBuilder();
        if (SaveGame.IsWizard)
        {
            knowledge = new MonsterKnowledge(SaveGame, _monsterType);
            if (_monsterType.Attacks != null)
            {
                for (m = 0; m < _monsterType.Attacks.Length; m++)
                {
                    if (_monsterType.Attacks[m].Effect != null || _monsterType.Attacks[m].Method != null)
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
            knowledge.Characteristics = new MonsterCharacteristics(_monsterType);
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
        MonsterCharacteristics characteristics = new MonsterCharacteristics(_monsterType, knowledge.Characteristics);
        MonsterSpellList combinedSpells = _monsterType.Spells.Add(knowledge.RSpells);
        if (_monsterType.Unique)
        {
            characteristics.Unique = true;
        }
        if (_monsterType.Guardian)
        {
            Guardian = true;
        }
        if (_monsterType.Male)
        {
            characteristics.Male = true;
        }
        if (_monsterType.Female)
        {
            characteristics.Female = true;
        }
        if (_monsterType.Friends)
        {
            characteristics.Friends = true;
        }
        if (_monsterType.Escorted)
        {
            characteristics.Escorted = true;
        }
        if (_monsterType.EscortsGroup)
        {
            characteristics.EscortsGroup = true;
        }
        if (knowledge.RTkills != 0 || knowledge.RProbed)
        {
            if (_monsterType.Orc)
            {
                characteristics.Orc = true;
            }
            if (_monsterType.Troll)
            {
                characteristics.Troll = true;
            }
            if (_monsterType.Giant)
            {
                characteristics.Giant = true;
            }
            if (_monsterType.Dragon)
            {
                characteristics.Dragon = true;
            }
            if (_monsterType.Demon)
            {
                characteristics.Demon = true;
            }
            if (_monsterType.Cthuloid)
            {
                characteristics.Cthuloid = true;
            }
            if (_monsterType.Undead)
            {
                characteristics.Undead = true;
            }
            if (_monsterType.Evil)
            {
                characteristics.Evil = true;
            }
            if (_monsterType.Good)
            {
                characteristics.Good = true;
            }
            if (_monsterType.Animal)
            {
                characteristics.Animal = true;
            }
            if (_monsterType.GreatOldOne)
            {
                characteristics.GreatOldOne = true;
            }
            if (_monsterType.ForceMaxHp)
            {
                characteristics.ForceMaxHp = true;
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
        if (characteristics.RandomMove50 || characteristics.RandomMove25)
        {
            if (characteristics.RandomMove50 && characteristics.RandomMove25)
            {
                _description.Append(" extremely");
            }
            else if (characteristics.RandomMove50)
            {
                _description.Append(" somewhat");
            }
            else if (characteristics.RandomMove25)
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
            _description.Append(" (").Append(Constants.ExtractEnergy[_monsterType.Speed] / 10.0).Append(" actions per turn)");
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
            _description.Append(" (").Append(Constants.ExtractEnergy[_monsterType.Speed] / 10.0).Append(" actions per turn)");
        }
        else
        {
            _description.Append(" at normal speed");
        }
        if (characteristics.NeverMove)
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
            _description.Append(characteristics.Unique ? "Killing this" : "A kill of this");
            if (characteristics.EldritchHorror)
            {
                _description.Append(" sanity-blasting");
            }
            if (characteristics.Animal)
            {
                _description.Append(" natural");
            }
            if (characteristics.Evil)
            {
                _description.Append(" evil");
            }
            if (characteristics.Good)
            {
                _description.Append(" good");
            }
            if (characteristics.Undead)
            {
                _description.Append(" undead");
            }
            if (characteristics.Dragon)
            {
                _description.Append(" dragon");
            }
            else if (characteristics.Demon)
            {
                _description.Append(" demon");
            }
            else if (characteristics.Giant)
            {
                _description.Append(" giant");
            }
            else if (characteristics.Troll)
            {
                _description.Append(" troll");
            }
            else if (characteristics.Orc)
            {
                _description.Append(" orc");
            }
            else if (characteristics.GreatOldOne)
            {
                _description.Append(" Great Old One");
            }
            else
            {
                _description.Append(" creature");
            }
            int i = _monsterType.Mexp * _monsterType.Level / SaveGame.ExperienceLevel;
            int j = ((_monsterType.Mexp * _monsterType.Level % SaveGame.ExperienceLevel * 1000 /
                     SaveGame.ExperienceLevel) + 5) / 10;
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
            i = SaveGame.ExperienceLevel % 10;
            if (SaveGame.ExperienceLevel / 10 == 1)
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
            i = SaveGame.ExperienceLevel;
            if (i == 8 || i == 11 || i == 18)
            {
                q = "n";
            }
            _description.Append(" for a").Append(q).Append(' ').Append(i).Append(p).Append(" level character. ");
        }
        if (characteristics.FireAura && characteristics.LightningAura)
        {
            _description.Append(_wdHeCap[msex]).Append(" is surrounded by flames and electricity. ");
        }
        else if (characteristics.FireAura)
        {
            _description.Append(_wdHeCap[msex]).Append(" is surrounded by flames. ");
        }
        else if (characteristics.LightningAura)
        {
            _description.Append(_wdHeCap[msex]).Append(" is surrounded by electricity. ");
        }
        if (characteristics.Reflecting)
        {
            _description.Append(_wdHeCap[msex]).Append(" reflects bolt spells. ");
        }
        if (characteristics.Escorted || characteristics.EscortsGroup)
        {
            _description.Append(_wdHeCap[msex]).Append(" usually appears with escorts. ");
        }
        else if (characteristics.Friends)
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
            if (characteristics.Smart)
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
                _description.Append(characteristics.ForceMaxHp
                    ? $" and has {_monsterType.Hdice * _monsterType.Hside:n0}hp. "
                    : $" and has {_monsterType.Hdice}d{_monsterType.Hside}hp. ");
            }
        }
        vn = 0;
        if (characteristics.OpenDoor)
        {
            vp[vn++] = "open doors";
        }
        if (characteristics.BashDoor)
        {
            vp[vn++] = "bash down doors";
        }
        if (characteristics.PassWall)
        {
            vp[vn++] = "pass through walls";
        }
        if (characteristics.KillWall)
        {
            vp[vn++] = "bore through walls";
        }
        if (characteristics.MoveBody)
        {
            vp[vn++] = "push past weaker monsters";
        }
        if (characteristics.KillBody)
        {
            vp[vn++] = "destroy weaker monsters";
        }
        if (characteristics.TakeItem)
        {
            vp[vn++] = "pick up objects";
        }
        if (characteristics.KillItem)
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
        if (characteristics.Invisible)
        {
            _description.Append(_wdHeCap[msex]).Append(" is invisible. ");
        }
        if (characteristics.ColdBlood)
        {
            _description.Append(_wdHeCap[msex]).Append(" is cold blooded. ");
        }
        if (characteristics.EmptyMind)
        {
            _description.Append(_wdHeCap[msex]).Append(" is not detected by telepathy. ");
        }
        if (characteristics.WeirdMind)
        {
            _description.Append(_wdHeCap[msex]).Append(" is rarely detected by telepathy. ");
        }
        if (characteristics.Multiply)
        {
            _description.Append(_wdHeCap[msex]).Append(" breeds explosively. ");
        }
        if (characteristics.Regenerate)
        {
            _description.Append(_wdHeCap[msex]).Append(" regenerates quickly. ");
        }
        vn = 0;
        if (characteristics.HurtByRock)
        {
            vp[vn++] = "rock remover";
        }
        if (characteristics.HurtByLight)
        {
            vp[vn++] = "bright light";
        }
        if (characteristics.HurtByFire)
        {
            vp[vn++] = "fire";
        }
        if (characteristics.HurtByCold)
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
        if (characteristics.ImmuneAcid)
        {
            vp[vn++] = "acid";
        }
        if (characteristics.ImmuneLightning)
        {
            vp[vn++] = "lightning";
        }
        if (characteristics.ImmuneFire)
        {
            vp[vn++] = "fire";
        }
        if (characteristics.ImmuneCold)
        {
            vp[vn++] = "cold";
        }
        if (characteristics.ImmunePoison)
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
        if (characteristics.ResistNether)
        {
            vp[vn++] = "nether";
        }
        if (characteristics.ResistWater)
        {
            vp[vn++] = "water";
        }
        if (characteristics.ResistPlasma)
        {
            vp[vn++] = "plasma";
        }
        if (characteristics.ResistNexus)
        {
            vp[vn++] = "nexus";
        }
        if (characteristics.ResistDisenchant)
        {
            vp[vn++] = "disenchantment";
        }
        if (characteristics.ResistTeleport)
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
        if (characteristics.ImmuneStun)
        {
            vp[vn++] = "stunned";
        }
        if (characteristics.ImmuneFear)
        {
            vp[vn++] = "frightened";
        }
        if (characteristics.ImmuneConfusion)
        {
            vp[vn++] = "confused";
        }
        if (characteristics.ImmuneSleep)
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
            if (characteristics.DropGreat)
            {
                p = " exceptional";
            }
            else if (characteristics.DropGood)
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
                if (_monsterType.Attacks[m].Method == null)
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
                if (_monsterType.Attacks[m].Method == null)
                {
                    continue;
                }
                if (knowledge.RBlows[m] == 0)
                {
                    continue;
                }
                Attack method = _monsterType.Attacks[m].Method;
                AttackEffect? effect = _monsterType.Attacks[m].Effect;
                int d1 = _monsterType.Attacks[m].DDice;
                int d2 = _monsterType.Attacks[m].DSide;
                p = method.KnowledgeAction;
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
        else if (characteristics.NeverAttack)
        {
            _description.Append(_wdHeCap[msex]).Append(" has no physical attacks. ");
        }
        else
        {
            _description.Append("Nothing is known about ").Append(_wdHis[msex]).Append(" attack. ");
        }
        if (characteristics.Unique)
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
        SaveGame.Screen.PrintWrap(bodyColour, _description.ToString());
    }

    private void DisplayHeader()
    {
        char c1 = _monsterType.Symbol.Character;
        ColourEnum a1 = _monsterType.Colour;
        SaveGame.Screen.Erase(0, 0);
        SaveGame.Screen.Goto(0, 0);
        if (!_monsterType.Unique)
        {
            SaveGame.Screen.Print(ColourEnum.White, "The ");
        }
        SaveGame.Screen.Print(ColourEnum.White, _monsterType.Name);
        SaveGame.Screen.Print(ColourEnum.White, " ('");
        SaveGame.Screen.Print(a1, c1.ToString());
        SaveGame.Screen.Print(ColourEnum.White, "')");
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