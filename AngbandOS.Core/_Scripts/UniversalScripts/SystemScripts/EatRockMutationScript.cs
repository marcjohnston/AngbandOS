namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class EatRockMutationScript : UniversalScript, IGetKey
{
    private EatRockMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
        int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
        GridTile cPtr = Game.Map.Grid[y][x];
        if (Game.GridPassable(y, x))
        {
            Game.MsgPrint("You bite into thin air!");
            return;
        }
        if (cPtr.FeatureType.IsPermanent)
        {
            Game.MsgPrint("Ouch!  This wall is harder than your teeth!");
            return;
        }
        if (cPtr.MonsterIndex != 0)
        {
            Game.MsgPrint("There's something in the way!");
            return;
        }
        if (cPtr.FeatureType.IsTree)
        {
            Game.MsgPrint("You don't like the woody taste!");
            return;
        }
        if (cPtr.FeatureType.IsVisibleDoor || cPtr.FeatureType.IsSecretDoor || cPtr.FeatureType.IsRubble)
        {
            Game.SetFood(Game.Food.IntValue + 3000);
        }
        else if (cPtr.FeatureType.IsVein)
        {
            Game.SetFood(Game.Food.IntValue + 5000);
        }
        else
        {
            Game.MsgPrint("This granite is very filling!");
            Game.SetFood(Game.Food.IntValue + 10000);
        }
        Game.RunIdentifiedScriptDirection(nameof(WallToMud1d30p20ProjectileScript), dir);
        int oy = Game.MapY.IntValue;
        int ox = Game.MapX.IntValue;
        Game.MapY.IntValue = y;
        Game.MapX.IntValue = x;
        Game.ConsoleView.RefreshMapLocation(Game.MapY.IntValue, Game.MapX.IntValue);
        Game.ConsoleView.RefreshMapLocation(oy, ox);
        Game.RecenterScreenAroundPlayer();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
    }
}