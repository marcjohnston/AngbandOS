namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BeigeBoltProjectileGraphic : ProjectileGraphic
{
    private BeigeBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeBolt";
}
