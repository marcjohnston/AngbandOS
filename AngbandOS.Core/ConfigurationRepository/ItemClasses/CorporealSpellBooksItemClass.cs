namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class CorporealSpellBooksItemClass : ItemClass
{
    private CorporealSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Corporeal Spellbook";
    public override string Description => Pluralize(Name);
}