namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class FolkSpellBooksItemClass : ItemClass
{
    private FolkSpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Folk Spellbook";
}