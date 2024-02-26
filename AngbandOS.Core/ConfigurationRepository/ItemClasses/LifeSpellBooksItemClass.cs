namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class LifeSpellBooksItemClass : ItemClass
{
    private LifeSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Life Spellbook";
}