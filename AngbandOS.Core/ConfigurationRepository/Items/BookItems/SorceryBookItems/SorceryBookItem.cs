// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class SorceryBookItem : BookItem
{
    public SorceryBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override string RealmName => "Sorcery";

    /// <summary>
    /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
    /// </summary>
    public override string DivineTitle => RealmName;
}