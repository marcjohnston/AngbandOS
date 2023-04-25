namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ScrollFlavour : Flavour
{
    private readonly char _character;
    private readonly Colour _colour;
    private readonly string _name;

    public override char Character => _character;
    public override Colour Colour => _colour;
    public override string Name => _name;
    public ScrollFlavour(SaveGame saveGame, char character, Colour color, string Name) : base(saveGame)
    {
        _character = character;
        _colour = color;
        _name = Name;
    }
}
