// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class BerserkActiveMutation : Mutation
{
    private BerserkActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate()
    {
        if (!SaveGame.CheckIfRacialPowerWorks(8, 8, Ability.Strength, 14))
        {
            return;
        }
        SaveGame.TimedSuperheroism.AddTimer(base.SaveGame.Rng.DieRoll(25) + 25);
        SaveGame.RestoreHealth(30);
        SaveGame.TimedFear.ResetTimer();
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 8 ? "berserk          (unusable until level 8)" : "berserk          (cost 8, STR based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You feel a controlled rage.";
    public override string HaveMessage => "You can drive yourself into a berserk frenzy.";
    public override string LoseMessage => "You no longer feel a controlled rage.";
}