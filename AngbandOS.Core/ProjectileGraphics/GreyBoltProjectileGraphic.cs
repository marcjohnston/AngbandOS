namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GreyBoltProjectileGraphic : ProjectileGraphic
{
    private GreyBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyBolt";
}
