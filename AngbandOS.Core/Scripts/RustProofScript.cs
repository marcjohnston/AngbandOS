﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RustProofScript : Script, IScript
{
    private RustProofScript(Game game) : base(game) { }

    /// <summary>
    /// Make a piece of armor immune to acid damage, removing any penalty at the same time
    /// </summary>
    public void ExecuteScript()
    {
        // Get a piece of armor
        if (!Game.SelectItem(out Item? item, "Rustproof which piece of armor? ", true, true, true, Game.SingletonRepository.ItemFilters.Get(nameof(ArmorItemFilter))))
        {
            Game.MsgPrint("You have nothing to rustproof.");
            return;
        }
        if (item == null)
        {
            return;
        }
        string itenName = item.Description(false, 0);
        // Set the ignore acid flag
        item.RandomArtifactItemCharacteristics.IgnoreAcid = true;
        // Make sure the grammar of the message is correct
        string your = item.IsInInventory ? "Your" : "The";
        string s;
        if (item.BonusArmorClass < 0 && !item.IdentCursed)
        {
            s = item.Count > 1 ? "" : "s";
            Game.MsgPrint($"{your} {itenName} look{s} as good as new!");
            item.BonusArmorClass = 0;
        }
        s = item.Count > 1 ? "are" : "is";
        Game.MsgPrint($"{your} {itenName} {s} now protected against corrosion.");
    }
}