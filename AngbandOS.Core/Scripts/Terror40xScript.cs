// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Terror40xScript : Script, IUsedScriptItem
{
    private Terror40xScript(Game game) : base(game) { }

    public bool ExecuteUsedScriptItem(Item item) // This is run by an item activation
    {
        Game.TurnMonsters(40 + Game.ExperienceLevel.IntValue);
        return true;
    }
}
