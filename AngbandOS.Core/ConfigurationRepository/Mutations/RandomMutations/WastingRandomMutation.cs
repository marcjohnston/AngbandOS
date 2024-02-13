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

    public override void OnProcessWorld()
    {
        if (base.SaveGame.DieRoll(3000) != 13)
        {
            return;
        }
        int whichStat = base.SaveGame.RandomLessThan(6);
        bool sustained = false;
        switch (whichStat)
        {
            case Ability.Strength:
                if (SaveGame.HasSustainStrength)
                {
                    sustained = true;
                }
                break;

            case Ability.Intelligence:
                if (SaveGame.HasSustainIntelligence)
                {
                    sustained = true;
                }
                break;

            case Ability.Wisdom:
                if (SaveGame.HasSustainWisdom)
                {
                    sustained = true;
                }
                break;

            case Ability.Dexterity:
                if (SaveGame.HasSustainDexterity)
                {
                    sustained = true;
                }
                break;

            case Ability.Constitution:
                if (SaveGame.HasSustainConstitution)
                {
                    sustained = true;
                }
                break;

            case Ability.Charisma:
                if (SaveGame.HasSustainCharisma)
                {
                    sustained = true;
                }
                break;

            default:
                SaveGame.MsgPrint("Invalid stat chosen!");
                sustained = true;
                break;
        }
        if (sustained)
        {
            return;
        }
        SaveGame.Disturb(false);
        if (base.SaveGame.DieRoll(10) <= SaveGame.Religion.GetNamedDeity(Pantheon.GodName.Lobon).AdjustedFavour)
        {
            SaveGame.MsgPrint("Lobon's favour protects you from wasting away!");
            SaveGame.MsgPrint(null);
            return;
        }
        SaveGame.MsgPrint("You can feel yourself wasting away!");
        SaveGame.MsgPrint(null);
        SaveGame.DecreaseAbilityScore(whichStat, base.SaveGame.DieRoll(6) + 6, base.SaveGame.DieRoll(3) == 1);
    }
}