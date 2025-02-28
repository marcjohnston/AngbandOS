// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CrushAttack : AttackGameConfiguration
{
    public override string MonsterAction => "crushes {0}";
    public override string[]? PlayerActionMessages => new string[]
    {
        "crushes you"
    };
    public override string KnowledgeAction => "crush";
    public override bool AttackStunsTarget => true;
}
