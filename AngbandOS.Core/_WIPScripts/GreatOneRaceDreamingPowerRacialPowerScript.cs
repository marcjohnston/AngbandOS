namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class GreatOneRaceDreamingPowerRacialPowerScript : Script, IScript
{
    private GreatOneRaceDreamingPowerRacialPowerScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        Game.MsgPrint("You dream of a time of health and peace...");
        Game.PoisonTimer.ResetTimer();
        Game.HallucinationsTimer.ResetTimer();
        Game.StunTimer.ResetTimer();
        Game.RunScript(nameof(BleedingResetTimerScript));
        Game.BlindnessTimer.ResetTimer();
        Game.FearTimer.ResetTimer();
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            Game.TryRestoringAbilityScore(ability);
        }
        Game.RunScript(nameof(RestoreLevelScript));
    }
}