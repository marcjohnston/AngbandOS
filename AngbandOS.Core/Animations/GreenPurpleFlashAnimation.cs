namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenPurpleFlashAnimation : Animation
{
    private GreenPurpleFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "GreenPurpleFlash";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"********";
}
