using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreySplatProjectileGraphic : ProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreySplat";
}
