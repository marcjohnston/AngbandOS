﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class CauseMortalWoundsMonsterSpell : CauseWoundsMonsterSpell
{
    private CauseMortalWoundsMonsterSpell(Game game) : base(game) { }
    public override bool IsAttack => true;
    protected override int CurseEquipmentChance => 0;
    protected override int HeavyCurseEquipmentChance => 0;
    protected override string DamageRollExpression => "15d15";
    public override string? VsPlayerBlindMessage => "You hear someone screams the word 'DIE!'";
    public override string? VsPlayerActionMessage => "{0} points at you, screaming the word DIE!";
    public override string? VsMonsterUnseenMessage => "You hear someone mumble.";
    public override string? VsMonsterSeenMessage => "{0} points at {3}, screaming the word 'DIE!'";
    protected override int TimedBleeding => Game.DiceRoll(10, 10);
}
