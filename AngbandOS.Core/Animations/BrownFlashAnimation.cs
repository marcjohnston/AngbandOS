namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownFlash";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"********";
}
