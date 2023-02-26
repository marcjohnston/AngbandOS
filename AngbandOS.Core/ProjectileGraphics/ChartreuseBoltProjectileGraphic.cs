namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class ChartreuseBoltProjectileGraphic : ProjectileGraphic
{
    private ChartreuseBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseBolt";
}
