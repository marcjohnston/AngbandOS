namespace AngbandOS.Core.Scripts;
internal class BanishMutationScript : UniversalScript, IGetKey
{
    private BanishMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState) { }
    public override void ExecuteScript()
    {
        if (!Game.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
        int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
        GridTile cPtr = Game.Grid[y][x];
        if (cPtr.Monster is null)
        {
            Game.MsgPrint("You sense no evil there!");
            return;
        }
        Monster mPtr = cPtr.Monster;
        MonsterRace rPtr = mPtr.Race;
        if (rPtr.Evil)
        {
            Game.DeleteMonster(cPtr.Monster);
            Game.MsgPrint("The evil creature vanishes in a puff of sulfurous smoke!");
        }
        else
        {
            Game.MsgPrint("Your invocation is ineffectual!");
        }
    }
}