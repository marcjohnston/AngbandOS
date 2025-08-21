namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class PanicHitMutationScript : UniversalScript, IGetKey
{
    private PanicHitMutationScript(Game game) : base(game) { }
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
        if (Game.Map.Grid[y][x].MonsterIndex != 0)
        {
            Game.PlayerAttackMonster(y, x);
            Game.RunScript(nameof(TeleportSelf30TeleportSelfScript));
        }
        else
        {
            Game.MsgPrint("You don't see any monster in this direction");
            Game.MsgPrint(string.Empty);
        }
    }
}