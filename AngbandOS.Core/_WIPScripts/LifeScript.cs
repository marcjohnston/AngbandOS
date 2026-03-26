// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class LifeScript : Script, IEatOrQuaffScript
{
    private LifeScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        // Life heals you 5000 health, removes experience and ability score drains, and
        // cures blindness, confusion, stun, poison, and bleeding
        Game.MsgPrint("You feel life flow through your body!");
        Game.RunScript(nameof(RestoreLevelScript));
        Game.RestoreHealth(5000);
        Game.PoisonTimer.ResetTimer();
        Game.BlindnessTimer.ResetTimer();
        Game.ConfusionTimer.ResetTimer();
        Game.HallucinationsTimer.ResetTimer();
        Game.StunTimer.ResetTimer();
        Game.PoisonTimer.ResetTimer();
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            Game.TryRestoringAbilityScore(ability);
        }
        return true ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}