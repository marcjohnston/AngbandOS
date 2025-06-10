// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// 102 Properties
/// </remarks>
[Serializable]
internal class GenericMonsterRace : MonsterRace
{
    public GenericMonsterRace(Game game, MonsterRaceGameConfiguration monsterRaceGameConfiguration) : base(game)
    {
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

    public override string Key { get; }

    protected override string[]? SpellNames { get; } = null;

    /// <summary>
    /// Returns the key for the symbol to be used.  The actual Symbol object is bound to the Symbol property during the
    /// bind phase.
    /// </summary>
    protected override string SymbolName { get; }

    /// <summary>
    /// Returns a multiline version of the monster race that is shown to the player.  Defaults to the <see cref="FriendlyName"/>.  Word-breaks are encoded with a \n character.
    /// </summary>
    public override string? MultilineName { get; }

    /// <summary>
    /// The color to display the monster as.
    /// </summary>
    public override ColorEnum Color { get; } = ColorEnum.White;

    /// <summary>
    /// The monster is an animal.
    /// </summary>
    public override bool Animal { get; } = false;

    /// <summary>
    /// The monsters armor class.
    /// </summary>
    public override int ArmorClass { get; }

    /// <summary>
    /// Returns an array of the definitions for the attacks abilities of the monster; or null, if the monster cannot attack.  Returns
    /// null, by default.
    /// </summary>
    protected override (string, string?, int, int)[]? AttackDefinitions { get; } = null;

    /// <summary>
    /// The monster's color can be anything (if 'AttrMulti' is set).
    /// </summary>
    public override bool AttrAny { get; } = false;

    /// <summary>
    /// The monster is transparent.
    /// </summary>
    public override bool AttrClear { get; } = false;

    /// <summary>
    /// The monster changes color.
    /// </summary>
    public override bool AttrMulti { get; } = false;

    /// <summary>
    /// The monster can break open doors.
    /// </summary>
    public override bool BashDoor { get; } = false;

    /// <summary>
    /// The monster is never seen, even with see invisible.
    /// </summary>
    public override bool CharClear { get; } = false;

    /// <summary>
    /// The monster is changes shape randomly.
    /// </summary>
    public override bool CharMulti { get; } = false;

    public override bool ColdBlood { get; } = false;

    public override bool Cthuloid { get; } = false;


    public override bool Demon { get; } = false;

    /// <summary>
    /// The descriptive text.
    /// </summary>
    public override string Description { get; }

    public override bool Dragon { get; } = false;

    /// <summary>
    /// The monster drops 1d2 items.
    /// </summary>
    public override bool Drop_1D2 { get; } = false;

    /// <summary>
    /// The monster drops 2d2 items.
    /// </summary>
    public override bool Drop_2D2 { get; } = false;

    /// <summary>
    /// The monster drops 3d2 items.
    /// </summary>
    public override bool Drop_3D2 { get; } = false;

    /// <summary>
    /// The monster drops 4d2 items.
    /// </summary>
    public override bool Drop_4D2 { get; } = false;

    /// <summary>
    /// The monster drops an item 60% of the time.
    /// </summary>
    public override bool Drop60 { get; } = false;

    /// <summary>
    /// The monster drops an item 90% of the time.
    /// </summary>
    public override bool Drop90 { get; } = false;

    /// <summary>
    /// The monster drops good items.
    /// </summary>
    public override bool DropGood { get; } = false;

    /// <summary>
    /// The monster drops great items.
    /// </summary>
    public override bool DropGreat { get; } = false;

    public override bool EldritchHorror { get; } = false;

    public override bool EmptyMind { get; } = false;

    /// <summary>
    /// The monster comes with minions of the same character.
    /// </summary>
    public override bool Escorted { get; } = false;

    /// <summary>
    /// The monster's minions come in groups (this doesn't force minions if 'Escort' isn't set).
    /// </summary>
    public override bool EscortsGroup { get; } = false;

    public override bool Evil { get; } = false;

    /// <summary>
    /// The monster should use feminine pronouns.
    /// </summary>
    public override bool Female { get; } = false;

    /// <summary>
    /// The monster has an aura of fire around it.
    /// </summary>
    public override bool FireAura { get; } = false;

    /// The monster has maximum hit points.
    /// </summary>
    public override bool ForceMaxHp { get; } = false;

    /// <summary>
    /// The monster always starts asleep.
    /// </summary>
    public override bool ForceSleep { get; } = false;

    /// <summary>
    /// The 1-in-X frequency with which the monster uses special abilities.
    /// </summary>
    public override int FreqInate { get; }

    /// <summary>
    /// The 1-in-X frequency with which the monster uses spells.
    /// </summary>
    public override int FreqSpell { get; }

    /// <summary>
    /// The name that the game shows the player (may have duplicates).
    /// </summary>
    public override string FriendlyName { get; }

    /// <summary>
    /// The monster comes with friends of the same race.
    /// </summary>
    public override bool Friends { get; } = false;

    public override bool Giant { get; } = false;

    protected override string GoldItemFactoryBindingKey { get; } = nameof(LotOfGoldGoldItemFactory);
    public override bool Good { get; } = false;

    public override bool GreatOldOne { get; } = false;
    public override bool HasLegs { get; } = false;

    /// <summary>
    /// The number of hit dice the monster has.
    /// </summary>
    public override int Hdice { get; }

    /// <summary>
    /// The number of sides of the monster's hit dice.
    /// </summary>
    public override int Hside { get; }

    public override bool HurtByCold { get; } = false;

    public override bool HurtByFire { get; } = false;

    public override bool HurtByLight { get; } = false;

    public override bool HurtByRock { get; } = false;

    public override bool ImmuneAcid { get; } = false;

    public override bool ImmuneCold { get; } = false;

    public override bool ImmuneConfusion { get; } = false;

    public override bool ImmuneFear { get; } = false;

    public override bool ImmuneFire { get; } = false;

    public override bool ImmuneLightning { get; } = false;

    public override bool ImmunePoison { get; } = false;

    public override bool ImmuneSleep { get; } = false;

    public override bool ImmuneStun { get; } = false;

    public override bool Invisible { get; } = false;

    public override bool KillBody { get; } = false;

    public override bool KillItem { get; } = false;

    public override bool KillWall { get; } = false;

    /// <summary>
    /// The level on which the monster is normally found.
    /// </summary>
    public override int LevelFound { get; }

    /// <summary>
    /// The monster has an aura of electricity around it.
    /// </summary>
    public override bool LightningAura { get; } = false;


    public override bool Male { get; } = false;

    /// <summary>
    /// The experience value for killing one of these.
    /// </summary>
    public override int Mexp { get; }

    public override bool MoveBody { get; } = false;

    public override bool Multiply { get; } = false;
    public override bool NeverAttack { get; } = false;

    public override bool NeverMove { get; } = false;

    public override bool Nonliving { get; } = false;

    /// <summary>
    /// The distance at which the monster notices the player.
    /// </summary>
    public override int NoticeRange { get; }

    public override bool OnlyDropGold { get; } = false;

    public override bool OnlyDropItem { get; } = false;

    public override bool OpenDoor { get; } = false;

    public override bool Orc { get; } = false;

    public override bool PassWall { get; } = false;

    public override bool Powerful { get; } = false;

    public override bool RandomMove25 { get; } = false;

    public override bool RandomMove50 { get; } = false;

    public override bool Reaver { get; } = false;
    /// <summary>
    /// The rarity with which the monster is usually found.
    /// </summary>
    public override int Rarity { get; }

    public override bool Reflecting { get; } = false;

    public override bool Regenerate { get; } = false;

    public override bool ResistDisenchant { get; } = false;

    public override bool ResistNether { get; } = false;

    public override bool ResistNexus { get; } = false;

    public override bool ResistPlasma { get; } = false;

    public override bool ResistTeleport { get; } = false;

    public override bool ResistWater { get; } = false;

    public override bool Shapechanger { get; } = false;

    /// <summary>
    /// How deeply the monster sleeps.
    /// </summary>
    public override int Sleep { get; }

    /// <summary>
    /// Returns true, if the monster is smart.  When badly injured, the monster will want to prioritise spells that disable the
    /// player, summon help, or let it escape over spells that do direct damage.
    /// </summary>
    public override bool Smart { get; } = false;

    /// <summary>
    /// how fast the monster moves (110 = normal speed, higher is better).
    /// </summary>
    public override int Speed { get; }

    public override bool Stupid { get; } = false;

    public override bool TakeItem { get; } = false;

    public override bool Troll { get; } = false;

    public override bool Undead { get; } = false;

    public override bool Unique { get; } = false;

    public override bool WeirdMind { get; } = false;
}
