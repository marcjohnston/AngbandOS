// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CauseSeriousWoundsMonsterSpell : CauseWoundsMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "cause serious wounds and cursing");
    public override bool IsAttack => true;
    public override bool Annoys => true;
    public override int CurseEquipmentChance => 50;
    public override int HeavyCurseEquipmentChance => 5;
    public override string DamageRollExpression => "8d8";
    public override string? VsMonsterSeenMessage => "{0} points at {3} and curses horribly.";
}
