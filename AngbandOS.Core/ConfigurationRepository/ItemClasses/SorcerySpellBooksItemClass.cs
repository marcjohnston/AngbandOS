namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SorcerySpellBooksItemClass : ItemClass
{
    private SorcerySpellBooksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Sorcery Spellbooks";
}