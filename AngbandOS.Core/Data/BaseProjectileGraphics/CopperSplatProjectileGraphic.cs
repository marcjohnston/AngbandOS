using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperSplatProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperSplat";
}
