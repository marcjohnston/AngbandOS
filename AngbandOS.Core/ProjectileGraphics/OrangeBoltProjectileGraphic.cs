namespace AngbandOS.Core;

[Serializable]
internal class OrangeBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeBolt";
}
