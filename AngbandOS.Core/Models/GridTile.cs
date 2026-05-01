// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// A single grid tile in either the dungeon, town, or wilderness.  Grid tiles are also containers for items; as they can have one or more items on the tile.
/// </summary>
[Serializable]
internal class GridTile : IItemContainer, IGameSerialize
{
    private Game Game { get; }
    private TrapsDetectedProperty _trapsDetectedProperty { get; }

    /// <summary>
    /// The type of feature in this grid tile
    /// </summary>
    private Tile _backgroundFeature { get; set; }

    /// <summary>
    /// The type of feature in this grid tile
    /// </summary>
    private Tile _featureType { get; set; }

    public Tile FeatureType => _featureType;
    public Tile BackgroundFeature => _backgroundFeature;

    public GridTile(Game game)
    {
        Game = game;
        _trapsDetectedProperty = (TrapsDetectedProperty)Game.SingletonRepository.Get<Property>(nameof(TrapsDetectedProperty));
        _backgroundFeature = Game.SingletonRepository.Get<Tile>(nameof(NothingTile));
        _featureType = _backgroundFeature;
    }
    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(EasyVisibility), saveGameState.CreateGameStateBag(EasyVisibility)),
            (nameof(InRoom), saveGameState.CreateGameStateBag(InRoom)),
            (nameof(InVault), saveGameState.CreateGameStateBag(InVault)),
            (nameof(IsVisible), saveGameState.CreateGameStateBag(IsVisible)),
            (nameof(PlayerLit), saveGameState.CreateGameStateBag(PlayerLit)),
            (nameof(PlayerMemorized), saveGameState.CreateGameStateBag(PlayerMemorized)),
            (nameof(SelfLit), saveGameState.CreateGameStateBag(SelfLit)),
            (nameof(TempFlag), saveGameState.CreateGameStateBag(TempFlag)),
            (nameof(_trapsDetected), saveGameState.CreateGameStateBag(_trapsDetected)),
            (nameof(Items), saveGameState.CreateGameStateBag(Items)),
            (nameof(MonsterIndex), saveGameState.CreateGameStateBag(MonsterIndex)),
            (nameof(ScentAge), saveGameState.CreateGameStateBag(ScentAge)),
            (nameof(ScentStrength), saveGameState.CreateGameStateBag(ScentStrength)),
            (nameof(_backgroundFeature), saveGameState.CreateGameStateBag(_backgroundFeature)),
            (nameof(_featureType), saveGameState.CreateGameStateBag(_featureType))
        );
    }

    public GridTile(Game game, RestoreGameState restoreGameState)
    {
        Game = game;
        _trapsDetectedProperty = (TrapsDetectedProperty)Game.SingletonRepository.Get<Property>(nameof(TrapsDetectedProperty));
        EasyVisibility = restoreGameState.GetBool(nameof(EasyVisibility));
        InRoom = restoreGameState.GetBool(nameof(InRoom));
        InVault = restoreGameState.GetBool(nameof(InVault));
        IsVisible = restoreGameState.GetBool(nameof(IsVisible));
        PlayerLit = restoreGameState.GetBool(nameof(PlayerLit));
        PlayerMemorized = restoreGameState.GetBool(nameof(PlayerMemorized));
        SelfLit = restoreGameState.GetBool(nameof(SelfLit));
        TempFlag = restoreGameState.GetBool(nameof(TempFlag));
        _trapsDetected = restoreGameState.GetBool(nameof(_trapsDetected));
        Items = restoreGameState.GetReferences<Item>(nameof(Items)).ToList();
        MonsterIndex = restoreGameState.GetInt(nameof(MonsterIndex));
        ScentAge = restoreGameState.GetInt(nameof(ScentAge));
        ScentStrength = restoreGameState.GetInt(nameof(ScentStrength));
        _backgroundFeature = restoreGameState.GetReference<Tile>(nameof(_backgroundFeature));
        _featureType = restoreGameState.GetReference<Tile>(nameof(_featureType));
    }

    #region State Data
    /// <summary>
    /// Used within the view code to mark tiles that are "easily" visible
    /// </summary>
    public bool EasyVisibility;

    /// <summary>
    /// Set if the grid tile is part of a room
    /// </summary>
    public bool InRoom;

    /// <summary>
    /// Set if the grid tile is part of a vault
    /// </summary>
    public bool InVault;

    /// <summary>
    /// Set if the grid tile is visible to the player
    /// </summary>
    public bool IsVisible;

    /// <summary>
    /// Set if the grid tile is currently lit by the player's light source
    /// </summary>
    public bool PlayerLit;

    /// <summary>
    /// Set if the player should remember the grid's contents
    /// </summary>
    public bool PlayerMemorized;

    /// <summary>
    /// Set if the grid tile is lit independently of the player's light source
    /// </summary>
    public bool SelfLit;

    /// <summary>
    /// Used within the view and light code to mark tiles that might need a redraw
    /// </summary>
    public bool TempFlag;

    private bool _trapsDetected;

    /// <summary>
    /// The index of the first item that is in this grid tile
    /// </summary>
    public List<Item> Items = new List<Item>(); // TODO: Publically, this needs to be an array

    /// <summary>
    /// The index of the monster that is in this grid tile
    /// </summary>
    public int MonsterIndex; // TODO: This should be a nullable reference to a monster.

    /// <summary>
    /// The time since the player's scent in the tile was calculated
    /// </summary>
    public int ScentAge;

    /// <summary>
    /// The strength of the player's scent in this tile
    /// </summary>
    public int ScentStrength;

    #endregion

    private TrapsDetectedProperty TrapsDetectedProperty { get; }

    /// <summary>
    /// Set if the grid tile has had a Detect Traps used on it
    /// </summary>
    public bool TrapsDetected
    {
        get
        {
            return _trapsDetected;
        }
        set
        {
            _trapsDetected = value;
            _trapsDetectedProperty.SetChangedFlag();
        }
    }
    public string DescribeItemLocation(Item oPtr) => $"On the ground:";

    public string Label(Item oPtr) => ""; // TODO: Items on the floor cannot be selected yet.

    public string TakeOffMessage(Item oPtr) => ""; // TODO: Grid tiles do not support removal messages yet.

    /// <summary>
    /// Modifies the quantity of an item.  No player stats are modified.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ModifyItemStackCount(Item oPtr, int num)
    {
        oPtr.ModifyStackCount(num);
    }

    /// <summary>
    /// Renders a description of the item.  For a non-inventory slot, the description is rendered as the player viewing the item.
    /// </summary>
    /// <param name="item"></param>
    public string DescribeContainer(Item oPtr)
    {
        string oName = oPtr.GetFullDescription(true);
        return $"You see {oName}.";
    }

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quantity is zero. 
    /// </summary>
    /// <param name="oPtr"></param>
    public void ItemOptimize(Item oPtr)
    {
        if (oPtr.StackCount != 0)
        {
            return;
        }
        Items.Remove(oPtr);
    }

    //public void AddItem(Item oPtr)
    //{
    //    Items.Add(oPtr);
    //}

    //public void RemoveItem(Item oPtr)
    //{
    //    Items.Remove(oPtr);
    //}

    public void ProcessWorld()
    {
        foreach (Item oPtr in Items)
        {
            oPtr.GridProcessWorld(this);
        }
    }

    /// <summary>
    /// Returns false, because the item container doesn't belong to the players inventory.
    /// </summary>
    public bool IsWielded => false;
    public bool IsWieldedAsEquipment => false;

    public void RevertToBackground()
    {
        _featureType = _backgroundFeature;
    }

    public void SetBackgroundFeature(Tile tile)
    {
        _backgroundFeature = tile;
    }

    public void SetFeature(Tile tile)
    {
        _featureType = tile;
    }

    public override string ToString()
    {
        if (_featureType == null)
        {
            return "Null Feature";
        }
        else
        {
            return _featureType.Description;
        }
    }
}