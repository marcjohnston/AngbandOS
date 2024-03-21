namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SorcerySpellBooksItemClass : ItemClass
{
    private SorcerySpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Sorcery Spellbook";
}