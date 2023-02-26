namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightYellowSplatProjectileGraphic : ProjectileGraphic
{
    private BrightYellowSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowSplat";
}
