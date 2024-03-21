namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class CorporealSpellBooksItemClass : ItemClass
{
    private CorporealSpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Corporeal Spellbook";
}