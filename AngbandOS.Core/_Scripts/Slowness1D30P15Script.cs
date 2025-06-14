﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Slowness1D30P15Script : Script, IReadScrollOrUseStaffScript
{
    private Slowness1D30P15Script(Game game) : base(game) { }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        // Slowness slows you down.
        bool identified = Game.SlowTimer.AddTimer(Game.DieRoll(30) + 15);
        return new IdentifiedAndUsedResult(identified, true);
    }
}
