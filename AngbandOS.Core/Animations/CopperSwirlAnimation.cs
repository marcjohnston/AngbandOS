namespace AngbandOS.Core.Animations;

[Serializable]
internal class CopperSwirlAnimation : Animation
{
    private CopperSwirlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperSwirl";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
