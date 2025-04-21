// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FloorEffects;

[Serializable]
internal class WallToMudFloorEffect : FloorEffect
{
    private WallToMudFloorEffect(Game game) : base(game) { } // This object is a singleton.

    public override bool Apply(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        if (Game.GridPassable(y, x))
        {
            return false;
        }
        if (cPtr.FeatureType.IsPermanent)
        {
            return false;
        }
        if (cPtr.FeatureType.IsTreasure)
        {
            if (cPtr.PlayerMemorized)
            {
                Game.MsgPrint("The vein turns into mud!");
                Game.MsgPrint("You have found something!");
                obvious = true;
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
            Game.PlaceGold(y, x);
        }
        else if (cPtr.FeatureType.IsVein)
        {
            if (cPtr.PlayerMemorized)
            {
                Game.MsgPrint("The vein turns into mud!");
                obvious = true;
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
        }
        else if (cPtr.FeatureType.IsWall)
        {
            if (cPtr.PlayerMemorized)
            {
                Game.MsgPrint("The wall turns into mud!");
                obvious = true;
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
        }
        else if (cPtr.FeatureType is RubbleTile)
        {
            if (cPtr.PlayerMemorized)
            {
                Game.MsgPrint("The rubble turns into mud!");
                obvious = true;
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
            if (Game.RandomLessThan(100) < 10)
            {
                if (Game.PlayerCanSeeBold(y, x))
                {
                    Game.MsgPrint("There was something buried in the rubble!");
                    obvious = true;
                }
                Game.PlaceObject(y, x, false, false);
            }
        }
        else
        {
            if (cPtr.PlayerMemorized)
            {
                Game.MsgPrint("The door turns into mud!");
                obvious = true;
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        return obvious;
    }
}
