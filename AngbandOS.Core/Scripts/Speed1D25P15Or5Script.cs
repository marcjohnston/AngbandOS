// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Speed1D25P15Or5Script : Script, IIdentifiedScript
{
    private Speed1D25P15Or5Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteIdentifiedScript()
    {
        // Speed temporarily hastes you.  But it is not additive.
        if (Game.HasteTimer.Value == 0)
        {
            if (Game.HasteTimer.SetTimer(Game.DieRoll(25) + 15))
            {
                return new IdentifiedResult(true);
            }
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
        return new IdentifiedResult(false);
    }
}
