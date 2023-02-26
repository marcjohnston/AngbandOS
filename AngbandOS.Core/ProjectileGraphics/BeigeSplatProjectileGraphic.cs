namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BeigeSplatProjectileGraphic : ProjectileGraphic
{
    private BeigeSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeSplat";
}
