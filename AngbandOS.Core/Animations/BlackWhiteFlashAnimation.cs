namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackWhiteFlashAnimation : Animation
{
    private BlackWhiteFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BlackWhiteFlash";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"********";
}
