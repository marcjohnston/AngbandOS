// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class MutationBerserk : Mutation
{
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(8, 8, Ability.Strength, 14))
        {
            return;
        }
        saveGame.Player.TimedSuperheroism.AddTimer(Program.Rng.DieRoll(25) + 25);
        saveGame.Player.RestoreHealth(30);
        saveGame.Player.TimedFear.ResetTimer();
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 8 ? "berserk          (unusable until level 8)" : "berserk          (cost 8, STR based)";
    }

    public override void Initialize()
    {
        Frequency = 3;
        GainMessage = "You feel a controlled rage.";
        HaveMessage = "You can drive yourself into a berserk frenzy.";
        LoseMessage = "You no longer feel a controlled rage.";
    }
}