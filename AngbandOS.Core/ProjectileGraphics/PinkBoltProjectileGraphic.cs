namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PinkBoltProjectileGraphic : ProjectileGraphic
{
    private PinkBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkBolt";
}
