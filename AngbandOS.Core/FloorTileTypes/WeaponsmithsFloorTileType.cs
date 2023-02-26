namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class WeaponsmithsFloorTileType : FloorTileType
{
    private WeaponsmithsFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '3';
    public override string Name => "Weaponsmiths";
    public override string AppearAs => "Weaponsmiths";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Weapon Smiths";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
