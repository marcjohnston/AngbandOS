namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class DeathSpellBooksItemClass : ItemClass
{
    private DeathSpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Death Spellbooks";
}