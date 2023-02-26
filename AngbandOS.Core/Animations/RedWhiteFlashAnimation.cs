namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedWhiteFlashAnimation : Animation
{
    private RedWhiteFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "RedWhiteFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}
