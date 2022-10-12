using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteSplatProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '*';
    public override string Name => "WhiteSplat";
}
