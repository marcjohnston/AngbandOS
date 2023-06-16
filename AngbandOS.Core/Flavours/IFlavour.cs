// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavours;

/// <summary>
/// Represents the interface an item factory needs to implement for the item to have a flavour.
/// </summary>
internal interface IFlavour
{
    /// <summary>
    /// Returns the repository to use for the issuance of the flavours or null, if the factory shouldn't be issued a flavour.  Null is returned
    /// when an item has a predefined flavour.  Apple juice, water and slime-mold item factories use pre-defined flavours. 
    /// </summary>
    IEnumerable<Flavour>? GetFlavourRepository();

    /// <summary>
    /// Returns the flavour that was issued to the item factory.
    /// </summary>
    Flavour Flavour { get; set; }
}