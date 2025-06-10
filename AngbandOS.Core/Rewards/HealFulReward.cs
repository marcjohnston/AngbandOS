// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Rewards;

[Serializable]
internal class HealFulReward : Reward
{
    private HealFulReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"The voice of {patron.ShortName} booms out:");
        Game.MsgPrint("'Rise, my servant!'");
        Game.RunScript(nameof(RestoreLevelScript));
        Game.PoisonTimer.ResetTimer();
        Game.BlindnessTimer.ResetTimer();
        Game.ConfusedTimer.ResetTimer();
        Game.HallucinationsTimer.ResetTimer();
        Game.StunTimer.ResetTimer();
        Game.BleedingTimer.ResetTimer();
        Game.RestoreHealth(5000);
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            Game.TryRestoringAbilityScore(ability);
        }
    }
}