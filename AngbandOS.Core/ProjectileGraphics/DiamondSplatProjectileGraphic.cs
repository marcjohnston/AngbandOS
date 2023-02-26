namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class DiamondSplatProjectileGraphic : ProjectileGraphic
{
    private DiamondSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondSplat";
}
