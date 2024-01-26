// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ScrollFlavour : Flavour
{
    private readonly Symbol _symbol;
    private readonly ColorEnum _color;
    private readonly string _name;

    public override Symbol Symbol => _symbol;
    public override ColorEnum Color => _color;
    public override string Name => _name;
    public ScrollFlavour(SaveGame saveGame, Symbol symbol, ColorEnum color, string Name) : base(saveGame)
    {
        _symbol = symbol;
        _color = color;
        _name = Name;
    }
}
