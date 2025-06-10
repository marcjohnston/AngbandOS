// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpeedIdentifiedAndUsedScriptItemAndDirection : Script, IZapRodScript
{
    private SpeedIdentifiedAndUsedScriptItemAndDirection(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        bool isIdentified = false;
        if (Game.HasteTimer.Value == 0)
        {
            if (Game.HasteTimer.SetTimer(Game.DieRoll(30) + 15))
            {
                isIdentified = true;
            }
        }
        else
        {
            Game.HasteTimer.AddTimer(5);
        }
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}
