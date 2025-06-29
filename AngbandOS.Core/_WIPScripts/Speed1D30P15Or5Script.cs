﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Speed1D30P15Or5Script : Script, IReadScrollOrUseStaffScript
{
    private Speed1D30P15Or5Script(Game game) : base(game) { }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        if (Game.HasteTimer.Value == 0)
        {
            if (Game.HasteTimer.SetTimer(Game.DieRoll(30) + 15))
            {
                return new IdentifiedAndUsedResult(true, true);
            }
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
        return new IdentifiedAndUsedResult(false, true);
    }
}