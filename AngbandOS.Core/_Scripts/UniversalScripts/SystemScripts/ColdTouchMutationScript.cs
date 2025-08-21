namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class ColdTouchMutationScript : UniversalScript, IGetKey
{
    private ColdTouchMutationScript(Game game) : base(game) { }
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
            Game.MsgPrint("You wave your hands in the air.");
            return;
        }
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile));
        projectile.TargetedFire(dir, 2 * Game.ExperienceLevel.IntValue, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
    }
}