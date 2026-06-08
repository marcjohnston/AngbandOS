// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CauseMortalWoundsMonsterSpell : CauseWoundsMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "cause mortal wounds");
    public override bool IsAttack => true;
    public override int CurseEquipmentChance => 0;
    public override int HeavyCurseEquipmentChance => 0;
    public override string DamageRollExpression => "15d15";
    public override string? VsPlayerBlindMessage => "You hear someone screams the word 'DIE!'";
    public override string? VsPlayerActionMessage => "{0} points at you, screaming the word DIE!";
    public override string? VsMonsterUnseenMessage => "You hear someone mumble.";
    public override string? VsMonsterSeenMessage => "{0} points at {3}, screaming the word 'DIE!'";
    public override string TimedBleedingExpressionText => "10d10";
}
