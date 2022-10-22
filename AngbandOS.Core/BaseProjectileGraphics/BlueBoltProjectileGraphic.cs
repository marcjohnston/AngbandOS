using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlueBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueBolt";
}
