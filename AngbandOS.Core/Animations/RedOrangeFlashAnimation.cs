namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedOrangeFlashAnimation : Animation
{
    private RedOrangeFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "RedOrangeFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}
