// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

internal interface IMonsterCharacteristics
{
    bool AttrClear { get; }
    bool AttrMulti { get; }
    bool CharClear { get; }
    bool CharMulti { get; }
    bool Drop_1D2 { get; }
    bool Drop_2D2 { get; }
    bool Drop_3D2 { get; }
    bool Drop_4D2 { get; }
    bool Drop60 { get; }
    bool Drop90 { get; }
    bool DropGood { get; }
    bool DropGreat { get; }
    bool Escorted { get; }
    bool EscortsGroup { get; }
    bool Female { get; }
    bool ForceMaxHp { get; }
    bool ForceSleep { get; }
    bool Friends { get; }
    bool Male { get; }
    bool NeverAttack { get; }
    bool NeverMove { get; }
    bool OnlyDropGold { get; }
    bool OnlyDropItem { get; }
    bool RandomMove25 { get; }
    bool RandomMove50 { get; }
    bool Unique { get; }

    bool AttrAny { get; }
    bool BashDoor { get; }
    bool ColdBlood { get; }
    bool EldritchHorror { get; }
    bool EmptyMind { get; }
    bool FireAura { get; }
    bool Invisible { get; }
    bool KillBody { get; }
    bool KillItem { get; }
    bool KillWall { get; }
    bool LightningAura { get; }
    bool MoveBody { get; }
    bool Multiply { get; }
    bool OpenDoor { get; }
    bool PassWall { get; }
    bool Powerful { get; }
    bool Reflecting { get; }
    bool Regenerate { get; }
    bool Shapechanger { get; }
    bool Smart { get; }
    bool Stupid { get; }
    bool TakeItem { get; }
    bool WeirdMind { get; }

    bool Animal { get; }
    bool Cthuloid { get; }
    bool Demon { get; }
    bool Dragon { get; }
    bool Evil { get; }
    bool Giant { get; }
    bool Good { get; }
    bool GreatOldOne { get; }
    bool HurtByCold { get; }
    bool HurtByFire { get; }
    bool HurtByLight { get; }
    bool HurtByRock { get; }
    bool ImmuneAcid { get; }
    bool ImmuneCold { get; }
    bool ImmuneConfusion { get; }
    bool ImmuneFear { get; }
    bool ImmuneFire { get; }
    bool ImmuneLightning { get; }
    bool ImmunePoison { get; }
    bool ImmuneSleep { get; }
    bool ImmuneStun { get; }
    bool Nonliving { get; }
    bool Orc { get; }
    bool ResistDisenchant { get; }
    bool ResistNether { get; }
    bool ResistNexus { get; }
    bool ResistPlasma { get; }
    bool ResistTeleport { get; }
    bool ResistWater { get; }
    bool Troll { get; }
    bool Undead { get; }
}
