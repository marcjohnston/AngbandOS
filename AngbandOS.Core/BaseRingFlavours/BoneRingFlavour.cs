using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BoneRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Bone";
}
