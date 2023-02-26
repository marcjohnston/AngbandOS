namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightPurpleBoltProjectileGraphic : ProjectileGraphic
{
    private BrightPurpleBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleBolt";
}
