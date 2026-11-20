// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MonsterRaceGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("bool",
        Title = "Can Teleport Self",
        Summary = "Determines whether the monster can teleport itself.")]
    public virtual bool CanTeleportSelf { get; set; } = false;

    [ConfigurationProperty("string[]?",
        Title = "Spells",
        Summary = "Specifies the spells that are available to monsters of this race.")]
    [ConfigurationForeignKey("MonsterSpells")]
    public virtual string[]? MonsterSpellBindingKeys { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Multiline Name",
        Summary = "Specifies the multiline name displayed to the player. When null, the friendly name is used.")]
    public virtual string? MultilineName { get; set; }

    [ConfigurationProperty("string",
        Title = "Symbol Name",
        Summary = "Specifies the binding key for the symbol used to render the monster.")]
    [ConfigurationForeignKey("Symbols")]
    public virtual string SymbolName { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Summary = "Specifies the color used to display the monster.")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty("bool",
        Title = "Animal",
        Summary = "Determines whether the monster is an animal.")]
    public virtual bool Animal { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Armor Class",
        Summary = "Specifies the monster's armor class.")]
    public virtual int ArmorClass { get; set; }

    [ConfigurationTupleItem(
        "MethodName",
        Title = "Method Name",
        ForeignCollectionName = "Attacks")]
    [ConfigurationTupleItem(
        "EffectName",
        Title = "Effect Name")]
    [ConfigurationTupleItem("Dice", Title = "Dice")]
    [ConfigurationTupleItem("Sides", Title = "Sides")]
    [ConfigurationProperty("(string MethodName, string? EffectName, int Dice, int Sides)[]?",
        Title = "Attack Definitions",
        Summary = "Specifies the attack definitions for the monster. When null, the monster cannot attack.")]
    public virtual (string MethodName, string? EffectName, int Dice, int Sides)[]? AttackDefinitions { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Attribute Any",
        Summary = "Determines whether the monster can use any color when its color changes.")]
    public virtual bool AttrAny { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Attribute Clear",
        Summary = "Determines whether the monster is transparent.")]
    public virtual bool AttrClear { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Attribute Multi",
        Summary = "Determines whether the monster changes color.")]
    public virtual bool AttrMulti { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Bash Door",
        Summary = "Determines whether the monster can break open doors.")]
    public virtual bool BashDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Character Clear",
        Summary = "Determines whether the monster is never seen, even with see invisible.")]
    public virtual bool CharClear { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Character Multi",
        Summary = "Determines whether the monster changes shape randomly.")]
    public virtual bool CharMulti { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Cold Blood",
        Summary = "Determines whether the monster is cold-blooded.")]
    public virtual bool ColdBlood { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Cthuloid",
        Summary = "Determines whether the monster is cthuloid.")]
    public virtual bool Cthuloid { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Demon",
        Summary = "Determines whether the monster is a demon.")]
    public virtual bool Demon { get; set; } = false;

    [ConfigurationProperty("string",
        Title = "Description",
        Summary = "Specifies the descriptive text for the monster.")]
    public virtual string Description { get; set; }

    [ConfigurationProperty("bool",
        Title = "Dragon",
        Summary = "Determines whether the monster is a dragon.")]
    public virtual bool Dragon { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop 1D2",
        Summary = "Determines whether the monster drops one to two items.")]
    public virtual bool Drop_1D2 { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop 2D2",
        Summary = "Determines whether the monster drops two to four items.")]
    public virtual bool Drop_2D2 { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop 3D2",
        Summary = "Determines whether the monster drops three to six items.")]
    public virtual bool Drop_3D2 { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop 4D2",
        Summary = "Determines whether the monster drops four to eight items.")]
    public virtual bool Drop_4D2 { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop 60",
        Summary = "Determines whether the monster drops an item 60 percent of the time.")]
    public virtual bool Drop60 { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop 90",
        Summary = "Determines whether the monster drops an item 90 percent of the time.")]
    public virtual bool Drop90 { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop Good",
        Summary = "Determines whether the monster drops good items.")]
    public virtual bool DropGood { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Drop Great",
        Summary = "Determines whether the monster drops great items.")]
    public virtual bool DropGreat { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Eldritch Horror",
        Summary = "Determines whether the monster is an eldritch horror.")]
    public virtual bool EldritchHorror { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Empty Mind",
        Summary = "Determines whether the monster has an empty mind.")]
    public virtual bool EmptyMind { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Escorted",
        Summary = "Determines whether the monster comes with minions of the same character.")]
    public virtual bool Escorted { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Escorts Group",
        Summary = "Determines whether the monster's minions come in groups.")]
    public virtual bool EscortsGroup { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Evil",
        Summary = "Determines whether the monster is evil.")]
    public virtual bool Evil { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Female",
        Summary = "Determines whether the monster uses feminine pronouns.")]
    public virtual bool Female { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Fire Aura",
        Summary = "Determines whether the monster has an aura of fire.")]
    public virtual bool FireAura { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Force Maximum Hit Points",
        Summary = "Determines whether the monster has maximum hit points.")]
    public virtual bool ForceMaxHp { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Force Sleep",
        Summary = "Determines whether the monster always starts asleep.")]
    public virtual bool ForceSleep { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Innate Frequency",
        Summary = "Specifies the one-in-X frequency with which the monster uses innate abilities.")]
    public virtual int FreqInate { get; set; }

    [ConfigurationProperty("int",
        Title = "Spell Frequency",
        Summary = "Specifies the one-in-X frequency with which the monster uses spells.")]
    public virtual int FreqSpell { get; set; }

    [ConfigurationProperty("string",
        Title = "Friendly Name",
        Summary = "Specifies the name displayed to the player.")]
    public virtual string FriendlyName { get; set; }

    [ConfigurationProperty("bool",
        Title = "Friends",
        Summary = "Determines whether the monster comes with friends of the same race.")]
    public virtual bool Friends { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Giant",
        Summary = "Determines whether the monster is a giant.")]
    public virtual bool Giant { get; set; } = false;

    [ConfigurationProperty("string",
        Title = "Gold Item Factory Binding Key",
        Summary = "Specifies the binding key of the item factory used to create gold dropped by the monster.")]
    [ConfigurationForeignKey("ItemFactories")]
    public virtual string GoldItemFactoryBindingKey { get; set; }

    [ConfigurationProperty("bool",
        Title = "Good",
        Summary = "Determines whether the monster is good.")]
    public virtual bool Good { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Great Old One",
        Summary = "Determines whether the monster is a Great Old One.")]
    public virtual bool GreatOldOne { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Has Legs",
        Summary = "Determines whether the monster has legs.")]
    public virtual bool HasLegs { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Hit Dice",
        Summary = "Specifies the number of hit dice the monster has.")]
    public virtual int Hdice { get; set; }

    [ConfigurationProperty("int",
        Title = "Hit Dice Sides",
        Summary = "Specifies the number of sides on the monster's hit dice.")]
    public virtual int Hside { get; set; }

    [ConfigurationProperty("bool",
        Title = "Hurt By Cold",
        Summary = "Determines whether the monster is hurt by cold.")]
    public virtual bool HurtByCold { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Hurt By Fire",
        Summary = "Determines whether the monster is hurt by fire.")]
    public virtual bool HurtByFire { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Hurt By Light",
        Summary = "Determines whether the monster is hurt by light.")]
    public virtual bool HurtByLight { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Hurt By Rock",
        Summary = "Determines whether the monster is hurt by rock.")]
    public virtual bool HurtByRock { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Acid",
        Summary = "Determines whether the monster is immune to acid.")]
    public virtual bool ImmuneAcid { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Cold",
        Summary = "Determines whether the monster is immune to cold.")]
    public virtual bool ImmuneCold { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Confusion",
        Summary = "Determines whether the monster is immune to confusion.")]
    public virtual bool ImmuneConfusion { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Fear",
        Summary = "Determines whether the monster is immune to fear.")]
    public virtual bool ImmuneFear { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Fire",
        Summary = "Determines whether the monster is immune to fire.")]
    public virtual bool ImmuneFire { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Lightning",
        Summary = "Determines whether the monster is immune to lightning.")]
    public virtual bool ImmuneLightning { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Poison",
        Summary = "Determines whether the monster is immune to poison.")]
    public virtual bool ImmunePoison { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Sleep",
        Summary = "Determines whether the monster is immune to sleep.")]
    public virtual bool ImmuneSleep { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Immune Stun",
        Summary = "Determines whether the monster is immune to stunning.")]
    public virtual bool ImmuneStun { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Invisible",
        Summary = "Determines whether the monster is invisible.")]
    public virtual bool Invisible { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Kill Body",
        Summary = "Determines whether the monster can kill bodies.")]
    public virtual bool KillBody { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Kill Item",
        Summary = "Determines whether the monster can destroy items.")]
    public virtual bool KillItem { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Kill Wall",
        Summary = "Determines whether the monster can destroy walls.")]
    public virtual bool KillWall { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Level Found",
        Summary = "Specifies the level on which the monster is normally found.")]
    public virtual int LevelFound { get; set; }

    [ConfigurationProperty("bool",
        Title = "Lightning Aura",
        Summary = "Determines whether the monster has an aura of electricity.")]
    public virtual bool LightningAura { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Male",
        Summary = "Determines whether the monster is male.")]
    public virtual bool Male { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Experience",
        Summary = "Specifies the experience value for killing the monster.")]
    public virtual int Mexp { get; set; }

    [ConfigurationProperty("bool",
        Title = "Move Body",
        Summary = "Determines whether the monster can move bodies.")]
    public virtual bool MoveBody { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Multiply",
        Summary = "Determines whether the monster can multiply.")]
    public virtual bool Multiply { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Never Attack",
        Summary = "Determines whether the monster never attacks.")]
    public virtual bool NeverAttack { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Never Move",
        Summary = "Determines whether the monster never moves.")]
    public virtual bool NeverMove { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Nonliving",
        Summary = "Determines whether the monster is nonliving.")]
    public virtual bool Nonliving { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Notice Range",
        Summary = "Specifies the distance at which the monster notices the player.")]
    public virtual int NoticeRange { get; set; }

    [ConfigurationProperty("bool",
        Title = "Only Drop Gold",
        Summary = "Determines whether the monster drops only gold.")]
    public virtual bool OnlyDropGold { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Only Drop Item",
        Summary = "Determines whether the monster drops only items.")]
    public virtual bool OnlyDropItem { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Open Door",
        Summary = "Determines whether the monster can open doors.")]
    public virtual bool OpenDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Orc",
        Summary = "Determines whether the monster is an orc.")]
    public virtual bool Orc { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Pass Wall",
        Summary = "Determines whether the monster can pass through walls.")]
    public virtual bool PassWall { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Ball And Breathe Projectile Bonus Radius",
        Summary = "Specifies the bonus radius applied to ball and breath projectiles used by the monster.")]
    public virtual int BallAndBreatheProjectileBonusRadius { get; set; } = 0;

    [ConfigurationProperty("bool",
        Title = "Random Move 25",
        Summary = "Determines whether the monster randomly moves 25 percent of the time.")]
    public virtual bool RandomMove25 { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Random Move 50",
        Summary = "Determines whether the monster randomly moves 50 percent of the time.")]
    public virtual bool RandomMove50 { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Rarity",
        Summary = "Specifies the rarity with which the monster is found.")]
    public virtual int Rarity { get; set; }

    [ConfigurationProperty("bool",
        Title = "Reflecting",
        Summary = "Determines whether the monster reflects attacks.")]
    public virtual bool Reflecting { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Reaver",
        Summary = "Determines whether the monster is a reaver.")]
    public virtual bool Reaver { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Regenerate",
        Summary = "Determines whether the monster regenerates.")]
    public virtual bool Regenerate { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Resist Disenchant",
        Summary = "Determines whether the monster resists disenchantment.")]
    public virtual bool ResistDisenchant { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Resist Nether",
        Summary = "Determines whether the monster resists nether.")]
    public virtual bool ResistNether { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Resist Nexus",
        Summary = "Determines whether the monster resists nexus.")]
    public virtual bool ResistNexus { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Resist Plasma",
        Summary = "Determines whether the monster resists plasma.")]
    public virtual bool ResistPlasma { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Resist Teleport",
        Summary = "Determines whether the monster resists teleportation.")]
    public virtual bool ResistTeleport { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Resist Water",
        Summary = "Determines whether the monster resists water.")]
    public virtual bool ResistWater { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Shapechanger",
        Summary = "Determines whether the monster is a shapechanger.")]
    public virtual bool Shapechanger { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Sleep",
        Summary = "Specifies how deeply the monster sleeps.")]
    public virtual int Sleep { get; set; }

    [ConfigurationProperty("bool",
        Title = "Smart",
        Summary = "Determines whether the monster prioritizes disabling, summoning, or escape spells when badly injured.")]
    public virtual bool Smart { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Speed",
        Summary = "Specifies how fast the monster moves. A value of 110 represents normal speed.")]
    public virtual int Speed { get; set; }

    [ConfigurationProperty("bool",
        Title = "Stupid",
        Summary = "Determines whether the monster is stupid.")]
    public virtual bool Stupid { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Take Item",
        Summary = "Determines whether the monster can take items.")]
    public virtual bool TakeItem { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Troll",
        Summary = "Determines whether the monster is a troll.")]
    public virtual bool Troll { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Undead",
        Summary = "Determines whether the monster is undead.")]
    public virtual bool Undead { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Unique",
        Summary = "Determines whether the monster is unique.")]
    public virtual bool Unique { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Weird Mind",
        Summary = "Determines whether the monster has a weird mind.")]
    public virtual bool WeirdMind { get; set; } = false;
}
