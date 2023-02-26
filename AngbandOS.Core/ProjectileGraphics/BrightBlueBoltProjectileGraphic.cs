namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBlueBoltProjectileGraphic : ProjectileGraphic
{
    private BrightBlueBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueBolt";
}
