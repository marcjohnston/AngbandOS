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
                int dummy = Game.ExperienceLevel.IntValue + (Game.DieRoll(Game.ExperienceLevel.IntValue) * Math.Max(1, Game.ExperienceLevel.IntValue / 10));
                if (Game.DrainLife(direction, dummy))
                {
                    if (Game.Food.IntValue < Constants.PyFoodFull)
                    {
                        Game.RestoreHealth(dummy);
                    }
                    else
                    {
                        Game.MsgPrint("You were not hungry.");
                    }
                    dummy = Game.Food.IntValue + Math.Min(5000, 100 * dummy);
                    if (Game.Food.IntValue < Constants.PyFoodMax)
                    {
                        Game.SetFood(dummy >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : dummy);
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