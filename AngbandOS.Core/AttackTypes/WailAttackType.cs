// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackTypes;

internal class WailAttackType : BaseAttackType
{
    public override string MonsterAction(Monster monster) => $"wails at {monster.Name}";
    public override string PlayerAction(SaveGame saveGame) => $"wails at you";
    public override string KnowledgeAction => "wail";
    public override bool AttackTouchesTarget => false;
}
