namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ChaosSpellBooksItemClass : ItemClass
{
    private ChaosSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Chaos Spellbook";
}