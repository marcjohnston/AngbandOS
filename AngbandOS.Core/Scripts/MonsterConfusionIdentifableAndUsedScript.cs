// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MonsterConfusionIdentifableAndUsedScript : Script, IIdentifiedAndUsedScript
{
    private MonsterConfusionIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        if (Game.HasConfusingTouch)
        {
            return (false, true); // We already had the enchantment.  We won't be able to identify any changes.
        }
        Game.MsgPrint("Your hands begin to glow.");
        Game.HasConfusingTouch = true;
        return (true, true); // We were able to identify the change in our hands.
    }
}

