namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class TarotSpellBooksItemClass : ItemClass
{
    private TarotSpellBooksItemClass(Game game) : base(game) { }
    public override string Name => "Tarot Spellbook";
}