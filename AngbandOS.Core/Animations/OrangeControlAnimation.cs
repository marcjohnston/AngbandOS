namespace AngbandOS.Core.Animations;

[Serializable]
internal class OrangeControlAnimation : Animation
{
    private OrangeControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeControl";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"!!!!";
}
