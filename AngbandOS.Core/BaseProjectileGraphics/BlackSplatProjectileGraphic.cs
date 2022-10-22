using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackSplatProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackSplat";
}
