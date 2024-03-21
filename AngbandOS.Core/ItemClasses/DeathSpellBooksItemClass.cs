namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class DeathSpellBooksItemClass : ItemClass
{
    private DeathSpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Death Spellbook";
}