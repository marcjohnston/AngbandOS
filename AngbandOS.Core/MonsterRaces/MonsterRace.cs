// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal abstract class MonsterRace : IMonsterCharacteristics, IGetKey
{
    #region 102 Serialized Members

    public virtual string Key => GetType().Name;

    protected virtual string[]? SpellNames => null;

    /// <summary>
    /// Returns the key for the symbol to be used.  The actual Symbol object is bound to the Symbol property during the
    /// bind phase.
    /// </summary>
    protected abstract string SymbolName { get; }

    /// <summary>
    /// The color to display the monster as.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    /// <summary>
    /// The monster is an animal.
    /// </summary>
    public virtual bool Animal => false;

    /// <summary>
    /// The monsters armor class.
    /// </summary>
    public abstract int ArmorClass { get; }

    /// <summary>
    /// Returns an array of the definitions for the attacks abilities of the monster; or null, if the monster cannot attack.  Returns
    /// null, by default.
    /// </summary>
    protected virtual (string MethodName, string? EffectName, int Dice, int Sides)[]? AttackDefinitions => null;

    /// <summary>
    /// The monster's color can be anything (if 'AttrMulti' is set).
    /// </summary>
    public virtual bool AttrAny => false;

    /// <summary>
    /// The monster is transparent.
    /// </summary>
    public virtual bool AttrClear => false;

    /// <summary>
    /// The monster changes color.
    /// </summary>
    public virtual bool AttrMulti => false;

    /// <summary>
    /// The monster can break open doors.
    /// </summary>
    public virtual bool BashDoor => false;

    /// <summary>
    /// The monster is never seen, even with see invisible.
    /// </summary>
    public virtual bool CharClear => false;

    /// <summary>
    /// The monster is changes shape randomly.
    /// </summary>
    public virtual bool CharMulti => false;

    public virtual bool ColdBlood => false;

    public virtual bool Cthuloid => false;


    public virtual bool Demon => false;

    /// <summary>
    /// The descriptive text.
    /// </summary>
    public abstract string Description { get; }

    public virtual bool Dragon => false;

    /// <summary>
    /// The monster drops 1d2 items.
    /// </summary>
    public virtual bool Drop_1D2 => false;

    /// <summary>
    /// The monster drops 2d2 items.
    /// </summary>
    public virtual bool Drop_2D2 => false;

    /// <summary>
    /// The monster drops 3d2 items.
    /// </summary>
    public virtual bool Drop_3D2 => false;

    /// <summary>
    /// The monster drops 4d2 items.
    /// </summary>
    public virtual bool Drop_4D2 => false;

    /// <summary>
    /// The monster drops an item 60% of the time.
    /// </summary>
    public virtual bool Drop60 => false;

    /// <summary>
    /// The monster drops an item 90% of the time.
    /// </summary>
    public virtual bool Drop90 => false;

    /// <summary>
    /// The monster drops good items.
    /// </summary>
    public virtual bool DropGood => false;

    /// <summary>
    /// The monster drops great items.
    /// </summary>
    public virtual bool DropGreat => false;

    public virtual bool EldritchHorror => false;

    public virtual bool EmptyMind => false;

    /// <summary>
    /// The monster comes with minions of the same character.
    /// </summary>
    public virtual bool Escorted => false;

    /// <summary>
    /// The monster's minions come in groups (this doesn't force minions if 'Escort' isn't set).
    /// </summary>
    public virtual bool EscortsGroup => false;

    public virtual bool Evil => false;

    /// <summary>
    /// The monster should use feminine pronouns.
    /// </summary>
    public virtual bool Female => false;

    /// <summary>
    /// The monster has an aura of fire around it.
    /// </summary>
    public virtual bool FireAura => false;

    /// The monster has maximum hit points.
    /// </summary>
    public virtual bool ForceMaxHp => false;

    /// <summary>
    /// The monster always starts asleep.
    /// </summary>
    public virtual bool ForceSleep => false;

    /// <summary>
    /// The 1-in-X frequency with which the monster uses special abilities.
    /// </summary>
    public abstract int FreqInate { get; }

    /// <summary>
    /// The 1-in-X frequency with which the monster uses spells.
    /// </summary>
    public abstract int FreqSpell { get; }

    /// <summary>
    /// Returns the full name of the monster race that is shown to the player.  Duplicate names is supported.
    /// </summary>
    public abstract string FriendlyName { get; }

    /// <summary>
    /// Returns a multiline version of the monster race that is shown to the player.  Returns null, if the <see cref="FriendlyName"/> should be used.  Word-breaks
    /// are encoded with a \n character.
    /// </summary>
    public virtual string? MultilineName => null;

    public string[] GetMultilineName => Game.ConvertToMultiline(MultilineName ?? FriendlyName);

    /// <summary>
    /// The monster comes with friends of the same race.
    /// </summary>
    public virtual bool Friends => false;

    public virtual bool Giant => false;

    public virtual bool Good => false;

    public virtual bool GreatOldOne => false;

    /// <summary>
    /// The number of hit dice the monster has.
    /// </summary>
    public abstract int Hdice { get; }

    /// <summary>
    /// The number of sides of the monster's hit dice.
    /// </summary>
    public abstract int Hside { get; }

    public virtual bool HurtByCold => false;

    public virtual bool HurtByFire => false;

    public virtual bool HurtByLight => false;

    public virtual bool HurtByRock => false;

    public virtual bool ImmuneAcid => false;

    public virtual bool ImmuneCold => false;

    public virtual bool ImmuneConfusion => false;

    public virtual bool ImmuneFear => false;

    public virtual bool ImmuneFire => false;

    public virtual bool ImmuneLightning => false;

    public virtual bool ImmunePoison => false;

    public virtual bool ImmuneSleep => false;

    public virtual bool ImmuneStun => false;

    public virtual bool Invisible => false;

    public virtual bool KillBody => false;

    public virtual bool KillItem => false;

    public virtual bool KillWall => false;

    /// <summary>
    /// The level on which the monster is normally found.
    /// </summary>
    public abstract int LevelFound { get; }

    /// <summary>
    /// The monster has an aura of electricity around it.
    /// </summary>
    public virtual bool LightningAura => false;


    public virtual bool Male => false;

    /// <summary>
    /// The experience value for killing one of these.
    /// </summary>
    public abstract int Mexp { get; }

    public virtual bool MoveBody => false;

    public virtual bool Multiply => false;
    public virtual bool NeverAttack => false;

    public virtual bool NeverMove => false;

    public virtual bool Nonliving => false;

    /// <summary>
    /// The distance at which the monster notices the player.
    /// </summary>
    public abstract int NoticeRange { get; }

    public virtual bool OnlyDropGold => false;

    public virtual bool OnlyDropItem => false;

    public virtual bool OpenDoor => false;

    public virtual bool Orc => false;

    public virtual bool PassWall => false;

    public virtual bool Powerful => false;

    public virtual bool RandomMove25 => false;

    public virtual bool RandomMove50 => false;

    /// <summary>
    /// The rarity with which the monster is usually found.
    /// </summary>
    public abstract int Rarity { get; }

    public virtual bool Reflecting => false;

    public virtual bool Regenerate => false;

    public virtual bool ResistDisenchant => false;

    public virtual bool ResistNether => false;

    public virtual bool ResistNexus => false;

    public virtual bool ResistPlasma => false;

    public virtual bool ResistTeleport => false;

    public virtual bool ResistWater => false;

    public virtual bool Shapechanger => false;

    /// <summary>
    /// How deeply the monster sleeps.
    /// </summary>
    public abstract int Sleep { get; }

    /// <summary>
    /// Returns true, if the monster is smart.  When badly injured, the monster will want to prioritise spells that disable the
    /// player, summon help, or let it escape over spells that do direct damage.
    /// </summary>
    public virtual bool Smart => false;

    /// <summary>
    /// how fast the monster moves (110 = normal speed, higher is better).
    /// </summary>
    public abstract int Speed { get; }

    public virtual bool Stupid => false;

    public virtual bool TakeItem => false;

    public virtual bool Troll => false;

    public virtual bool Undead => false;

    public virtual bool Unique => false;

    public virtual bool WeirdMind => false;
    #endregion

    #region
    protected readonly Game Game;
    protected MonsterRace(Game game)
    {
        Game = game;
    }

    public string GetKey => Key;
    public void Bind()
    {
        Knowledge = new MonsterKnowledge(Game, this);
        int freqInate = (FreqInate == 0 ? 0 : 100 / FreqInate);
        int freqSpell = (FreqSpell == 0 ? 0 : 100 / FreqSpell);
        FrequencyChance = (freqInate + freqSpell) / 2;
        Level = (LevelFound < 0 || LevelFound > 100) ? 0 : LevelFound; // TODO: Something isn't right here.  

        // Bind the monster spell names.
        if (SpellNames != null)
        {
            foreach (string spellName in SpellNames)
            {
                Spells.Add(Game.SingletonRepository.Get<MonsterSpell>(spellName));
            }
        }

        // Bind the symbol.
        Symbol = Game.SingletonRepository.Get<Symbol>(SymbolName);

        // Bind the monster attacks.
        List<(Attack, AttackEffect?, int, int)> attackList = new();
        if (AttackDefinitions != null)
        {
            foreach ((string MethodName, string? EffectName, int Dice, int Sides) in AttackDefinitions)
            {
                Attack method = Game.SingletonRepository.Get<Attack>(MethodName);
                AttackEffect? attackEffect = null;
                if (EffectName != null)
                {
                    attackEffect = Game.SingletonRepository.Get<AttackEffect>(EffectName);
                }
                attackList.Add((method, attackEffect, Dice, Sides));
            }
        }
        Attacks = attackList.ToArray();
    }

    public MonsterSpellList Spells = new MonsterSpellList();
    public bool BreatheAcid => Spells.Contains(typeof(AcidBreatheBallMonsterSpell));
    public bool BreatheCold => Spells.Contains(typeof(ColdBreatheBallMonsterSpell));
    public bool BreatheFire => Spells.Contains(typeof(FireBreatheBallMonsterSpell));
    public bool BreatheLightning => Spells.Contains(typeof(LightningBreatheBallMonsterSpell));
    public bool BreathePoison => Spells.Contains(typeof(PoisonBreatheBallMonsterSpell));
    public bool BreatheChaos => Spells.Contains(typeof(ChaosBreatheBallMonsterSpell));
    public bool BreatheConfusion => Spells.Contains(typeof(ConfusionBreatheBallMonsterSpell));
    public bool BreatheDark => Spells.Contains(typeof(DarkBreatheBallMonsterSpell));
    public bool BreatheSound => Spells.Contains(typeof(SoundBreatheBallMonsterSpell));
    public bool BreatheForce => Spells.Contains(typeof(ForceBreatheBallMonsterSpell));
    public bool BreatheShards => Spells.Contains(typeof(ShardsBreatheBallMonsterSpell));
    public bool BreatheGravity => Spells.Contains(typeof(GravityBreatheBallMonsterSpell));
    public bool BreatheInertia => Spells.Contains(typeof(InertiaBreatheBallMonsterSpell));
    public bool BreatheTime => Spells.Contains(typeof(TimeBreatheBallMonsterSpell));
    public bool TeleportSelf => Spells.Contains(typeof(TeleportSelfMonsterSpell));

    public int CurNum;
    public bool Guardian;
    public bool OnlyGuardian;
    public int MaxNum;
    public MonsterKnowledge Knowledge;

    /// <summary>
    /// Returns a standard message note for a monster of either it 'dies' or is 'destroyed' based on whether
    /// or not the monster is already dead.  If it is already dead, a 'destroyed' message is returned and it 'dies'
    /// is returned for all living monsters.  Other variations are that dispel projectiles will dissolve and
    /// PSI will "collapses, a mindless husk".
    /// </summary>
    /// <param name="rPtr"></param>
    /// <returns></returns>
    public string DeathNote()
    {
        if (Demon || Undead || Cthuloid || Stupid || Nonliving || "Evg".Contains(Symbol.Character.ToString()))
        {
            return " is destroyed.";
        }
        return " dies.";
    }

    /// <summary>
    /// Returns the symbol to use for rendering.
    /// </summary>
    public Symbol Symbol { get; private set; }


    /// <summary>
    /// Returns all of the attacks that the monster can perform in a single round.  This property is bound from the AttackDefinitions
    /// during the bind phase.  If there are no attacks, the array will be empty.  Null is not supported.
    /// </summary>
    public (Attack Method, AttackEffect? Effect, int Dice, int Sides)[] Attacks { get; private set; }

    /// <summary>
    /// The number of hit points the monster has (click to update).
    /// </summary>
    public string HitPoints
    {
        get
        {
            if (ForceMaxHp)
            {
                return $"{Hdice}d{Hside} (max. {Hdice * Hside})";
            }
            return $"{Hdice}d{Hside} (avg. {(Hdice * Hside / 2) + (Hdice / 2)})";
        }
    }

    /// <summary>
    /// Represents a percentage chance (0-100) of successfully casting as spell.
    /// </summary>
    public int FrequencyChance { get; private set; }

    /// <summary>
    /// Returns the level at which the monster will appear.  This is typically same as LevelFound but Player and the NobodyGhost are moved to the town level.
    /// </summary>
    public int Level { get; private set; }

    /// <summary>
    /// Returns the index into the monster race array where the monster is.  Set just after construction.
    /// </summary>
    public int Index; // TODO: Needs to be removed. THERE IS NO WRITE.

    public int GetCoinType()
    {
        if (Symbol.Character == '$') // TODO: Hardcoding
        {
            if (FriendlyName.Contains(" copper ")) // TODO: Hardcoding
            {
                return 2;
            }
            if (FriendlyName.Contains(" silver ")) // TODO: Hardcoding
            {
                return 5;
            }
            if (FriendlyName.Contains(" gold ")) // TODO: Hardcoding
            {
                return 10;
            }
            if (FriendlyName.Contains(" mithril ")) // TODO: Hardcoding
            {
                return 16;
            }
            if (FriendlyName.Contains(" adamantite ")) // TODO: Hardcoding
            {
                return 17;
            }
            if (FriendlyName.StartsWith("Copper ")) // TODO: Hardcoding
            {
                return 2;
            }
            if (FriendlyName.StartsWith("Silver ")) // TODO: Hardcoding
            {
                return 5;
            }
            if (FriendlyName.StartsWith("Gold ")) // TODO: Hardcoding
            {
                return 10;
            }
            if (FriendlyName.StartsWith("Mithril ")) // TODO: Hardcoding
            {
                return 16;
            }
            if (FriendlyName.StartsWith("Adamantite ")) // TODO: Hardcoding
            {
                return 17;
            }
        }
        return 0;
    }

    public override string ToString()
    {
        return $"{FriendlyName} (lvl {Level})";
    }

    public string ToJson()
    {
        MonsterRaceGameConfiguration monsterRaceConfiguration = new()
        {
            // 102 Properties
            Key = Key,
            SpellNames = SpellNames,
            SymbolName = SymbolName,
            Color = Color,
            Animal = Animal,
            ArmorClass = ArmorClass,
            AttackDefinitions = AttackDefinitions,
            AttrAny = AttrAny,
            AttrClear = AttrClear,
            AttrMulti = AttrMulti,
            BashDoor = BashDoor,
            CharClear = CharClear,
            CharMulti = CharMulti,
            ColdBlood = ColdBlood,
            Cthuloid = Cthuloid,
            Demon = Demon,
            Description = Description,
            Dragon = Dragon,
            Drop_1D2 = Drop_1D2,
            Drop_2D2 = Drop_2D2,
            Drop_3D2 = Drop_3D2,
            Drop_4D2 = Drop_4D2,
            Drop60 = Drop60,
            Drop90 = Drop90,
            DropGood = DropGood,
            DropGreat = DropGreat,
            EldritchHorror = EldritchHorror,
            EmptyMind = EmptyMind,
            Escorted = Escorted,
            EscortsGroup = EscortsGroup,
            Evil = Evil,
            Female = Female,
            FireAura = FireAura,
            ForceMaxHp = ForceMaxHp,
            ForceSleep = ForceSleep,
            FreqInate = FreqInate,
            FreqSpell = FreqSpell,
            FriendlyName = FriendlyName,
            Friends = Friends,
            Giant = Giant,
            Good = Good,
            GreatOldOne = GreatOldOne,
            Hdice = Hdice,
            Hside = Hside,
            HurtByCold = HurtByCold,
            HurtByFire = HurtByFire,
            HurtByLight = HurtByLight,
            HurtByRock = HurtByRock,
            ImmuneAcid = ImmuneAcid,
            ImmuneCold = ImmuneCold,
            ImmuneConfusion = ImmuneConfusion,
            ImmuneFear = ImmuneFear,
            ImmuneFire = ImmuneFire,
            ImmuneLightning = ImmuneLightning,
            ImmunePoison = ImmunePoison,
            ImmuneSleep = ImmuneSleep,
            ImmuneStun = ImmuneStun,
            Invisible = Invisible,
            KillBody = KillBody,
            KillItem = KillItem,
            KillWall = KillWall,
            LevelFound = LevelFound,
            LightningAura = LightningAura,
            Male = Male,
            Mexp = Mexp,
            MoveBody = MoveBody,
            Multiply = Multiply,
            NeverAttack = NeverAttack,
            NeverMove = NeverMove,
            Nonliving = Nonliving,
            NoticeRange = NoticeRange,
            OnlyDropGold = OnlyDropGold,
            OnlyDropItem = OnlyDropItem,
            OpenDoor = OpenDoor,
            Orc = Orc,
            PassWall = PassWall,
            Powerful = Powerful,
            RandomMove25 = RandomMove25,
            RandomMove50 = RandomMove50,
            Rarity = Rarity,
            Reflecting = Reflecting,
            Regenerate = Regenerate,
            ResistDisenchant = ResistDisenchant,
            ResistNether = ResistNether,
            ResistNexus = ResistNexus,
            ResistPlasma = ResistPlasma,
            ResistTeleport = ResistTeleport,
            ResistWater = ResistWater,
            Shapechanger = Shapechanger,
            Sleep = Sleep,
            Smart = Smart,
            Speed = Speed,
            Stupid = Stupid,
            TakeItem = TakeItem,
            Troll = Troll,
            Undead = Undead,
            Unique = Unique,
            WeirdMind = WeirdMind
        };
        return JsonSerializer.Serialize(monsterRaceConfiguration, Game.GetJsonSerializerOptions());
    }
    #endregion

}