// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class ResistActiveMutation : Mutation
{
    private ResistActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (SaveGame.CheckIfRacialPowerWorks(10, 12, Ability.Constitution, 12))
        {
            int num = SaveGame.ExperienceLevel / 10;
            int dur = base.SaveGame.DieRoll(20) + 20;
            if (base.SaveGame.RandomLessThan(5) < num)
            {
                SaveGame.TimedAcidResistance.AddTimer(dur);
                num--;
            }
            if (base.SaveGame.RandomLessThan(4) < num)
            {
                SaveGame.TimedLightningResistance.AddTimer(dur);
                num--;
            }
            if (base.SaveGame.RandomLessThan(3) < num)
            {
                SaveGame.TimedFireResistance.AddTimer(dur);
                num--;
            }
            if (base.SaveGame.RandomLessThan(2) < num)
            {
                SaveGame.TimedColdResistance.AddTimer(dur);
                num--;
            }
            if (num != 0)
            {
                SaveGame.TimedPoisonResistance.AddTimer(dur);
            }
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 10 ? "resist elements  (unusable until level 10)" : "resist elements  (cost 12, CON based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You feel like you can protect yourself.";
    public override string HaveMessage => "You can harden yourself to the ravages of the elements.";
    public override string LoseMessage => "You feel like you might be vulnerable.";
}