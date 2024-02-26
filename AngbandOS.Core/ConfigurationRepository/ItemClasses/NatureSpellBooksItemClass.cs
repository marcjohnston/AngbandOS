namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class NatureSpellBooksItemClass : ItemClass
{
    private NatureSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Nature Spellbook";
}