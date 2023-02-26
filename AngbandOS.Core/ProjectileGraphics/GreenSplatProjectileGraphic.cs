namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GreenSplatProjectileGraphic : ProjectileGraphic
{
    private GreenSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenSplat";
}
