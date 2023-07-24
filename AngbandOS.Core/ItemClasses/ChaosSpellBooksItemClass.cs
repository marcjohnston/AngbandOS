[Serializable]
internal class ChaosSpellBooksItemClass : ItemClass
{
    private ChaosSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Chaos Spellbooks";
}