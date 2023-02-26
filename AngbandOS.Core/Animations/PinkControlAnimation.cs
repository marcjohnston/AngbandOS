namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkControlAnimation : Animation
{
    private PinkControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkControl";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"!!!!";
}
