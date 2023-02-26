namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowContractAnimation : Animation
{
    private YellowContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowContract";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"Oo·";
}
