[Serializable]
internal class SpikesItemClass : ItemClass
{
    private SpikesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Spikes";
}