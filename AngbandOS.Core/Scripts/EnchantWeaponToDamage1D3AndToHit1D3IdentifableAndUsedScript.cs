// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnchantWeaponToDamage1D3AndToHit1D3IdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private EnchantWeaponToDamage1D3AndToHit1D3IdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.EnchantItem(Game.DieRoll(3), Game.DieRoll(3), 0))
        {
            return (true, false);
        }
        return (true, true);
    }
}

