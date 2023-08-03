// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// A single grid tile in either the dungeon, town, or wilderness
/// </summary>
[Serializable]
internal class GridTile : IItemContainer
{
    protected readonly SaveGame SaveGame;
    public readonly int X;
    public readonly int Y;
    public GridTile(SaveGame saveGame, int x, int y)
    {
        SaveGame = saveGame;
        X = x;
        Y = y;
        BackgroundFeature = SaveGame.SingletonRepository.Tiles["Nothing"];
        FeatureType = SaveGame.SingletonRepository.Tiles["Nothing"];
    }

    /// <summary>
    /// Used within the view code to mark tiles that are "easily" visible
    /// </summary>
    public const int EasyVisibility = 0x0080;

    /// <summary>
    /// Set if the grid tile is part of a room
    /// </summary>
    public const int InRoom = 0x0008;

    /// <summary>
    /// Set if the grid tile is part of a vault
    /// </summary>
    public const int InVault = 0x0004;

    /// <summary>
    /// Set if the grid tile is visible to the player
    /// </summary>
    public const int IsVisible = 0x0020;

    /// <summary>
    /// Set if the grid tile is currently lit by the player's light source
    /// </summary>
    public const int PlayerLit = 0x0010;

    /// <summary>
    /// Set if the player should remember the grid's contents
    /// </summary>
    public const int PlayerMemorized = 0x0001;

    /// <summary>
    /// Set if the grid tile is lit independently of the player's light source
    /// </summary>
    public const int SelfLit = 0x0002;

    /// <summary>
    /// Used within the view and light code to mark tiles that might need a redraw
    /// </summary>
    public const int TempFlag = 0x0040;

    /// <summary>
    /// Set if the grid tile has had a Detect Traps used on it
    /// </summary>
    public const int TrapsDetected = 0x0100;

    /// <summary>
    /// Flags for the tile
    /// </summary>
    public readonly FlagSet TileFlags = new FlagSet();

    /// <summary>
    /// The type of feature in this grid tile
    /// </summary>
    public Tile BackgroundFeature;

    /// <summary>
    /// The type of feature in this grid tile
    /// </summary>
    public Tile FeatureType;

    /// <summary>
    /// The index of the first item that is in this grid tile
    /// </summary>
    public List<Item> Items = new List<Item>();

    /// <summary>
    /// The index of the monster that is in this grid tile
    /// </summary>
    public int MonsterIndex;

    /// <summary>
    /// The time since the player's scent in the tile was calculated
    /// </summary>
    public int ScentAge;

    /// <summary>
    /// The strength of the player's scent in this tile
    /// </summary>
    public int ScentStrength;

    public string DescribeItemLocation(Item oPtr) => $"On the ground:";

    public string Label(Item oPtr) => ""; // TODO: Items on the floor cannot be selected yet.

    public string TakeOffMessage(Item oPtr) => ""; // TODO: Grid tiles do not support removal messages yet.

    /// <summary>
    /// Modifies the quantity of an item.  No player stats are modified.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ItemIncrease(Item oPtr, int num)
    {
        num += oPtr.Count;
        if (num > 255)
        {
            num = 255;
        }
        else if (num < 0)
        {
            num = 0;
        }
        num -= oPtr.Count;
        oPtr.Count += num;
    }

    /// <summary>
    /// Renders a description of the item.  For a non-inventory slot, the description is rendered as the player viewing the item.
    /// </summary>
    /// <param name="item"></param>
    public void ItemDescribe(Item oPtr)
    {
        string oName = oPtr.Description(true, 3);
        SaveGame.MsgPrint($"You see {oName}.");
    }

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quantity is zero. 
    /// </summary>
    /// <param name="oPtr"></param>
    public void ItemOptimize(Item oPtr)
    {
        if (oPtr.Count != 0)
        {
            return;
        }
        Items.Remove(oPtr);
    }

    public void AddItem(Item oPtr)
    {
        Items.Add(oPtr);
    }

    public void RemoveItem(Item oPtr)
    {
        Items.Remove(oPtr);
    }

    public void ProcessWorld()
    {
        foreach (Item oPtr in Items)
        {
            oPtr.ProcessWorld();
        }
    }

    /// <summary>
    /// Returns false, because the item container doesn't belong to the players inventory.
    /// </summary>
    public bool IsInInventory => false;
    public bool IsInEquipment => false;

    public void RevertToBackground()
    {
        FeatureType = BackgroundFeature;
    }

    public void SetBackgroundFeature(string name)
    {
        BackgroundFeature = SaveGame.SingletonRepository.Tiles[name];
    }

    /// <summary>
    /// Sets the FeatureType of the tile to a named FloorTileType
    /// </summary>
    /// <param name="name"> </param>
    public void SetFeature(string name)
    {
        FeatureType = SaveGame.SingletonRepository.Tiles[name];
    }

    public override string ToString()
    {
        if (FeatureType == null)
        {
            return "Null Feature";
        }
        else
        {
            return FeatureType.Name;
        }
    }
}