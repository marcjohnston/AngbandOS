namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class GlovesItemClass : ItemClass
{
    private GlovesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Gloves";
    public override string Description => "Gloves";
}