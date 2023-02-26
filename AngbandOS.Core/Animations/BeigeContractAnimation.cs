namespace AngbandOS.Core.Animations;

[Serializable]
internal class BeigeContractAnimation : Animation
{
    private BeigeContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeContract";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"Oo·";
}
