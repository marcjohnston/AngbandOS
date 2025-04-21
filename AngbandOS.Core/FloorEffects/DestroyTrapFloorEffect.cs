// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FloorEffects;

[Serializable]
internal class DestroyTrapFloorEffect : FloorEffect
{
    private DestroyTrapFloorEffect(Game game) : base(game) { } // This object is a singleton.

    public override bool Apply(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsUnidentifiedTrap || cPtr.FeatureType.IsTrap)
        {
            if (Game.PlayerHasLosBold(y, x))
            {
                Game.MsgPrint("There is a bright flash of light!");
                obvious = true;
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
        }
        else if (cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsClosedDoor)
        {
            Game.CaveSetFeat(y, x, Game.SingletonRepository.Get<Tile>(nameof(LockedDoor0Tile)));
            if (Game.PlayerHasLosBold(y, x))
            {
                Game.MsgPrint("Click!");
                obvious = true;
            }
        }
        return obvious;
    }
}
