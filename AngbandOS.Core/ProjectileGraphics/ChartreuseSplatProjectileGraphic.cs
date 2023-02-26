namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class ChartreuseSplatProjectileGraphic : ProjectileGraphic
{
    private ChartreuseSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseSplat";
}
