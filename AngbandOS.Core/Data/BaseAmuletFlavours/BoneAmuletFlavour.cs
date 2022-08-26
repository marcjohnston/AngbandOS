using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BoneAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Bone";
}
