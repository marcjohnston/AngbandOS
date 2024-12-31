// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Speed75p1d75Script : Script, IUsedScriptItem
{
    private Speed75p1d75Script(Game game) : base(game) { }

    public bool ExecuteUsedScriptItem(Item item) // This is run by an item activation
    {
        if (Game.HasteTimer.Value == 0)
        {
            Game.HasteTimer.SetTimer(Game.DieRoll(75) + 75);
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
        return true;
    }
}
