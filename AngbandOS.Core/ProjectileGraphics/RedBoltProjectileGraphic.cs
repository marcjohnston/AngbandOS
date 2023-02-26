namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class RedBoltProjectileGraphic : ProjectileGraphic
{
    private RedBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedBolt";
}
