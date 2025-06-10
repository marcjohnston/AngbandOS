// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PunchAttack : AttackGameConfiguration
{
    public override string MonsterAction => "punches {0}";
    public override string[]? PlayerActionMessages => new string[]
    {
        "punches you"
    };
    public override string KnowledgeAction => "punch";
    public override bool AttackStunsTarget => true;
}
