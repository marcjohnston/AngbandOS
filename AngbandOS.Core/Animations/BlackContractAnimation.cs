namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackContractAnimation : Animation
{
    private BlackContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackContract";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"Oo·";
}
