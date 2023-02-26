namespace AngbandOS.Core.Animations;

[Serializable]
internal class GoldContractAnimation : Animation
{
    private GoldContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldContract";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"Oo·";
}
