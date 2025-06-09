// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PolymorphSelfScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private PolymorphSelfScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the polymorph-self script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the polymorh-self script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int effects = Game.DieRoll(2);
        bool moreEffects = true;
        Game.MsgPrint("You feel a change coming over you...");
        while (effects-- != 0 && moreEffects)
        {
            switch (Game.DieRoll(12))
            {
                case 1:
                case 2:
                case 3:
                    Game.RunScript(nameof(PolymorphWoundsScript));
                    break;

                case 4:
                case 5:
                case 6:
                    Game.RunScript(nameof(GainMutationScript));
                    break;

                case 7:
                    {
                        int newRaceIndex;
                        Race newRace;
                        do
                        {
                            newRaceIndex = Game.RandomLessThan(Game.SingletonRepository.Count<Race>());
                            newRace = Game.SingletonRepository.Get<Race>(newRaceIndex);
                        } while (newRace is Race);
                        Game.MsgPrint($"You turn into {newRace.IndefiniteArticleForTitle} {newRace.Title}!");
                        Game.ChangeRace(newRace);
                    }
                    Game.ConsoleView.RefreshMapLocation(Game.MapY.IntValue, Game.MapX.IntValue);
                    moreEffects = false;
                    break;

                case 8:
                    Game.MsgPrint("You polymorph into an abomination!");
                    foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
                    {
                        Game.DecreaseAbilityScore(ability, Game.FixedSeed + 6, Game.DieRoll(3) == 1);
                    }
                    if (Game.DieRoll(6) == 1)
                    {
                        Game.MsgPrint("You find living difficult in your present form!");
                        Game.TakeHit(Game.DiceRoll(Game.DieRoll(Game.ExperienceLevel.IntValue), Game.ExperienceLevel.IntValue), "a lethal mutation");
                    }
                    Game.ShuffleAbilityScores();
                    break;

                default:
                    Game.ShuffleAbilityScores();
                    break;
            }
        }
    }
    public string LearnedDetails => "";
}
