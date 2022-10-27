using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreySplatProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreySplat";
}
