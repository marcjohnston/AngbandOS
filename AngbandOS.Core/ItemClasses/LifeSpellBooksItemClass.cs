namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class LifeSpellBooksItemClass : ItemClass
{
    private LifeSpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Life Spellbook";
}