// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CauseLightWoundsMonsterSpell : CauseWoundsMonsterSpellGameConfiguration
{
    public override (string, string) KnowledgeAction => ("which", "cause light wounds and cursing");
    public override int CurseEquipmentChance => 33;
    public override int HeavyCurseEquipmentChance => 0;
    public override string DamageRollExpression => "3d8";
    public override string? VsMonsterSeenMessage => "{0} points at {3} and curses horribly.";
}
