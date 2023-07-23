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
    public override void Activate(SaveGame saveGame)
    {
        if (saveGame.CheckIfRacialPowerWorks(10, 12, Ability.Constitution, 12))
        {
            int num = saveGame.ExperienceLevel / 10;
            int dur = Program.Rng.DieRoll(20) + 20;
            if (Program.Rng.RandomLessThan(5) < num)
            {
                saveGame.TimedAcidResistance.AddTimer(dur);
                num--;
            }
            if (Program.Rng.RandomLessThan(4) < num)
            {
                saveGame.TimedLightningResistance.AddTimer(dur);
                num--;
            }
            if (Program.Rng.RandomLessThan(3) < num)
            {
                saveGame.TimedFireResistance.AddTimer(dur);
                num--;
            }
            if (Program.Rng.RandomLessThan(2) < num)
            {
                saveGame.TimedColdResistance.AddTimer(dur);
                num--;
            }
            if (num != 0)
            {
                saveGame.TimedPoisonResistance.AddTimer(dur);
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