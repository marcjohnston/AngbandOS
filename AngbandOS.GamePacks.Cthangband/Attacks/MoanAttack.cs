﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MoanAttack : AttackGameConfiguration
{
    public override string MonsterAction => "moans at {0}";
    public override string[]? PlayerActionMessages => new string[]
    {
        "seems sad about something.",
        "asks if you have seen his dogs.",
        "tells you to get off his land.",
        "mumbles something about mushrooms."
    };
    public override string KnowledgeAction => "moan";
    public override bool AttackAwakensTarget => true;
}
