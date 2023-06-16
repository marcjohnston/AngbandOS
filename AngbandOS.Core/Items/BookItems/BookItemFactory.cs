// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class BookItemFactory : ItemFactory
{
    public BookItemFactory(SaveGame saveGame) : base(saveGame) { }
    /// <summary>
    /// Returns true for all books.
    /// </summary>
    public override bool EasyKnow => true;

    public abstract BaseRealm? ToRealm { get; }

    public abstract Spell[] Spells { get; }

    /// <summary>
    /// Returns true, if a book is a high level book; false, otherwise.  False is returned, by default.
    /// </summary>
    public virtual bool IsHighLevelBook => false;
}
