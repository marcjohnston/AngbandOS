namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class TarotSpellBooksItemClass : ItemClass
{
    private TarotSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Tarot Spellbook";
    public override string Description => Pluralize(Name);
}