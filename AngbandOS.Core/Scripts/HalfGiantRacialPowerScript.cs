namespace AngbandOS.Core.Scripts;

// Half-giants can bash through stone walls
[Serializable]
internal class HalfGiantRacialPowerScript : Script, IScript
{
    private HalfGiantRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        if (Game.GetDirectionWithAim(out int direction))
        {
            Game.MsgPrint("You bash at a stone wall.");
            Game.RunIdentifiedScriptDirection(nameof(WallToMud1d30p20ProjectileScript), direction);
        }
    }
}