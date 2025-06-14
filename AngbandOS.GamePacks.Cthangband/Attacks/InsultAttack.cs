﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class InsultAttack : AttackGameConfiguration
{
    public override string MonsterAction => "insults {0}";
    public override string[]? PlayerActionMessages => new string[]
    {
        "insults you!", "insults your mother!", "gives you the finger!", "humiliates you!", "defiles you!",
        "dances around you!", "makes obscene gestures!", "moons you!"
    };
    public override string KnowledgeAction => "insult";
    public override bool AttackTouchesTarget => false;
    public override bool AttackAwakensTarget => true;
}
