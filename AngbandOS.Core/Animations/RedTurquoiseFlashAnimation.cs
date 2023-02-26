namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedTurquoiseFlashAnimation : Animation
{
    private RedTurquoiseFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "RedTurquoiseFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}
