namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class DeathSpellBooksItemClass : ItemClass
{
    private DeathSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Death Spellbook";
    public override string Description => Pluralize(Name);
}