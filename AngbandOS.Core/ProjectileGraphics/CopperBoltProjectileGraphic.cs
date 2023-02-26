namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class CopperBoltProjectileGraphic : ProjectileGraphic
{
    private CopperBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperBolt";
}
