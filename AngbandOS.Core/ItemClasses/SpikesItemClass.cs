namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class SpikesItemClass : ItemClass
{
    private SpikesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Spike";
}