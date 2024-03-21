namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class NatureSpellBooksItemClass : ItemClass
{
    private NatureSpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Nature Spellbook";
}