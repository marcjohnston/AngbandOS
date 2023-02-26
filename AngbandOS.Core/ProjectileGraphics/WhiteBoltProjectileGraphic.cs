namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class WhiteBoltProjectileGraphic : ProjectileGraphic
{
    private WhiteBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override string Name => "WhiteBolt";
}
