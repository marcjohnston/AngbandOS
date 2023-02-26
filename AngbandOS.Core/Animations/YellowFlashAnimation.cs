namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowFlashAnimation : Animation
{
    private YellowFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowFlash";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"********";
}
