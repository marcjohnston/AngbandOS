// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.GridTileEffects;

[Serializable]
internal class DestroyTrapOrDoorGridTileEffect : GridTileEffect
{
    private DestroyTrapOrDoorGridTileEffect(Game game) : base(game) { } // This object is a singleton.

    public override IsNoticedEnum Apply(int x, int y)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        IsNoticedEnum isNoticed = IsNoticedEnum.False;
        if (cPtr.FeatureType.IsVisibleDoor || cPtr.FeatureType.IsOpenDoor || cPtr.FeatureType.IsUnidentifiedTrap || cPtr.FeatureType.IsTrap)
        {
            if (Game.GridTileIsVisible(y, x))
            {
                Game.MsgPrint("There is a bright flash of light!");
                isNoticed = IsNoticedEnum.True;
                if (cPtr.FeatureType.IsVisibleDoor)
                {
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
                    Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
                }
            }
            cPtr.PlayerMemorized = false;
            Game.RevertTileToBackground(y, x);
        }
        return isNoticed;
    }
}
