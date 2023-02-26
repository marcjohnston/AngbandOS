namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightPurpleSplatProjectileGraphic : ProjectileGraphic
{
    private BrightPurpleSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleSplat";
}
