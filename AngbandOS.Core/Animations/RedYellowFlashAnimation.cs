namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedYellowFlashAnimation : Animation
{
    private RedYellowFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "RedYellowFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}
