namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyFlashAnimation : Animation
{
    private GreyFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyFlash";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"********";
}
