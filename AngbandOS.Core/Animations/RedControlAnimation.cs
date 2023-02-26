namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedControlAnimation : Animation
{
    private RedControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedControl";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"!!!!";
}
