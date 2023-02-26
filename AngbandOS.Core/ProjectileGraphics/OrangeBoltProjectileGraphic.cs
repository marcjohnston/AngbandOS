namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class OrangeBoltProjectileGraphic : ProjectileGraphic
{
    private OrangeBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeBolt";
}
