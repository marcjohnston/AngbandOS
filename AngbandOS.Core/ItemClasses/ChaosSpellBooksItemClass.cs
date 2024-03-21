namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ChaosSpellBooksItemClass : ItemClass
{
    private ChaosSpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Chaos Spellbook";
}