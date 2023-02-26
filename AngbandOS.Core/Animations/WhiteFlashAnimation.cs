namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteFlashAnimation : Animation
{
    private WhiteFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteFlash";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"********";
    public override Colour Colour => Colour.White;
}
