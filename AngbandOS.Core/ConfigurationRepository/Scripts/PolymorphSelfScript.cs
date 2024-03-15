// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PolymorphSelfScript : Script, IScript, IRepeatableScript
{
    private PolymorphSelfScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the polymorph-self script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the polymorh-self script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int effects = SaveGame.DieRoll(2);
        int tmp = 0;
        bool moreEffects = true;
        SaveGame.MsgPrint("You feel a change coming over you...");
        while (effects-- != 0 && moreEffects)
        {
            switch (SaveGame.DieRoll(12))
            {
                case 1:
                case 2:
                case 3:
                    SaveGame.RunScript(nameof(PolymorphWoundsScript));
                    break;

                case 4:
                case 5:
                case 6:
                    SaveGame.RunScript(nameof(GainMutationScript));
                    break;

                case 7:
                    {
                        int newRaceIndex;
                        Race newRace;
                        do
                        {
                            newRaceIndex = SaveGame.RandomLessThan(SaveGame.SingletonRepository.Races.Count);
                            newRace = SaveGame.SingletonRepository.Races[newRaceIndex];
                        } while (newRace is Race);
                        SaveGame.MsgPrint($"You turn into {newRace.IndefiniteArticleForTitle} {newRace.Title}!");
                        SaveGame.ChangeRace(newRace);
                    }
                    SaveGame.RedrawSingleLocation(SaveGame.MapY, SaveGame.MapX);
                    moreEffects = false;
                    break;

                case 8:
                    SaveGame.MsgPrint("You polymorph into an abomination!");
                    while (tmp < 6)
                    {
                        SaveGame.DecreaseAbilityScore(tmp, SaveGame.FixedSeed + 6, SaveGame.DieRoll(3) == 1);
                        tmp++;
                    }
                    if (SaveGame.DieRoll(6) == 1)
                    {
                        SaveGame.MsgPrint("You find living difficult in your present form!");
                        SaveGame.TakeHit(SaveGame.DiceRoll(SaveGame.DieRoll(SaveGame.ExperienceLevel.Value), SaveGame.ExperienceLevel.Value), "a lethal mutation");
                    }
                    SaveGame.ShuffleAbilityScores();
                    break;

                default:
                    SaveGame.ShuffleAbilityScores();
                    break;
            }
        }
    }
}
