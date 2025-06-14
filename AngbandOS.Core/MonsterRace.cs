// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class MonsterRace : IMonsterCharacteristics, IGetKey
{
    #region 102 Serialized Members

    public virtual string Key { get; }

    protected virtual string[]? SpellNames { get; } = null;

    /// <summary>
    /// Returns the key for the symbol to be used.  The actual Symbol object is bound to the Symbol property during the
    /// bind phase.
    /// </summary>
    protected virtual string SymbolName { get; }

    /// <summary>
    /// The color to display the monster as.
    /// </summary>
    public virtual ColorEnum Color { get; } = ColorEnum.White;

    /// <summary>
    /// The monster is an animal.
    /// </summary>
    public virtual bool Animal { get; } = false;

    /// <summary>
    /// The monsters armor class.
    /// </summary>
    public virtual int ArmorClass { get; }

    /// <summary>
    /// Returns an array of the definitions for the attacks abilities of the monster; or null, if the monster cannot attack.  Returns
    /// null, by default.
    /// </summary>
    protected virtual (string MethodName, string? EffectName, int Dice, int Sides)[]? AttackDefinitions { get; } = null;

    /// <summary>
    /// The monster's color can be anything (if 'AttrMulti' is set).
    /// </summary>
    public virtual bool AttrAny { get; } = false;

    /// <summary>
    /// The monster is transparent.
    /// </summary>
    public virtual bool AttrClear { get; } = false;

    /// <summary>
    /// The monster changes color.
    /// </summary>
    public virtual bool AttrMulti { get; } = false;

    /// <summary>
    /// The monster can break open doors.
    /// </summary>
    public virtual bool BashDoor { get; } = false;

    /// <summary>
    /// The monster is never seen, even with see invisible.
    /// </summary>
    public virtual bool CharClear { get; } = false;

    /// <summary>
    /// The monster is changes shape randomly.
    /// </summary>
    public virtual bool CharMulti { get; } = false;

    public virtual bool ColdBlood { get; } = false;

    public virtual bool Cthuloid { get; } = false;


    public virtual bool Demon { get; } = false;

    /// <summary>
    /// The descriptive text.
    /// </summary>
    public virtual string Description { get; }

    public virtual bool Dragon { get; } = false;

    /// <summary>
    /// The monster drops 1d2 items.
    /// </summary>
    public virtual bool Drop_1D2 { get; } = false;

    /// <summary>
    /// The monster drops 2d2 items.
    /// </summary>
    public virtual bool Drop_2D2 { get; } = false;

    /// <summary>
    /// The monster drops 3d2 items.
    /// </summary>
    public virtual bool Drop_3D2 { get; } = false;

    /// <summary>
    /// The monster drops 4d2 items.
    /// </summary>
    public virtual bool Drop_4D2 { get; } = false;

    /// <summary>
    /// The monster drops an item 60% of the time.
    /// </summary>
    public virtual bool Drop60 { get; } = false;

    /// <summary>
    /// The monster drops an item 90% of the time.
    /// </summary>
    public virtual bool Drop90 { get; } = false;

    /// <summary>
    /// The monster drops good items.
    /// </summary>
    public virtual bool DropGood { get; } = false;

    /// <summary>
    /// The monster drops great items.
    /// </summary>
    public virtual bool DropGreat { get; } = false;

    public virtual bool EldritchHorror { get; } = false;

    public virtual bool EmptyMind { get; } = false;

    /// <summary>
    /// The monster comes with minions of the same character.
    /// </summary>
    public virtual bool Escorted { get; } = false;

    /// <summary>
    /// The monster's minions come in groups (this doesn't force minions if 'Escort' isn't set).
    /// </summary>
    public virtual bool EscortsGroup { get; } = false;

    public virtual bool Evil { get; } = false;

    /// <summary>
    /// The monster should use feminine pronouns.
    /// </summary>
    public virtual bool Female { get; } = false;

    /// <summary>
    /// The monster has an aura of fire around it.
    /// </summary>
    public virtual bool FireAura { get; } = false;

    /// The monster has maximum hit points.
    /// </summary>
    public virtual bool ForceMaxHp { get; } = false;

    /// <summary>
    /// The monster always starts asleep.
    /// </summary>
    public virtual bool ForceSleep { get; } = false;

    /// <summary>
    /// The 1-in-X frequency with which the monster uses special abilities.
    /// </summary>
    public virtual int FreqInate { get; }

    /// <summary>
    /// The 1-in-X frequency with which the monster uses spells.
    /// </summary>
    public virtual int FreqSpell { get; }

    /// <summary>
    /// Returns the full name of the monster race that is shown to the player.  Duplicate names is supported.
    /// </summary>
    public virtual string FriendlyName { get; }

    /// <summary>
    /// Returns a multiline version of the monster race that is shown to the player.  Returns null, if the <see cref="FriendlyName"/> should be used.  Word-breaks
    /// are encoded with a \n character.
    /// </summary>
    public virtual string? MultilineName { get; } = null;

    /// <summary>
    /// The monster comes with friends of the same race.
    /// </summary>
    public virtual bool Friends { get; } = false;

    public virtual bool Giant { get; } = false;

    public virtual bool Good { get; } = false;

    public virtual bool GreatOldOne { get; } = false;

    /// <summary>
    /// The number of hit dice the monster has.
    /// </summary>
    public virtual int Hdice { get; }

    /// <summary>
    /// The number of sides of the monster's hit dice.
    /// </summary>
    public virtual int Hside { get; }

    public virtual bool HurtByCold { get; } = false;

    public virtual bool HurtByFire { get; } = false;

    public virtual bool HurtByLight { get; } = false;

    public virtual bool HurtByRock { get; } = false;

    public virtual bool ImmuneAcid { get; } = false;

    public virtual bool ImmuneCold { get; } = false;

    public virtual bool ImmuneConfusion { get; } = false;

    public virtual bool ImmuneFear { get; } = false;

    public virtual bool ImmuneFire { get; } = false;

    public virtual bool ImmuneLightning { get; } = false;

    public virtual bool ImmunePoison { get; } = false;

    public virtual bool ImmuneSleep { get; } = false;

    public virtual bool ImmuneStun { get; } = false;

    public virtual bool Invisible { get; } = false;

    public virtual bool KillBody { get; } = false;

    public virtual bool KillItem { get; } = false;

    public virtual bool KillWall { get; } = false;

    /// <summary>
    /// The level on which the monster is normally found.
    /// </summary>
    public virtual int LevelFound { get; }

    /// <summary>
    /// The monster has an aura of electricity around it.
    /// </summary>
    public virtual bool LightningAura { get; } = false;


    public virtual bool Male { get; } = false;

    /// <summary>
    /// The experience value for killing one of these.
    /// </summary>
    public virtual int Mexp { get; }

    public virtual bool MoveBody { get; } = false;

    public virtual bool Multiply { get; } = false;
    public virtual bool NeverAttack { get; } = false;

    public virtual bool NeverMove { get; } = false;

    public virtual bool Nonliving { get; } = false;

    /// <summary>
    /// The distance at which the monster notices the player.
    /// </summary>
    public virtual int NoticeRange { get; }

    public virtual bool OnlyDropGold { get; } = false;

    public virtual bool OnlyDropItem { get; } = false;

    public virtual bool OpenDoor { get; } = false;

    public virtual bool Orc { get; } = false;

    public virtual bool PassWall { get; } = false;

    public virtual bool Powerful { get; } = false;

    public virtual bool RandomMove25 { get; } = false;

    public virtual bool RandomMove50 { get; } = false;

    /// <summary>
    /// The rarity with which the monster is usually found.
    /// </summary>
    public virtual int Rarity { get; }
    public virtual bool Reaver { get; } = false;

    public virtual bool Reflecting { get; } = false;

    public virtual bool Regenerate { get; } = false;

    public virtual bool ResistDisenchant { get; } = false;

    public virtual bool ResistNether { get; } = false;

    public virtual bool ResistNexus { get; } = false;

    public virtual bool ResistPlasma { get; } = false;

    public virtual bool ResistTeleport { get; } = false;

    public virtual bool ResistWater { get; } = false;

    public virtual bool Shapechanger { get; } = false;

    /// <summary>
    /// How deeply the monster sleeps.
    /// </summary>
    public virtual int Sleep { get; }

    /// <summary>
    /// Returns true, if the monster is smart.  When badly injured, the monster will want to prioritise spells that disable the
    /// player, summon help, or let it escape over spells that do direct damage.
    /// </summary>
    public virtual bool Smart { get; } = false;

    /// <summary>
    /// how fast the monster moves (110 = normal speed, higher is better).
    /// </summary>
    public virtual int Speed { get; }

    public virtual bool Stupid { get; } = false;

    public virtual bool TakeItem { get; } = false;

    public virtual bool Troll { get; } = false;

    public virtual bool Undead { get; } = false;

    public virtual bool Unique { get; } = false;

    public virtual bool WeirdMind { get; } = false;

    protected virtual string GoldItemFactoryBindingKey { get; } = nameof(LotOfGoldGoldItemFactory);

    /// <summary>
    /// Returns true, if the monster has legs.  Monsters that have legs are susceptible to martial arts ankle kicks that will slow the monster.  Returns false, by default.
    /// </summary>
    public virtual bool HasLegs { get; } = false;
    #endregion

    #region
    protected readonly Game Game;
    public string[] GetMultilineName => Game.ConvertToMultiline(MultilineName ?? FriendlyName);

    public MonsterRace(Game game, MonsterRaceGameConfiguration monsterRaceGameConfiguration)
    {
        Game = game;
        // 102 Properties
        Key = monsterRaceGameConfiguration.Key ?? monsterRaceGameConfiguration.GetType().Name;
        SpellNames = monsterRaceGameConfiguration.SpellNames;
        SymbolName = monsterRaceGameConfiguration.SymbolName;
        MultilineName = monsterRaceGameConfiguration.MultilineName;
        Color = monsterRaceGameConfiguration.Color;
        Animal = monsterRaceGameConfiguration.Animal;
        ArmorClass = monsterRaceGameConfiguration.ArmorClass;
        AttackDefinitions = monsterRaceGameConfiguration.AttackDefinitions;
        AttrAny = monsterRaceGameConfiguration.AttrAny;
        AttrClear = monsterRaceGameConfiguration.AttrClear;
        AttrMulti = monsterRaceGameConfiguration.AttrMulti;
        BashDoor = monsterRaceGameConfiguration.BashDoor;
        CharClear = monsterRaceGameConfiguration.CharClear;
        CharMulti = monsterRaceGameConfiguration.CharMulti;
        ColdBlood = monsterRaceGameConfiguration.ColdBlood;
        Cthuloid = monsterRaceGameConfiguration.Cthuloid;
        Demon = monsterRaceGameConfiguration.Demon;
        Description = monsterRaceGameConfiguration.Description;
        Dragon = monsterRaceGameConfiguration.Dragon;
        Drop_1D2 = monsterRaceGameConfiguration.Drop_1D2;
        Drop_2D2 = monsterRaceGameConfiguration.Drop_2D2;
        Drop_3D2 = monsterRaceGameConfiguration.Drop_3D2;
        Drop_4D2 = monsterRaceGameConfiguration.Drop_4D2;
        Drop60 = monsterRaceGameConfiguration.Drop60;
        Drop90 = monsterRaceGameConfiguration.Drop90;
        DropGood = monsterRaceGameConfiguration.DropGood;
        DropGreat = monsterRaceGameConfiguration.DropGreat;
        EldritchHorror = monsterRaceGameConfiguration.EldritchHorror;
        EmptyMind = monsterRaceGameConfiguration.EmptyMind;
        Escorted = monsterRaceGameConfiguration.Escorted;
        EscortsGroup = monsterRaceGameConfiguration.EscortsGroup;
        Evil = monsterRaceGameConfiguration.Evil;
        Female = monsterRaceGameConfiguration.Female;
        FireAura = monsterRaceGameConfiguration.FireAura;
        ForceMaxHp = monsterRaceGameConfiguration.ForceMaxHp;
        ForceSleep = monsterRaceGameConfiguration.ForceSleep;
        FreqInate = monsterRaceGameConfiguration.FreqInate;
        FreqSpell = monsterRaceGameConfiguration.FreqSpell;
        FriendlyName = monsterRaceGameConfiguration.FriendlyName;
        Friends = monsterRaceGameConfiguration.Friends;
        Giant = monsterRaceGameConfiguration.Giant;
        GoldItemFactoryBindingKey = monsterRaceGameConfiguration.GoldItemFactoryBindingKey;
        Good = monsterRaceGameConfiguration.Good;
        GreatOldOne = monsterRaceGameConfiguration.GreatOldOne;
        HasLegs = monsterRaceGameConfiguration.HasLegs;
        Hdice = monsterRaceGameConfiguration.Hdice;
        Hside = monsterRaceGameConfiguration.Hside;
        HurtByCold = monsterRaceGameConfiguration.HurtByCold;
        HurtByFire = monsterRaceGameConfiguration.HurtByFire;
        HurtByLight = monsterRaceGameConfiguration.HurtByLight;
        HurtByRock = monsterRaceGameConfiguration.HurtByRock;
        ImmuneAcid = monsterRaceGameConfiguration.ImmuneAcid;
        ImmuneCold = monsterRaceGameConfiguration.ImmuneCold;
        ImmuneConfusion = monsterRaceGameConfiguration.ImmuneConfusion;
        ImmuneFear = monsterRaceGameConfiguration.ImmuneFear;
        ImmuneFire = monsterRaceGameConfiguration.ImmuneFire;
        ImmuneLightning = monsterRaceGameConfiguration.ImmuneLightning;
        ImmunePoison = monsterRaceGameConfiguration.ImmunePoison;
        ImmuneSleep = monsterRaceGameConfiguration.ImmuneSleep;
        ImmuneStun = monsterRaceGameConfiguration.ImmuneStun;
        Invisible = monsterRaceGameConfiguration.Invisible;
        KillBody = monsterRaceGameConfiguration.KillBody;
        KillItem = monsterRaceGameConfiguration.KillItem;
        KillWall = monsterRaceGameConfiguration.KillWall;
        LevelFound = monsterRaceGameConfiguration.LevelFound;
        LightningAura = monsterRaceGameConfiguration.LightningAura;
        Male = monsterRaceGameConfiguration.Male;
        Mexp = monsterRaceGameConfiguration.Mexp;
        MoveBody = monsterRaceGameConfiguration.MoveBody;
        Multiply = monsterRaceGameConfiguration.Multiply;
        NeverAttack = monsterRaceGameConfiguration.NeverAttack;
        NeverMove = monsterRaceGameConfiguration.NeverMove;
        Nonliving = monsterRaceGameConfiguration.Nonliving;
        NoticeRange = monsterRaceGameConfiguration.NoticeRange;
        OnlyDropGold = monsterRaceGameConfiguration.OnlyDropGold;
        OnlyDropItem = monsterRaceGameConfiguration.OnlyDropItem;
        OpenDoor = monsterRaceGameConfiguration.OpenDoor;
        Orc = monsterRaceGameConfiguration.Orc;
        PassWall = monsterRaceGameConfiguration.PassWall;
        Powerful = monsterRaceGameConfiguration.Powerful;
        RandomMove25 = monsterRaceGameConfiguration.RandomMove25;
        RandomMove50 = monsterRaceGameConfiguration.RandomMove50;
        Rarity = monsterRaceGameConfiguration.Rarity;
        Reaver = monsterRaceGameConfiguration.Reaver;
        Reflecting = monsterRaceGameConfiguration.Reflecting;
        Regenerate = monsterRaceGameConfiguration.Regenerate;
        ResistDisenchant = monsterRaceGameConfiguration.ResistDisenchant;
        ResistNether = monsterRaceGameConfiguration.ResistNether;
        ResistNexus = monsterRaceGameConfiguration.ResistNexus;
        ResistPlasma = monsterRaceGameConfiguration.ResistPlasma;
        ResistTeleport = monsterRaceGameConfiguration.ResistTeleport;
        ResistWater = monsterRaceGameConfiguration.ResistWater;
        Shapechanger = monsterRaceGameConfiguration.Shapechanger;
        Sleep = monsterRaceGameConfiguration.Sleep;
        Smart = monsterRaceGameConfiguration.Smart;
        Speed = monsterRaceGameConfiguration.Speed;
        Stupid = monsterRaceGameConfiguration.Stupid;
        TakeItem = monsterRaceGameConfiguration.TakeItem;
        Troll = monsterRaceGameConfiguration.Troll;
        Undead = monsterRaceGameConfiguration.Undead;
        Unique = monsterRaceGameConfiguration.Unique;
        WeirdMind = monsterRaceGameConfiguration.WeirdMind;
    }

    public string GetKey => Key;
    public void Bind()
    {
        // We need to initialize the monster indexes.
        // TODO: The Index should be removed.
        for (int i = 0; i < Game.SingletonRepository.Count<MonsterRace>(); i++)
        {
            MonsterRace monsterRace = Game.SingletonRepository.Get<MonsterRace>(i);
            monsterRace.Index = i;
        }

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

        GoldItemFactory = Game.SingletonRepository.Get<ItemFactory>(GoldItemFactoryBindingKey);
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
    [Obsolete("Index will be removed.")]
    public int Index { get; private set; }

    public ItemFactory GoldItemFactory { get; private set; }

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
            GoldItemFactoryBindingKey = GoldItemFactoryBindingKey,
            Good = Good,
            GreatOldOne = GreatOldOne,
            HasLegs = HasLegs,
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
            Reaver = Reaver,
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