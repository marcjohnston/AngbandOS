namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightRedBoltProjectileGraphic : ProjectileGraphic
{
    private BrightRedBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedBolt";
}
