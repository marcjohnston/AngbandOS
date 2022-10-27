using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverSplatProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverSplat";
}
