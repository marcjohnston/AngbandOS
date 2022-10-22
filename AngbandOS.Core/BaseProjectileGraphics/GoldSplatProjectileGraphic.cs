using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldSplatProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldSplat";
}
