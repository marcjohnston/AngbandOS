// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class StarlightScript : Script, IReadScrollOrUseStaffScript
{
    private StarlightScript(Game game) : base(game) { }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        if (Game.BlindnessTimer.Value == 0)
        {
            Game.MsgPrint("The end of the staff glows brightly...");
        }
        for (int k = 0; k < 8; k++)
        {
            Game.LightLine(Game.OrderedDirection[k]);
        }
        return new IdentifiedAndUsedResult(true, true);
    }
}
