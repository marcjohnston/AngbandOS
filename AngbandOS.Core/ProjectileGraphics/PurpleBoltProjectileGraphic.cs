namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PurpleBoltProjectileGraphic : ProjectileGraphic
{
    private PurpleBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleBolt";
}
