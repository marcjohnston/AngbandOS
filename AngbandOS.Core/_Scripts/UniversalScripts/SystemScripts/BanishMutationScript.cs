namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class BanishMutationScript : UniversalScript, IGetKey
{
    private BanishMutationScript(Game game) : base(game) { }
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
        if (cPtr.MonsterIndex == 0)
        {
            Game.MsgPrint("You sense no evil there!");
            return;
        }
        Monster mPtr = Game.Monsters[cPtr.MonsterIndex];
        MonsterRace rPtr = mPtr.Race;
        if (rPtr.Evil)
        {
            Game.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
            Game.MsgPrint("The evil creature vanishes in a puff of sulfurous smoke!");
        }
        else
        {
            Game.MsgPrint("Your invocation is ineffectual!");
        }
    }
}