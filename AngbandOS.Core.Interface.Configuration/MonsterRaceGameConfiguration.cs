// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// 102 Properties
/// </remarks>
[Serializable]
public class MonsterRaceGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    /// <foreign-collection-name>MonsterSpells</foreign-collection-name>
    public virtual string[]? SpellNames { get; set; } = null;

    /// <summary>
    /// Returns a multiline version of the monster race that is shown to the player.  Defaults to the <see cref="FriendlyName"/>.  Word-breaks are encoded with a \n character.
    /// </summary>
    public virtual string? MultilineName { get; set; }

    /// <summary>
    /// Returns the key for the symbol to be used.  The actual Symbol object is bound to the Symbol property during the
    /// bind phase.
    /// </summary>
    /// <foreign-collection-name>Symbols</foreign-collection-name>
    public virtual string SymbolName { get; set; }

    /// <summary>
    /// The color to display the monster as.
    /// </summary>
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    /// <summary>
    /// The monster is an animal.
    /// </summary>
    public virtual bool Animal { get; set; } = false;

    /// <summary>
    /// The monsters armor class.
    /// </summary>
    public virtual int ArmorClass { get; set; }

    /// <summary>
    /// Returns an array of the definitions for the attacks abilities of the monster; or null, if the monster cannot attack.  Returns
    /// null, by default.
    /// </summary>
    /// <returns>
    /// MethodName:description The name of the attack method.
    /// MethodName:foreign-collection-name: Attacks
    /// EffectName:description: The name of the attach effect.
    /// Dice:description: The number of dice.
    /// Sides:description: The number of sides on the dice.
    /// </returns>
    public virtual (string MethodName, string? EffectName, int Dice, int Sides)[]? AttackDefinitions { get; set; } = null;

    /// <summary>
    /// The monster's color can be anything (if 'AttrMulti' is set).
    /// </summary>
    public virtual bool AttrAny { get; set; } = false;

    /// <summary>
    /// The monster is transparent.
    /// </summary>
    public virtual bool AttrClear { get; set; } = false;

    /// <summary>
    /// The monster changes color.
    /// </summary>
    public virtual bool AttrMulti { get; set; } = false;

    /// <summary>
    /// The monster can break open doors.
    /// </summary>
    public virtual bool BashDoor { get; set; } = false;

    /// <summary>
    /// The monster is never seen, even with see invisible.
    /// </summary>
    public virtual bool CharClear { get; set; } = false;

    /// <summary>
    /// The monster is changes shape randomly.
    /// </summary>
    public virtual bool CharMulti { get; set; } = false;

    public virtual bool ColdBlood { get; set; } = false;

    public virtual bool Cthuloid { get; set; } = false;


    public virtual bool Demon { get; set; } = false;

    /// <summary>
    /// The descriptive text.
    /// </summary>
    public virtual string Description { get; set; }

    public virtual bool Dragon { get; set; } = false;

    /// <summary>
    /// The monster drops 1d2 items.
    /// </summary>
    public virtual bool Drop_1D2 { get; set; } = false;

    /// <summary>
    /// The monster drops 2d2 items.
    /// </summary>
    public virtual bool Drop_2D2 { get; set; } = false;

    /// <summary>
    /// The monster drops 3d2 items.
    /// </summary>
    public virtual bool Drop_3D2 { get; set; } = false;

    /// <summary>
    /// The monster drops 4d2 items.
    /// </summary>
    public virtual bool Drop_4D2 { get; set; } = false;

    /// <summary>
    /// The monster drops an item 60% of the time.
    /// </summary>
    public virtual bool Drop60 { get; set; } = false;

    /// <summary>
    /// The monster drops an item 90% of the time.
    /// </summary>
    public virtual bool Drop90 { get; set; } = false;

    /// <summary>
    /// The monster drops good items.
    /// </summary>
    public virtual bool DropGood { get; set; } = false;

    /// <summary>
    /// The monster drops great items.
    /// </summary>
    public virtual bool DropGreat { get; set; } = false;

    public virtual bool EldritchHorror { get; set; } = false;

    public virtual bool EmptyMind { get; set; } = false;

    /// <summary>
    /// The monster comes with minions of the same character.
    /// </summary>
    public virtual bool Escorted { get; set; } = false;

    /// <summary>
    /// The monster's minions come in groups (this doesn't force minions if 'Escort' isn't set).
    /// </summary>
    public virtual bool EscortsGroup { get; set; } = false;

    public virtual bool Evil { get; set; } = false;

    /// <summary>
    /// The monster should use feminine pronouns.
    /// </summary>
    public virtual bool Female { get; set; } = false;

    /// <summary>
    /// The monster has an aura of fire around it.
    /// </summary>
    public virtual bool FireAura { get; set; } = false;

    /// The monster has maximum hit points.
    /// </summary>
    public virtual bool ForceMaxHp { get; set; } = false;

    /// <summary>
    /// The monster always starts asleep.
    /// </summary>
    public virtual bool ForceSleep { get; set; } = false;

    /// <summary>
    /// The 1-in-X frequency with which the monster uses special abilities.
    /// </summary>
    public virtual int FreqInate { get; set; }

    /// <summary>
    /// The 1-in-X frequency with which the monster uses spells.
    /// </summary>
    public virtual int FreqSpell { get; set; }

    /// <summary>
    /// The name that the game shows the player (may have duplicates).
    /// </summary>
    public virtual string FriendlyName { get; set; }

    /// <summary>
    /// The monster comes with friends of the same race.
    /// </summary>
    public virtual bool Friends { get; set; } = false;

    public virtual bool Giant { get; set; } = false;
    public virtual string GoldItemFactoryBindingKey { get; set; }

    public virtual bool Good { get; set; } = false;

    public virtual bool GreatOldOne { get; set; } = false;
    public virtual bool HasLegs { get; set; } = false;

    /// <summary>
    /// The number of hit dice the monster has.
    /// </summary>
    public virtual int Hdice { get; set; }

    /// <summary>
    /// The number of sides of the monster's hit dice.
    /// </summary>
    public virtual int Hside { get; set; }

    public virtual bool HurtByCold { get; set; } = false;

    public virtual bool HurtByFire { get; set; } = false;

    public virtual bool HurtByLight { get; set; } = false;

    public virtual bool HurtByRock { get; set; } = false;

    public virtual bool ImmuneAcid { get; set; } = false;

    public virtual bool ImmuneCold { get; set; } = false;

    public virtual bool ImmuneConfusion { get; set; } = false;

    public virtual bool ImmuneFear { get; set; } = false;

    public virtual bool ImmuneFire { get; set; } = false;

    public virtual bool ImmuneLightning { get; set; } = false;

    public virtual bool ImmunePoison { get; set; } = false;

    public virtual bool ImmuneSleep { get; set; } = false;

    public virtual bool ImmuneStun { get; set; } = false;

    public virtual bool Invisible { get; set; } = false;

    public virtual bool KillBody { get; set; } = false;

    public virtual bool KillItem { get; set; } = false;

    public virtual bool KillWall { get; set; } = false;

    /// <summary>
    /// The level on which the monster is normally found.
    /// </summary>
    public virtual int LevelFound { get; set; }

    /// <summary>
    /// The monster has an aura of electricity around it.
    /// </summary>
    public virtual bool LightningAura { get; set; } = false;


    public virtual bool Male { get; set; } = false;

    /// <summary>
    /// The experience value for killing one of these.
    /// </summary>
    public virtual int Mexp { get; set; }

    public virtual bool MoveBody { get; set; } = false;

    public virtual bool Multiply { get; set; } = false;
    public virtual bool NeverAttack { get; set; } = false;

    public virtual bool NeverMove { get; set; } = false;

    public virtual bool Nonliving { get; set; } = false;

    /// <summary>
    /// The distance at which the monster notices the player.
    /// </summary>
    public virtual int NoticeRange { get; set; }

    public virtual bool OnlyDropGold { get; set; } = false;

    public virtual bool OnlyDropItem { get; set; } = false;

    public virtual bool OpenDoor { get; set; } = false;

    public virtual bool Orc { get; set; } = false;

    public virtual bool PassWall { get; set; } = false;

    public virtual bool Powerful { get; set; } = false;

    public virtual bool RandomMove25 { get; set; } = false;

    public virtual bool RandomMove50 { get; set; } = false;

    /// <summary>
    /// The rarity with which the monster is usually found.
    /// </summary>
    public virtual int Rarity { get; set; }

    public virtual bool Reflecting { get; set; } = false;

    public virtual bool Reaver { get; set; } = false;
    public virtual bool Regenerate { get; set; } = false;

    public virtual bool ResistDisenchant { get; set; } = false;

    public virtual bool ResistNether { get; set; } = false;

    public virtual bool ResistNexus { get; set; } = false;

    public virtual bool ResistPlasma { get; set; } = false;

    public virtual bool ResistTeleport { get; set; } = false;

    public virtual bool ResistWater { get; set; } = false;

    public virtual bool Shapechanger { get; set; } = false;

    /// <summary>
    /// How deeply the monster sleeps.
    /// </summary>
    public virtual int Sleep { get; set; }

    /// <summary>
    /// Returns true, if the monster is smart.  When badly injured, the monster will want to prioritise spells that disable the
    /// player, summon help, or let it escape over spells that do direct damage.
    /// </summary>
    public virtual bool Smart { get; set; } = false;

    /// <summary>
    /// how fast the monster moves (110 = normal speed, higher is better).
    /// </summary>
    public virtual int Speed { get; set; }

    public virtual bool Stupid { get; set; } = false;

    public virtual bool TakeItem { get; set; } = false;

    public virtual bool Troll { get; set; } = false;

    public virtual bool Undead { get; set; } = false;

    public virtual bool Unique { get; set; } = false;

    public virtual bool WeirdMind { get; set; } = false;

    //public bool IsValid()
    //{
    //    // 100 Properties Required
    //    if (Key == null ||
    //        SymbolName == null ||
    //        Color == null ||
    //        Animal == null ||
    //        ArmorClass == null ||
    //        AttrAny == null ||
    //        AttrClear == null ||
    //        AttrMulti == null ||
    //        BashDoor == null ||
    //        CharClear == null ||
    //        CharMulti == null ||
    //        ColdBlood == null ||
    //        Cthuloid == null ||
    //        Demon == null ||
    //        Description == null ||
    //        Dragon == null ||
    //        Drop_1D2 == null ||
    //        Drop_2D2 == null ||
    //        Drop_3D2 == null ||
    //        Drop_4D2 == null ||
    //        Drop60 == null ||
    //        Drop90 == null ||
    //        DropGood == null ||
    //        DropGreat == null ||
    //        EldritchHorror == null ||
    //        EmptyMind == null ||
    //        Escorted == null ||
    //        EscortsGroup == null ||
    //        Evil == null ||
    //        Female == null ||
    //        FireAura == null ||
    //        ForceMaxHp == null ||
    //        ForceSleep == null ||
    //        FreqInate == null ||
    //        FreqSpell == null ||
    //        FriendlyName == null ||
    //        Friends == null ||
    //        Giant == null ||
    //        Good == null ||
    //        GreatOldOne == null ||
    //        Hdice == null ||
    //        Hside == null ||
    //        HurtByCold == null ||
    //        HurtByFire == null ||
    //        HurtByLight == null ||
    //        HurtByRock == null ||
    //        ImmuneAcid == null ||
    //        ImmuneCold == null ||
    //        ImmuneConfusion == null ||
    //        ImmuneFear == null ||
    //        ImmuneFire == null ||
    //        ImmuneLightning == null ||
    //        ImmunePoison == null ||
    //        ImmuneSleep == null ||
    //        ImmuneStun == null ||
    //        Invisible == null ||
    //        KillBody == null ||
    //        KillItem == null ||
    //        KillWall == null ||
    //        LevelFound == null ||
    //        LightningAura == null ||
    //        Male == null ||
    //        Mexp == null ||
    //        MoveBody == null ||
    //        Multiply == null ||
    //        NeverAttack == null ||
    //        NeverMove == null ||
    //        Nonliving == null ||
    //        NoticeRange == null ||
    //        OnlyDropGold == null ||
    //        OnlyDropItem == null ||
    //        OpenDoor == null ||
    //        Orc == null ||
    //        PassWall == null ||
    //        Powerful == null ||
    //        RandomMove25 == null ||
    //        RandomMove50 == null ||
    //        Rarity == null ||
    //        Reflecting == null ||
    //        Regenerate == null ||
    //        ResistDisenchant == null ||
    //        ResistNether == null ||
    //        ResistNexus == null ||
    //        ResistPlasma == null ||
    //        ResistTeleport == null ||
    //        ResistWater == null ||
    //        Shapechanger == null ||
    //        Sleep == null ||
    //        Smart == null ||
    //        Speed == null ||
    //        Stupid == null ||
    //        TakeItem == null ||
    //        Troll == null ||
    //        Undead == null ||
    //        Unique == null ||
    //        WeirdMind == null)
    //    {
    //        return false;
    //    }

    //    if (AttackDefinitions != null && AttackDefinitions.Any(_attackDefinition => _attackDefinition.MethodName == null || _attackDefinition.Dice == null || _attackDefinition.Sides == null))
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}
