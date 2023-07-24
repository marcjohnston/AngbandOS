[Serializable]
internal class CorporealSpellBooksItemClass : ItemClass
{
    private CorporealSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Corporeal Spellbooks";
}