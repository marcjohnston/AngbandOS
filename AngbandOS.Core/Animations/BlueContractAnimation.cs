namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlueContractAnimation : Animation
{
    private BlueContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueContract";
    public override Colour AlternateColour => Colour.Blue;
    public override string Sequence => @"Oo·";
}
