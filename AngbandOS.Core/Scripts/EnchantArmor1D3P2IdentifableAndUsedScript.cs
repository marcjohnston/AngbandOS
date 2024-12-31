// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnchantArmor1D3P2IdentifableAndUsedScript : Script, IIdentifiedAndUsedScript
{
    private EnchantArmor1D3P2IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        bool used = Game.EnchantItem(0, 0, Game.DieRoll(3) + 2);
        return (true, used);
    }
}

