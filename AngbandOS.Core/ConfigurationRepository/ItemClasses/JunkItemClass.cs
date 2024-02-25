namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class JunkItemClass : ItemClass
{
    private JunkItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Junk";
    public override string Description => "Junk";
}