// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Monster Race",
    EntityNoun = "monster race")]
public class MonsterRaceGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Can Teleport Self",
        Summary = "Determines whether the monster can teleport itself.",
        DataType = "bool")]
    public virtual bool CanTeleportSelf { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Spell Names",
        Summary = "Specifies the monster spell binding keys available to the monster race.",
        DataType = "string[]?")]
    public virtual string[]? SpellNames { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Multiline Name",
        Summary = "Specifies the multiline name displayed to the player. When null, the friendly name is used.",
        DataType = "string?")]
    public virtual string? MultilineName { get; set; }

    [ConfigurationMetadata(
        Title = "Symbol Name",
        Summary = "Specifies the binding key for the symbol used to render the monster.",
        DataType = "string")]
    public virtual string SymbolName { get; set; }

    [ConfigurationMetadata(
        Title = "Color",
        Summary = "Specifies the color used to display the monster.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationMetadata(
        Title = "Animal",
        Summary = "Determines whether the monster is an animal.",
        DataType = "bool")]
    public virtual bool Animal { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Armor Class",
        Summary = "Specifies the monster's armor class.",
        DataType = "int")]
    public virtual int ArmorClass { get; set; }

    [ConfigurationTupleItem("MethodName", Title = "Method Name")]
    [ConfigurationTupleItem("EffectName", Title = "Effect Name")]
    [ConfigurationTupleItem("Dice", Title = "Dice")]
    [ConfigurationTupleItem("Sides", Title = "Sides")]
    [ConfigurationMetadata(
        Title = "Attack Definitions",
        Summary = "Specifies the attack definitions for the monster. When null, the monster cannot attack.",
        DataType = "(string MethodName, string? EffectName, int Dice, int Sides)[]?")]
    public virtual (string MethodName, string? EffectName, int Dice, int Sides)[]? AttackDefinitions { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Attribute Any",
        Summary = "Determines whether the monster can use any color when its color changes.",
        DataType = "bool")]
    public virtual bool AttrAny { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Attribute Clear",
        Summary = "Determines whether the monster is transparent.",
        DataType = "bool")]
    public virtual bool AttrClear { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Attribute Multi",
        Summary = "Determines whether the monster changes color.",
        DataType = "bool")]
    public virtual bool AttrMulti { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Bash Door",
        Summary = "Determines whether the monster can break open doors.",
        DataType = "bool")]
    public virtual bool BashDoor { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Character Clear",
        Summary = "Determines whether the monster is never seen, even with see invisible.",
        DataType = "bool")]
    public virtual bool CharClear { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Character Multi",
        Summary = "Determines whether the monster changes shape randomly.",
        DataType = "bool")]
    public virtual bool CharMulti { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Cold Blood",
        Summary = "Determines whether the monster is cold-blooded.",
        DataType = "bool")]
    public virtual bool ColdBlood { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Cthuloid",
        Summary = "Determines whether the monster is cthuloid.",
        DataType = "bool")]
    public virtual bool Cthuloid { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Demon",
        Summary = "Determines whether the monster is a demon.",
        DataType = "bool")]
    public virtual bool Demon { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Description",
        Summary = "Specifies the descriptive text for the monster.",
        DataType = "string")]
    public virtual string Description { get; set; }

    [ConfigurationMetadata(
        Title = "Dragon",
        Summary = "Determines whether the monster is a dragon.",
        DataType = "bool")]
    public virtual bool Dragon { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Drop 1D2",
        Summary = "Determines whether the monster drops one to two items.",
        DataType = "bool")]
    public virtual bool Drop_1D2 { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Drop 2D2",
        Summary = "Determines whether the monster drops two to four items.",
        DataType = "bool")]
    public virtual bool Drop_2D2 { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Drop 3D2",
        Summary = "Determines whether the monster drops three to six items.",
        DataType = "bool")]
    public virtual bool Drop_3D2 { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Drop 4D2",
        Summary = "Determines whether the monster drops four to eight items.",
        DataType = "bool")]
    public virtual bool Drop_4D2 { get; set; } = false;

    [ConfigurationMetadata(Title = "Drop 60", Summary = "Determines whether the monster drops an item 60 percent of the time.", DataType = "bool")]
    public virtual bool Drop60 { get; set; } = false;

    [ConfigurationMetadata(Title = "Drop 90", Summary = "Determines whether the monster drops an item 90 percent of the time.", DataType = "bool")]
    public virtual bool Drop90 { get; set; } = false;

    [ConfigurationMetadata(Title = "Drop Good", Summary = "Determines whether the monster drops good items.", DataType = "bool")]
    public virtual bool DropGood { get; set; } = false;

    [ConfigurationMetadata(Title = "Drop Great", Summary = "Determines whether the monster drops great items.", DataType = "bool")]
    public virtual bool DropGreat { get; set; } = false;

    [ConfigurationMetadata(Title = "Eldritch Horror", Summary = "Determines whether the monster is an eldritch horror.", DataType = "bool")]
    public virtual bool EldritchHorror { get; set; } = false;

    [ConfigurationMetadata(Title = "Empty Mind", Summary = "Determines whether the monster has an empty mind.", DataType = "bool")]
    public virtual bool EmptyMind { get; set; } = false;

    [ConfigurationMetadata(Title = "Escorted", Summary = "Determines whether the monster comes with minions of the same character.", DataType = "bool")]
    public virtual bool Escorted { get; set; } = false;

    [ConfigurationMetadata(Title = "Escorts Group", Summary = "Determines whether the monster's minions come in groups.", DataType = "bool")]
    public virtual bool EscortsGroup { get; set; } = false;

    [ConfigurationMetadata(Title = "Evil", Summary = "Determines whether the monster is evil.", DataType = "bool")]
    public virtual bool Evil { get; set; } = false;

    [ConfigurationMetadata(Title = "Female", Summary = "Determines whether the monster uses feminine pronouns.", DataType = "bool")]
    public virtual bool Female { get; set; } = false;

    [ConfigurationMetadata(Title = "Fire Aura", Summary = "Determines whether the monster has an aura of fire.", DataType = "bool")]
    public virtual bool FireAura { get; set; } = false;

    [ConfigurationMetadata(Title = "Force Maximum Hit Points", Summary = "Determines whether the monster has maximum hit points.", DataType = "bool")]
    public virtual bool ForceMaxHp { get; set; } = false;

    [ConfigurationMetadata(Title = "Force Sleep", Summary = "Determines whether the monster always starts asleep.", DataType = "bool")]
    public virtual bool ForceSleep { get; set; } = false;

    [ConfigurationMetadata(Title = "Innate Frequency", Summary = "Specifies the one-in-X frequency with which the monster uses innate abilities.", DataType = "int")]
    public virtual int FreqInate { get; set; }

    [ConfigurationMetadata(Title = "Spell Frequency", Summary = "Specifies the one-in-X frequency with which the monster uses spells.", DataType = "int")]
    public virtual int FreqSpell { get; set; }

    [ConfigurationMetadata(Title = "Friendly Name", Summary = "Specifies the name displayed to the player.", DataType = "string")]
    public virtual string FriendlyName { get; set; }

    [ConfigurationMetadata(Title = "Friends", Summary = "Determines whether the monster comes with friends of the same race.", DataType = "bool")]
    public virtual bool Friends { get; set; } = false;

    [ConfigurationMetadata(Title = "Giant", Summary = "Determines whether the monster is a giant.", DataType = "bool")]
    public virtual bool Giant { get; set; } = false;

    [ConfigurationMetadata(Title = "Gold Item Factory Binding Key", Summary = "Specifies the binding key of the item factory used to create gold dropped by the monster.", DataType = "string")]
    public virtual string GoldItemFactoryBindingKey { get; set; }

    [ConfigurationMetadata(Title = "Good", Summary = "Determines whether the monster is good.", DataType = "bool")]
    public virtual bool Good { get; set; } = false;

    [ConfigurationMetadata(Title = "Great Old One", Summary = "Determines whether the monster is a Great Old One.", DataType = "bool")]
    public virtual bool GreatOldOne { get; set; } = false;

    [ConfigurationMetadata(Title = "Has Legs", Summary = "Determines whether the monster has legs.", DataType = "bool")]
    public virtual bool HasLegs { get; set; } = false;

    [ConfigurationMetadata(Title = "Hit Dice", Summary = "Specifies the number of hit dice the monster has.", DataType = "int")]
    public virtual int Hdice { get; set; }

    [ConfigurationMetadata(Title = "Hit Dice Sides", Summary = "Specifies the number of sides on the monster's hit dice.", DataType = "int")]
    public virtual int Hside { get; set; }

    [ConfigurationMetadata(Title = "Hurt By Cold", Summary = "Determines whether the monster is hurt by cold.", DataType = "bool")]
    public virtual bool HurtByCold { get; set; } = false;

    [ConfigurationMetadata(Title = "Hurt By Fire", Summary = "Determines whether the monster is hurt by fire.", DataType = "bool")]
    public virtual bool HurtByFire { get; set; } = false;

    [ConfigurationMetadata(Title = "Hurt By Light", Summary = "Determines whether the monster is hurt by light.", DataType = "bool")]
    public virtual bool HurtByLight { get; set; } = false;

    [ConfigurationMetadata(Title = "Hurt By Rock", Summary = "Determines whether the monster is hurt by rock.", DataType = "bool")]
    public virtual bool HurtByRock { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Acid", Summary = "Determines whether the monster is immune to acid.", DataType = "bool")]
    public virtual bool ImmuneAcid { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Cold", Summary = "Determines whether the monster is immune to cold.", DataType = "bool")]
    public virtual bool ImmuneCold { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Confusion", Summary = "Determines whether the monster is immune to confusion.", DataType = "bool")]
    public virtual bool ImmuneConfusion { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Fear", Summary = "Determines whether the monster is immune to fear.", DataType = "bool")]
    public virtual bool ImmuneFear { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Fire", Summary = "Determines whether the monster is immune to fire.", DataType = "bool")]
    public virtual bool ImmuneFire { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Lightning", Summary = "Determines whether the monster is immune to lightning.", DataType = "bool")]
    public virtual bool ImmuneLightning { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Poison", Summary = "Determines whether the monster is immune to poison.", DataType = "bool")]
    public virtual bool ImmunePoison { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Sleep", Summary = "Determines whether the monster is immune to sleep.", DataType = "bool")]
    public virtual bool ImmuneSleep { get; set; } = false;

    [ConfigurationMetadata(Title = "Immune Stun", Summary = "Determines whether the monster is immune to stunning.", DataType = "bool")]
    public virtual bool ImmuneStun { get; set; } = false;

    [ConfigurationMetadata(Title = "Invisible", Summary = "Determines whether the monster is invisible.", DataType = "bool")]
    public virtual bool Invisible { get; set; } = false;

    [ConfigurationMetadata(Title = "Kill Body", Summary = "Determines whether the monster can kill bodies.", DataType = "bool")]
    public virtual bool KillBody { get; set; } = false;

    [ConfigurationMetadata(Title = "Kill Item", Summary = "Determines whether the monster can destroy items.", DataType = "bool")]
    public virtual bool KillItem { get; set; } = false;

    [ConfigurationMetadata(Title = "Kill Wall", Summary = "Determines whether the monster can destroy walls.", DataType = "bool")]
    public virtual bool KillWall { get; set; } = false;

    [ConfigurationMetadata(Title = "Level Found", Summary = "Specifies the level on which the monster is normally found.", DataType = "int")]
    public virtual int LevelFound { get; set; }

    [ConfigurationMetadata(Title = "Lightning Aura", Summary = "Determines whether the monster has an aura of electricity.", DataType = "bool")]
    public virtual bool LightningAura { get; set; } = false;

    [ConfigurationMetadata(Title = "Male", Summary = "Determines whether the monster is male.", DataType = "bool")]
    public virtual bool Male { get; set; } = false;

    [ConfigurationMetadata(Title = "Experience", Summary = "Specifies the experience value for killing the monster.", DataType = "int")]
    public virtual int Mexp { get; set; }

    [ConfigurationMetadata(Title = "Move Body", Summary = "Determines whether the monster can move bodies.", DataType = "bool")]
    public virtual bool MoveBody { get; set; } = false;

    [ConfigurationMetadata(Title = "Multiply", Summary = "Determines whether the monster can multiply.", DataType = "bool")]
    public virtual bool Multiply { get; set; } = false;

    [ConfigurationMetadata(Title = "Never Attack", Summary = "Determines whether the monster never attacks.", DataType = "bool")]
    public virtual bool NeverAttack { get; set; } = false;

    [ConfigurationMetadata(Title = "Never Move", Summary = "Determines whether the monster never moves.", DataType = "bool")]
    public virtual bool NeverMove { get; set; } = false;

    [ConfigurationMetadata(Title = "Nonliving", Summary = "Determines whether the monster is nonliving.", DataType = "bool")]
    public virtual bool Nonliving { get; set; } = false;

    [ConfigurationMetadata(Title = "Notice Range", Summary = "Specifies the distance at which the monster notices the player.", DataType = "int")]
    public virtual int NoticeRange { get; set; }

    [ConfigurationMetadata(Title = "Only Drop Gold", Summary = "Determines whether the monster drops only gold.", DataType = "bool")]
    public virtual bool OnlyDropGold { get; set; } = false;

    [ConfigurationMetadata(Title = "Only Drop Item", Summary = "Determines whether the monster drops only items.", DataType = "bool")]
    public virtual bool OnlyDropItem { get; set; } = false;

    [ConfigurationMetadata(Title = "Open Door", Summary = "Determines whether the monster can open doors.", DataType = "bool")]
    public virtual bool OpenDoor { get; set; } = false;

    [ConfigurationMetadata(Title = "Orc", Summary = "Determines whether the monster is an orc.", DataType = "bool")]
    public virtual bool Orc { get; set; } = false;

    [ConfigurationMetadata(Title = "Pass Wall", Summary = "Determines whether the monster can pass through walls.", DataType = "bool")]
    public virtual bool PassWall { get; set; } = false;

    [ConfigurationMetadata(Title = "Ball And Breathe Projectile Bonus Radius", Summary = "Specifies the bonus radius applied to ball and breath projectiles used by the monster.", DataType = "int")]
    public virtual int BallAndBreatheProjectileBonusRadius { get; set; } = 0;

    [ConfigurationMetadata(Title = "Random Move 25", Summary = "Determines whether the monster randomly moves 25 percent of the time.", DataType = "bool")]
    public virtual bool RandomMove25 { get; set; } = false;

    [ConfigurationMetadata(Title = "Random Move 50", Summary = "Determines whether the monster randomly moves 50 percent of the time.", DataType = "bool")]
    public virtual bool RandomMove50 { get; set; } = false;

    [ConfigurationMetadata(Title = "Rarity", Summary = "Specifies the rarity with which the monster is found.", DataType = "int")]
    public virtual int Rarity { get; set; }

    [ConfigurationMetadata(Title = "Reflecting", Summary = "Determines whether the monster reflects attacks.", DataType = "bool")]
    public virtual bool Reflecting { get; set; } = false;

    [ConfigurationMetadata(Title = "Reaver", Summary = "Determines whether the monster is a reaver.", DataType = "bool")]
    public virtual bool Reaver { get; set; } = false;

    [ConfigurationMetadata(Title = "Regenerate", Summary = "Determines whether the monster regenerates.", DataType = "bool")]
    public virtual bool Regenerate { get; set; } = false;

    [ConfigurationMetadata(Title = "Resist Disenchant", Summary = "Determines whether the monster resists disenchantment.", DataType = "bool")]
    public virtual bool ResistDisenchant { get; set; } = false;

    [ConfigurationMetadata(Title = "Resist Nether", Summary = "Determines whether the monster resists nether.", DataType = "bool")]
    public virtual bool ResistNether { get; set; } = false;

    [ConfigurationMetadata(Title = "Resist Nexus", Summary = "Determines whether the monster resists nexus.", DataType = "bool")]
    public virtual bool ResistNexus { get; set; } = false;

    [ConfigurationMetadata(Title = "Resist Plasma", Summary = "Determines whether the monster resists plasma.", DataType = "bool")]
    public virtual bool ResistPlasma { get; set; } = false;

    [ConfigurationMetadata(Title = "Resist Teleport", Summary = "Determines whether the monster resists teleportation.", DataType = "bool")]
    public virtual bool ResistTeleport { get; set; } = false;

    [ConfigurationMetadata(Title = "Resist Water", Summary = "Determines whether the monster resists water.", DataType = "bool")]
    public virtual bool ResistWater { get; set; } = false;

    [ConfigurationMetadata(Title = "Shapechanger", Summary = "Determines whether the monster is a shapechanger.", DataType = "bool")]
    public virtual bool Shapechanger { get; set; } = false;

    [ConfigurationMetadata(Title = "Sleep", Summary = "Specifies how deeply the monster sleeps.", DataType = "int")]
    public virtual int Sleep { get; set; }

    [ConfigurationMetadata(Title = "Smart", Summary = "Determines whether the monster prioritizes disabling, summoning, or escape spells when badly injured.", DataType = "bool")]
    public virtual bool Smart { get; set; } = false;

    [ConfigurationMetadata(Title = "Speed", Summary = "Specifies how fast the monster moves. A value of 110 represents normal speed.", DataType = "int")]
    public virtual int Speed { get; set; }

    [ConfigurationMetadata(Title = "Stupid", Summary = "Determines whether the monster is stupid.", DataType = "bool")]
    public virtual bool Stupid { get; set; } = false;

    [ConfigurationMetadata(Title = "Take Item", Summary = "Determines whether the monster can take items.", DataType = "bool")]
    public virtual bool TakeItem { get; set; } = false;

    [ConfigurationMetadata(Title = "Troll", Summary = "Determines whether the monster is a troll.", DataType = "bool")]
    public virtual bool Troll { get; set; } = false;

    [ConfigurationMetadata(Title = "Undead", Summary = "Determines whether the monster is undead.", DataType = "bool")]
    public virtual bool Undead { get; set; } = false;

    [ConfigurationMetadata(Title = "Unique", Summary = "Determines whether the monster is unique.", DataType = "bool")]
    public virtual bool Unique { get; set; } = false;

    [ConfigurationMetadata(Title = "Weird Mind", Summary = "Determines whether the monster has a weird mind.", DataType = "bool")]
    public virtual bool WeirdMind { get; set; } = false;
}
