namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackControlAnimation : Animation
{
    private BlackControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackControl";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"!!!!";
}
