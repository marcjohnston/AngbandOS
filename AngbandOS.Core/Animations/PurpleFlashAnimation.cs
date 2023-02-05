namespace AngbandOS.Core.Animations;

[Serializable]
internal class PurpleFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleFlash";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"********";
}
