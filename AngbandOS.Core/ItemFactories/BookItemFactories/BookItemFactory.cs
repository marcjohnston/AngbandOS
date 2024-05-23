// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class BookItemFactory : ItemFactory
{
    public BookItemFactory(Game game) : base(game) { }

    public override void Bind()
    {
        base.Bind();
        Spells = Game.SingletonRepository.Get<Spell>(SpellNames);
    }

    public void SetBookIndex(Realm realm, int bookIndex)
    {
        BookIndex = bookIndex;
        Realm = realm;
    }

    public int BookIndex { get; private set; }

    /// <summary>
    /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
    /// </summary>
    public virtual int ExperienceGainDivisorForDestroying => 4;

    /// <summary>
    /// Returns true for all books.
    /// </summary>
    public override bool EasyKnow => true;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (50, "2d3-2"),
        (500, "1d3-1")
    };

    /// <summary>
    /// Returns the singleton realm that this book factory belongs to.  This is needed because realms define books--books do not define what realm they belong to.
    /// For this reason, the Realm the book belongs to is set at run-time.
    /// </summary>
    public Realm Realm { get; private set; }

    /// <summary>
    /// Returns the spells that belong to this book.  This property is bound from the SpellNames property during the binding phase.
    /// </summary>
    public Spell[] Spells { get; private set; }

    /// <summary>
    /// Returns the names of the spells that belong to this book.  This property is used to bind the Spells property during the binding phase.
    /// </summary>
    protected abstract string[] SpellNames { get; }

    /// <summary>
    /// Returns true, if a book is a high level book; false, otherwise.  False is returned, by default.
    /// </summary>
    public virtual bool IsHighLevelBook => false;
}
