namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class GreatOneRaceTravelRacialPowerScript : Script, IScript
{
    private GreatOneRaceTravelRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You start walking around. Your surroundings change.");
        Game.DoCmdSaveGame(true);
        Game.NewLevelFlag = true;
        Game.CameFrom = LevelStartEnum.StartRandom;
    }
}