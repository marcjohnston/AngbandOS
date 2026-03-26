// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RuinationScript : Script, IEatOrQuaffScript
{
    private RuinationScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        // Ruination does 10d10 damage and reduces all your ability scores, bypassing
        // sustains and divine protection
        Game.MsgPrint("Your nerves and muscles feel weak and lifeless!");
        Game.TakeHit(Game.DiceRoll(10, 10), "a potion of Ruination");
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            Game.DecreaseAbilityScore(ability, 25, true);
        }
        return IdentifiedResultEnum.True;
    }
}