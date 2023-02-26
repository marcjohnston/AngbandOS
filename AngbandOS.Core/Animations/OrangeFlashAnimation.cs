namespace AngbandOS.Core.Animations;

[Serializable]
internal class OrangeFlashAnimation : Animation
{
    private OrangeFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeFlash";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"********";
}
