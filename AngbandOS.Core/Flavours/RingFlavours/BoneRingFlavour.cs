namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BoneRingFlavour : RingFlavour
{
    private BoneRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Bone";
}
