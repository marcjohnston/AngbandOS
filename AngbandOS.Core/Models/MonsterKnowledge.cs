// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;
namespace AngbandOS.Core;

[Serializable]
internal class MonsterKnowledge : IGameSerialize
{

    #region State Data
    public readonly int[] RBlows = new int[4];
    public int RCastInate;
    public int RCastSpell;
    public int RDeaths;
    public int RDropGold;
    public int RDropItem;
    public bool Guardian;
    public bool OnlyGuardian;
    public MonsterCharacteristics Characteristics = new MonsterCharacteristics();
    public MonsterSpell[] RSpells = new MonsterSpell[] { };
    public int RIgnore;
    public int RPkills;
    public bool RProbed;
    public int RSights;
    public int RTkills;
    public int RWake;
    private readonly MonsterRace _monsterType;
    #endregion

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(_monsterType), saveGameState.CreateGameStateBag(_monsterType, typeof(MonsterRace))),
            (nameof(RBlows), saveGameState.CreateGameStateBag(RBlows)),
            (nameof(RCastInate), saveGameState.CreateGameStateBag(RCastInate)),
            (nameof(RCastSpell), saveGameState.CreateGameStateBag(RCastSpell)),
            (nameof(RDeaths), saveGameState.CreateGameStateBag(RDeaths)),
            (nameof(RDropGold), saveGameState.CreateGameStateBag(RDropGold)),
            (nameof(RDropItem), saveGameState.CreateGameStateBag(RDropItem)),
            (nameof(Guardian), saveGameState.CreateGameStateBag(Guardian)),
            (nameof(OnlyGuardian), saveGameState.CreateGameStateBag(OnlyGuardian)),
            (nameof(Characteristics), saveGameState.CreateGameStateBag(Characteristics, typeof(MonsterCharacteristics))),
            (nameof(RSpells), saveGameState.CreateGameStateBag(RSpells)),
            (nameof(RIgnore), saveGameState.CreateGameStateBag(RIgnore)),
            (nameof(RPkills), saveGameState.CreateGameStateBag(RPkills)),
            (nameof(RProbed), saveGameState.CreateGameStateBag(RProbed)),
            (nameof(RSights), saveGameState.CreateGameStateBag(RSights)),
            (nameof(RTkills), saveGameState.CreateGameStateBag(RTkills)),
            (nameof(RWake), saveGameState.CreateGameStateBag(RWake))
        );
    }

    private string[] _wdHe { get; } = { "it", "he", "she" };
    private string[] _wdHeCap { get; } = { "It", "He", "She" };
    private string[] _wdHis { get; } = { "its", "his", "her" };
    private Game Game { get; }

    public MonsterKnowledge(Game game, MonsterRace monsterRace)
    {
        Game = game;
        _monsterType = monsterRace;
    }

    public MonsterKnowledge(Game game, RestoreGameState restoreGameState) : this(game, restoreGameState.GetByKey(nameof(_monsterType)).GetDerivedReference<MonsterRace>())
    {
        RBlows = restoreGameState.GetByKey(nameof(RBlows)).GetInts();
        RCastInate = restoreGameState.GetByKey(nameof(RCastInate)).GetInt();
        RCastSpell = restoreGameState.GetByKey(nameof(RCastSpell)).GetInt();
        RDeaths = restoreGameState.GetByKey(nameof(RDeaths)).GetInt();
        RDropGold = restoreGameState.GetByKey(nameof(RDropGold)).GetInt();
        RDropItem = restoreGameState.GetByKey(nameof(RDropItem)).GetInt();
        Guardian = restoreGameState.GetByKey(nameof(Guardian)).GetBool();
        OnlyGuardian = restoreGameState.GetByKey(nameof(OnlyGuardian)).GetBool();
        Characteristics = restoreGameState.GetByKey(nameof(Characteristics)).GetDerivedReference<MonsterCharacteristics>((RestoreGameState restoreGameState) => new MonsterCharacteristics(Game, restoreGameState));
        RSpells = restoreGameState.GetByKey(nameof(RSpells)).GetDerivedReferences<MonsterSpell>();
        RIgnore = restoreGameState.GetByKey(nameof(RIgnore)).GetInt();
        RPkills = restoreGameState.GetByKey(nameof(RPkills)).GetInt();
        RProbed = restoreGameState.GetByKey(nameof(RProbed)).GetBool();
        RSights = restoreGameState.GetByKey(nameof(RSights)).GetInt();
        RTkills = restoreGameState.GetByKey(nameof(RTkills)).GetInt();
        RWake = restoreGameState.GetByKey(nameof(RWake)).GetInt();
    }

    public void Display()
    {
        Game.MsgPrint(string.Empty);
        Game.Screen.Erase(1, 0);
        DisplayBody(ColorEnum.White);
        DisplayHeader();
    }

    public void DisplayBody(ColorEnum bodyColor)
    {
        int m;
        int msex = 0;
        string[] vp = new string[64];
        MonsterKnowledge knowledge = this;
        StringBuilder _description = new StringBuilder();
        if (Game.IsWizard.BoolValue)
        {
            knowledge = new MonsterKnowledge(Game, _monsterType);
            for (m = 0; m < _monsterType.Attacks.Length; m++)
            {
                if (_monsterType.Attacks[m].Effect != null || _monsterType.Attacks[m].Method != null)
                {
                    knowledge.RBlows[m] = Constants.MaxUchar;
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
        MonsterSpell[] combinedSpells = _monsterType.Spells.Concat(knowledge.RSpells).ToArray();
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
            _description.Append(" (").Append(Game.ExtractEnergy[_monsterType.Speed] / 10.0).Append(" actions per turn)");
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
            _description.Append(" (").Append(Game.ExtractEnergy[_monsterType.Speed] / 10.0).Append(" actions per turn)");
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
            int i = _monsterType.Mexp * _monsterType.Level / Game.ExperienceLevel.IntValue;
            int j = ((_monsterType.Mexp * _monsterType.Level % Game.ExperienceLevel.IntValue * 1000 /
                     Game.ExperienceLevel.IntValue) + 5) / 10;
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
            i = Game.ExperienceLevel.IntValue % 10;
            if (Game.ExperienceLevel.IntValue / 10 == 1)
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
            i = Game.ExperienceLevel.IntValue;
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
        if (combinedSpells.Any(spell => typeof(ShriekScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "shriek for help";
        }
        if (combinedSpells.Any(spell => typeof(ShardBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce shard balls";
        }
        if (combinedSpells.Any(spell => typeof(Arrow1D6ProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "fire an arrow";
        }
        if (combinedSpells.Any(spell => typeof(Arrow3D6ProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "fire arrows";
        }
        if (combinedSpells.Any(spell => typeof(Arrow5D6ProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "fire a missile";
        }
        if (combinedSpells.Any(spell => typeof(Arrow7D6ProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
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
        if (combinedSpells.Any(spell => typeof(AcidBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "acid";
        }
        if (combinedSpells.Any(spell => typeof(LightningBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "lightning";
        }
        if (combinedSpells.Any(spell => typeof(FireBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "fire";
        }
        if (combinedSpells.Any(spell => typeof(ColdBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "frost";
        }
        if (combinedSpells.Any(spell => typeof(PoisonBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "poison";
        }
        if (combinedSpells.Any(spell => typeof(NetherBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "nether";
        }
        if (combinedSpells.Any(spell => typeof(LightBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "light";
        }
        if (combinedSpells.Any(spell => typeof(DarkBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "darkness";
        }
        if (combinedSpells.Any(spell => typeof(ConfusionBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "confusion";
        }
        if (combinedSpells.Any(spell => typeof(SoundBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "sound";
        }
        if (combinedSpells.Any(spell => typeof(ChaosBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "chaos";
        }
        if (combinedSpells.Any(spell => typeof(DisenchantBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "disenchantment";
        }
        if (combinedSpells.Any(spell => typeof(NexusBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "nexus";
        }
        if (combinedSpells.Any(spell => typeof(TimeBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "time";
        }
        if (combinedSpells.Any(spell => typeof(InertiaBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "inertia";
        }
        if (combinedSpells.Any(spell => typeof(GravityBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "gravity";
        }
        if (combinedSpells.Any(spell => typeof(ShardsBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "shards";
        }
        if (combinedSpells.Any(spell => typeof(PlasmaBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "plasma";
        }
        if (combinedSpells.Any(spell => typeof(ForceBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "force";
        }
        if (combinedSpells.Any(spell => typeof(ManaBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "mana";
        }
        if (combinedSpells.Any(spell => typeof(RadiationBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "toxic waste";
        }
        if (combinedSpells.Any(spell => typeof(DisintegrationBreathProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
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
        if (combinedSpells.Any(spell => typeof(AcidBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce acid balls";
        }
        if (combinedSpells.Any(spell => typeof(LightningBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce lightning balls";
        }
        if (combinedSpells.Any(spell => typeof(FireBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce fire balls";
        }
        if (combinedSpells.Any(spell => typeof(ColdBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce frost balls";
        }
        if (combinedSpells.Any(spell => typeof(PoisonBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce poison balls";
        }
        if (combinedSpells.Any(spell => typeof(NetherBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce nether balls";
        }
        if (combinedSpells.Any(spell => typeof(WaterBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce water balls";
        }
        if (combinedSpells.Any(spell => typeof(RadiationBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce balls of radiation";
        }
        if (combinedSpells.Any(spell => typeof(ManaBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "invoke mana storms";
        }
        if (combinedSpells.Any(spell => typeof(DarkBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "invoke darkness storms";
        }
        if (combinedSpells.Any(spell => typeof(ChaosBallProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "invoke raw chaos";
        }
        if (combinedSpells.Any(spell => typeof(DreadCurseScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "invoke the Dread Curse of Azathoth";
        }
        if (combinedSpells.Any(spell => typeof(DrainManaScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "drain mana";
        }
        if (combinedSpells.Any(spell => typeof(MindBlastScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "cause mind blasting";
        }
        if (combinedSpells.Any(spell => typeof(BrainSmashScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "cause brain smashing";
        }
        if (combinedSpells.Any(spell => typeof(CauseLightWoundsMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "cause light wounds and cursing";
        }
        if (combinedSpells.Any(spell => typeof(CauseSeriousWoundsMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "cause serious wounds and cursing";
        }
        if (combinedSpells.Any(spell => typeof(CauseCriticalWoundsMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "cause critical wounds and cursing";
        }
        if (combinedSpells.Any(spell => typeof(CauseMortalWoundsMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "cause mortal wounds";
        }
        if (combinedSpells.Any(spell => typeof(AcidBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce acid bolts";
        }
        if (combinedSpells.Any(spell => typeof(LightningBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce lightning bolts";
        }
        if (combinedSpells.Any(spell => typeof(FireBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce fire bolts";
        }
        if (combinedSpells.Any(spell => typeof(ColdBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce frost bolts";
        }
        if (combinedSpells.Any(spell => typeof(PoisonBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce poison bolts";
        }
        if (combinedSpells.Any(spell => typeof(NetherBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce nether bolts";
        }
        if (combinedSpells.Any(spell => typeof(WaterBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce water bolts";
        }
        if (combinedSpells.Any(spell => typeof(ManaBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce mana bolts";
        }
        if (combinedSpells.Any(spell => typeof(PlasmaBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce plasma bolts";
        }
        if (combinedSpells.Any(spell => typeof(IceBoltProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce ice bolts";
        }
        if (combinedSpells.Any(spell => typeof(MagicMissileProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "produce magic missiles";
        }
        if (combinedSpells.Any(spell => typeof(ScareScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "terrify";
        }
        if (combinedSpells.Any(spell => typeof(BlindnessScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "blind";
        }
        if (combinedSpells.Any(spell => typeof(ConfuseScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "confuse";
        }
        if (combinedSpells.Any(spell => typeof(SlowScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "slow";
        }
        if (combinedSpells.Any(spell => typeof(HoldScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "paralyze";
        }
        if (combinedSpells.Any(spell => typeof(HasteScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "haste-self";
        }
        if (combinedSpells.Any(spell => typeof(HealScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "heal-self";
        }
        if (combinedSpells.Any(spell => typeof(BlinkScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "blink-self";
        }
        if (combinedSpells.Any(spell => typeof(TeleportSelfScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "teleport-self";
        }
        if (combinedSpells.Any(spell => typeof(TeleportToScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "teleport to";
        }
        if (combinedSpells.Any(spell => typeof(TeleportAwayScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "teleport away";
        }
        if (combinedSpells.Any(spell => typeof(TeleportLevelScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "teleport level";
        }
        if (combinedSpells.Any(spell => typeof(DarknessProjectileMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "create darkness";
        }
        if (combinedSpells.Any(spell => typeof(CreateTrapsScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "create traps";
        }
        if (combinedSpells.Any(spell => typeof(ForgetScriptMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "cause amnesia";
        }
        if (combinedSpells.Any(spell => typeof(MonsterSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon a monster";
        }
        if (combinedSpells.Any(spell => typeof(MonstersSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon monsters";
        }
        if (combinedSpells.Any(spell => typeof(KinSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon aid";
        }
        if (combinedSpells.Any(spell => typeof(AntSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon ants";
        }
        if (combinedSpells.Any(spell => typeof(SpiderSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon spiders";
        }
        if (combinedSpells.Any(spell => typeof(HoundSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon hounds";
        }
        if (combinedSpells.Any(spell => typeof(HydraSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon hydras";
        }
        if (combinedSpells.Any(spell => typeof(CthuloidSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon a Cthuloid entity";
        }
        if (combinedSpells.Any(spell => typeof(DemonSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon a demon";
        }
        if (combinedSpells.Any(spell => typeof(UndeadSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon an undead";
        }
        if (combinedSpells.Any(spell => typeof(DragonSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon a dragon";
        }
        if (combinedSpells.Any(spell => typeof(HiUndeadSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon Greater Undead";
        }
        if (combinedSpells.Any(spell => typeof(HiDragonSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon Ancient Dragons";
        }
        if (combinedSpells.Any(spell => typeof(ReaverSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon Black Reavers";
        }
        if (combinedSpells.Any(spell => typeof(GreatOldOneSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
        {
            vp[vn++] = "summon Great Old Ones";
        }
        if (combinedSpells.Any(spell => typeof(UniqueSummonMonsterSpell).IsAssignableFrom(spell.GetType())))
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
        if (KnowArmor(_monsterType, knowledge))
        {
            _description.Append(_wdHeCap[msex]).Append(" is AC ").Append(_monsterType.ArmorClass);
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
        int r = 0;
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
            int d1 = _monsterType.Attacks[m].Dice;
            int d2 = _monsterType.Attacks[m].Sides;
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
        Game.Screen.PrintWrap(bodyColor, _description.ToString());
    }

    private void DisplayHeader()
    {
        char c1 = _monsterType.Symbol.Character;
        ColorEnum a1 = _monsterType.Color;
        Game.Screen.Erase(0, 0);
        Game.Screen.Goto(0, 0);
        if (!_monsterType.Unique)
        {
            Game.Screen.Print(ColorEnum.White, "The ");
        }
        Game.Screen.Print(ColorEnum.White, _monsterType.FriendlyName);
        Game.Screen.Print(ColorEnum.White, " ('");
        Game.Screen.Print(a1, c1.ToString());
        Game.Screen.Print(ColorEnum.White, "')");
    }

    private bool KnowArmor(MonsterRace monsterType, MonsterKnowledge knowledge)
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
        int d1 = monsterType.Attacks[i].Dice;
        int d2 = monsterType.Attacks[i].Sides;
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