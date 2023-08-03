namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class TarotSpellBooksItemClass : ItemClass
{
    private TarotSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Tarot Spellbooks";
}