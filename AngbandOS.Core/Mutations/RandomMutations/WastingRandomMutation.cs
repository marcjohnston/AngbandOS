// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class WastingRandomMutation : Mutation
{
    private WastingRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You suddenly contract a horrible wasting disease.";
    public override string HaveMessage => "You have a horrible wasting disease.";
    public override string LoseMessage => "You are cured of the horrible wasting disease!";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (SaveGame.Rng.DieRoll(3000) != 13)
        {
            return;
        }
        int whichStat = SaveGame.Rng.RandomLessThan(6);
        bool sustained = false;
        switch (whichStat)
        {
            case Ability.Strength:
                if (saveGame.HasSustainStrength)
                {
                    sustained = true;
                }
                break;

            case Ability.Intelligence:
                if (saveGame.HasSustainIntelligence)
                {
                    sustained = true;
                }
                break;

            case Ability.Wisdom:
                if (saveGame.HasSustainWisdom)
                {
                    sustained = true;
                }
                break;

            case Ability.Dexterity:
                if (saveGame.HasSustainDexterity)
                {
                    sustained = true;
                }
                break;

            case Ability.Constitution:
                if (saveGame.HasSustainConstitution)
                {
                    sustained = true;
                }
                break;

            case Ability.Charisma:
                if (saveGame.HasSustainCharisma)
                {
                    sustained = true;
                }
                break;

            default:
                saveGame.MsgPrint("Invalid stat chosen!");
                sustained = true;
                break;
        }
        if (sustained)
        {
            return;
        }
        saveGame.Disturb(false);
        if (SaveGame.Rng.DieRoll(10) <= saveGame.Religion.GetNamedDeity(Pantheon.GodName.Lobon).AdjustedFavour)
        {
            saveGame.MsgPrint("Lobon's favour protects you from wasting away!");
            saveGame.MsgPrint(null);
            return;
        }
        saveGame.MsgPrint("You can feel yourself wasting away!");
        saveGame.MsgPrint(null);
        saveGame.DecreaseAbilityScore(whichStat, SaveGame.Rng.DieRoll(6) + 6, SaveGame.Rng.DieRoll(3) == 1);
    }
}