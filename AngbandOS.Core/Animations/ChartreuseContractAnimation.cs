namespace AngbandOS.Core.Animations;

[Serializable]
internal class ChartreuseContractAnimation : Animation
{
    private ChartreuseContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseContract";
    public override Colour AlternateColour => Colour.Chartreuse;
    public override string Sequence => @"Oo·";
}
