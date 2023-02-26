namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteControlAnimation : Animation
{
    private WhiteControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteControl";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"!!!!";
    public override Colour Colour => Colour.White;
}
