namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackFlashAnimation : Animation
{
    private BlackFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackFlash";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"********";
}
