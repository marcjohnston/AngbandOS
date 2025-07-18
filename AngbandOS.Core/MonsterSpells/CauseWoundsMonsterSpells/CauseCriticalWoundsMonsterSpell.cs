﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class CauseCriticalWoundsMonsterSpell : CauseWoundsMonsterSpell
{
    private CauseCriticalWoundsMonsterSpell(Game game) : base(game) { }
    public override bool IsAttack => true;
    public override bool Annoys => true;
    protected override int CurseEquipmentChance => 80;
    protected override int HeavyCurseEquipmentChance => 15;
    protected override string DamageRollExpression => "10d15";
    public override string? VsPlayerBlindMessage => "You hear someone mumble loudly.";
    public override string? VsPlayerActionMessage => "{0} points at you, incanting terribly!";
    public override string? VsMonsterUnseenMessage => "You hear someone mumble.";
    public override string? VsMonsterSeenMessage => "{0} points at {3}, incanting terribly!";
}
