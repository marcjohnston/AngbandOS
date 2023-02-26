namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowBlueFlashAnimation : Animation
{
    private YellowBlueFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "YellowBlueFlash";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"********";
}
