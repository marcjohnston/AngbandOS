// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class StoreFloorTile : FloorTile
{
    private char _character;
    private Colour _colour;
    private string _name;
    private string _appearAs;
    private string _description;

    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override bool BlocksLos => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
    public override char Character => _character;
    public override Colour Colour => Colour.Green;
    public override string Name => _name;
    public override string AppearAs => _appearAs;
    public override string Description => _description;
    public StoreFloorTile(SaveGame saveGame, char character, Colour colour, string name, string appearAs, string description) : base(saveGame)
    {
        _character = character;
        _colour = colour;
        _name = name;
        _appearAs = appearAs;
        _description = description;
    }
}

