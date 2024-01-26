// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class StoreFloorTile : Tile
{
    private Symbol _symbol;
    private ColorEnum _color;
    private string _name;
    private string _appearAs;
    private string _description;

    public override bool BlocksLos => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
    public override Symbol Symbol => _symbol;
    public override ColorEnum Color => _color;
    public override string Name => _name;
    public override string AppearAs => _appearAs;
    public override string Description => _description;
    public StoreFloorTile(SaveGame saveGame, Symbol symbol, ColorEnum color, string name, string appearAs, string description) : base(saveGame)
    {
        _symbol = symbol;
        _color = color;
        _name = name;
        _appearAs = appearAs;
        _description = description;
    }
}

