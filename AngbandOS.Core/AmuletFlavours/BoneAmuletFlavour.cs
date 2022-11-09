using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BoneAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Bone";
}
