// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class NewLifeScript : Script, IEatOrQuaffScript
{
    private NewLifeScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        // New life rerolls your health, cures all mutations, and restores you to your birth race
        Game.RunScript(nameof(RerollHitPointsScript));
        if (Game.HasMutations)
        {
            Game.MsgPrint("You are cured of all mutations.");
            Game.LoseAllMutations();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            Game.HandleStuff();
        }
        if (!(Game.Race.GetType() == Game.RaceAtBirth.GetType()))
        {
            var oldRaceName = Game.RaceAtBirth.Title;
            Game.MsgPrint($"You feel more {oldRaceName} again.");
            Game.ChangeRace(Game.RaceAtBirth);
            Game.ConsoleView.RefreshMapLocation(Game.MapY.IntValue, Game.MapX.IntValue);
        }
        return IdentifiedResultEnum.True;
    }
}