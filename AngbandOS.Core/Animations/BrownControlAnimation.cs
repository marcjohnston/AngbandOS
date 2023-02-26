namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownControlAnimation : Animation
{
    private BrownControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownControl";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"!!!!";
}
