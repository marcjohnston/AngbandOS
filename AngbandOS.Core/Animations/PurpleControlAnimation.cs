namespace AngbandOS.Core.Animations;

[Serializable]
internal class PurpleControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleControl";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"!!!!";
}
