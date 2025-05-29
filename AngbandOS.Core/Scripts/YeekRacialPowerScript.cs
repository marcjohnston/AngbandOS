namespace AngbandOS.Core.Scripts;

// Yeeks can scream
[Serializable]
internal class YeekRacialPowerScript : Script, IScript
{
    private YeekRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.MsgPrint("You make a horrible scream!");
            Game.ScareMonster(direction, Game.ExperienceLevel.IntValue);
        }
    }
}