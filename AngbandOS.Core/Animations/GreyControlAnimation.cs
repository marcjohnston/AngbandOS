namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyControlAnimation : Animation
{
    private GreyControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyControl";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"!!!!";
}
