namespace AngbandOS.Core.Animations;

[Serializable]
internal class BeigeControlAnimation : Animation
{
    private BeigeControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeControl";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"!!!!";
}
