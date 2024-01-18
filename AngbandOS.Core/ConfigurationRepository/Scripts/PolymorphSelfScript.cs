// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PolymorphSelfScript : Script
{
    private PolymorphSelfScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        int effects = SaveGame.Rng.DieRoll(2);
        int tmp = 0;
        bool moreEffects = true;
        SaveGame.MsgPrint("You feel a change coming over you...");
        while (effects-- != 0 && moreEffects)
        {
            switch (SaveGame.Rng.DieRoll(12))
            {
                case 1:
                case 2:
                case 3:
                    SaveGame.RunScript(nameof(PolymorphWoundsScript));
                    break;

                case 4:
                case 5:
                case 6:
                    SaveGame.Dna.GainMutation();
                    break;

                case 7:
                    {
                        int newRaceIndex;
                        Race newRace;
                        do
                        {
                            newRaceIndex = SaveGame.Rng.RandomLessThan(SaveGame.SingletonRepository.Races.Count);
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
                        SaveGame.DecreaseAbilityScore(tmp, SaveGame.Rng.FixedSeed + 6, SaveGame.Rng.DieRoll(3) == 1);
                        tmp++;
                    }
                    if (SaveGame.Rng.DieRoll(6) == 1)
                    {
                        SaveGame.MsgPrint("You find living difficult in your present form!");
                        SaveGame.TakeHit(SaveGame.Rng.DiceRoll(SaveGame.Rng.DieRoll(SaveGame.ExperienceLevel), SaveGame.ExperienceLevel), "a lethal mutation");
                    }
                    SaveGame.ShuffleAbilityScores();
                    break;

                default:
                    SaveGame.ShuffleAbilityScores();
                    break;
            }
        }
        return false;
    }
}
