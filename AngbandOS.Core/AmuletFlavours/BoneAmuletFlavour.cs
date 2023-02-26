namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class BoneAmuletFlavour : AmuletFlavour
{
    private BoneAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Bone";
}
