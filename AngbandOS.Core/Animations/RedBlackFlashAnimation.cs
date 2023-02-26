namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedBlackFlashAnimation : Animation
{
    private RedBlackFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "RedBlackFlash";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"********";
}
