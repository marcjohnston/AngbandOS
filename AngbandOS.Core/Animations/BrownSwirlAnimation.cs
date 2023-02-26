namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownSwirlAnimation : Animation
{
    private BrownSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownSwirl";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
