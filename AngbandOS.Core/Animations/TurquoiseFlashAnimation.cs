namespace AngbandOS.Core.Animations;

[Serializable]
internal class TurquoiseFlashAnimation : Animation
{
    private TurquoiseFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseFlash";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"********";
}
