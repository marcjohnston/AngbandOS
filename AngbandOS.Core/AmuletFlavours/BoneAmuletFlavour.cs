namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class BoneAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Bone";
}
