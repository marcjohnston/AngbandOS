namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenFlashAnimation : Animation
{
    private GreenFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenFlash";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"********";
}
