namespace AngbandOS.Core.Scripts;

// Vampires can drain health
[Serializable]
internal class VampireRacialPowerScript : Script, IScript
{
    private VampireRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionNoAim(out int direction))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[direction];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[direction];
            GridTile tile = Game.Map.Grid[y][x];
            if (tile.MonsterIndex == 0)
            {
                Game.MsgPrint("You bite into thin air!");
            }
            else
            {
                Game.MsgPrint("You grin and bare your fangs...");
                int damage = Game.ExperienceLevel.IntValue + (Game.DieRoll(Game.ExperienceLevel.IntValue) * Math.Max(1, Game.ExperienceLevel.IntValue / 10));
                Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(OldDrainLifeProjectile));
                IsNoticedEnum isNoticed = projectile.TargetedFire(direction, damage, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
                if (isNoticed == IsNoticedEnum.True)
                {
                    if (Game.Food.IntValue < Constants.PyFoodFull)
                    {
                        Game.RestoreHealth(damage);
                    }
                    else
                    {
                        Game.MsgPrint("You were not hungry.");
                    }
                    damage = Game.Food.IntValue + Math.Min(5000, 100 * damage);
                    if (Game.Food.IntValue < Constants.PyFoodMax)
                    {
                        Game.SetFood(damage >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : damage);
                    }
                }
                else
                {
                    Game.MsgPrint("Yechh. That tastes foul.");
                }
            }
        }
    }
}