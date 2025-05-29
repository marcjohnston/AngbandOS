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
        Game.BleedingTimer.ResetTimer();
        Game.BlindnessTimer.ResetTimer();
        Game.FearTimer.ResetTimer();
        Game.TryRestoringAbilityScore(Game.StrengthAbility);
        Game.TryRestoringAbilityScore(Game.IntelligenceAbility);
        Game.TryRestoringAbilityScore(Game.WisdomAbility);
        Game.TryRestoringAbilityScore(Game.DexterityAbility);
        Game.TryRestoringAbilityScore(Game.ConstitutionAbility);
        Game.TryRestoringAbilityScore(Game.CharismaAbility);
        Game.RunScript(nameof(RestoreLevelScript));
    }
}