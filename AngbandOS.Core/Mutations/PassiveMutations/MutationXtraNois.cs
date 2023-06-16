// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class MutationXtraNois : Mutation
{
    public override void Initialize()
    {
        Frequency = 3;
        GainMessage = "You start making strange noise!";
        HaveMessage = "You make a lot of strange noise (-3 stealth).";
        LoseMessage = "You stop making strange noise!";
    }

    public override void OnGain(Genome genome)
    {
        genome.StealthBonus -= 3;
    }

    public override void OnLose(Genome genome)
    {
        genome.StealthBonus += 3;
    }
}