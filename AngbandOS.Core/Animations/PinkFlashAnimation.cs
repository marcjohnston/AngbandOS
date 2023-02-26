namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkFlashAnimation : Animation
{
    private PinkFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "PinkFlash";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"********";
}
