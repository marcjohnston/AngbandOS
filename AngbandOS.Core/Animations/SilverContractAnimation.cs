namespace AngbandOS.Core.Animations;

[Serializable]
internal class SilverContractAnimation : Animation
{
    private SilverContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverContract";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"Oo·";
}
