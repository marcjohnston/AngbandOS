namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkPurpleFlashAnimation : Animation
{
    private PinkPurpleFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PinkPurpleFlash";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"********";
}
