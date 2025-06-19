// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents an item filter for spell books that are in the primary or secondary realms.
/// </summary>
[Serializable]
public class IsUsableSpellBookItemFilter : ItemFilterGameConfiguration
{
    public override bool? IsUsableSpellBook => true;
}
