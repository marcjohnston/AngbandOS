namespace AngbandOS.Core.Scripts;

/// <summary>
/// Allows the player to select and run a dream or travel racial power.
/// </summary>
[Serializable]
internal class GreatOneRacialPowerScript : Script, IScript
{
    private GreatOneRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        // Great ones can heal themselves or swap to a new level
        int dreamPower;
        while (true)
        {
            if (!Game.GetCom("Use Dream [T]ravel or [D]reaming? ", out char ch))
            {
                dreamPower = 0;
                break;
            }
            if (ch == 'D' || ch == 'd')
            {
                dreamPower = 1;
                break;
            }
            if (ch == 'T' || ch == 't')
            {
                dreamPower = 2;
                break;
            }
        }
        if (dreamPower == 1)
        {
            Game.RunScript(nameof(GreatOneRaceDreamingPowerRacialPowerConditionalScript));
        }
        else if (dreamPower == 2)
        {
            Game.RunScript(nameof(GreatOneRaceTravelPowerRacialPowerConditionalScript));
        }
    }
}