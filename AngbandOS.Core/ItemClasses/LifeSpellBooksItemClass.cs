[Serializable]
internal class LifeSpellBooksItemClass : ItemClass
{
    private LifeSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Life Spellbooks";
}