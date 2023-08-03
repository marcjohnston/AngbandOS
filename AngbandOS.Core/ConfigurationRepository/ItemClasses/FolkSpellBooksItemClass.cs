namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class FolkSpellBooksItemClass : ItemClass
{
    private FolkSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Folk Spellbooks";
}