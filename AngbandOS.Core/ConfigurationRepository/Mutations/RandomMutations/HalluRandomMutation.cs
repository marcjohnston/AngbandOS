﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class HalluRandomMutation : Mutation
{
    private HalluRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You are afflicted by a hallucinatory insanity!";
    public override string HaveMessage => "You have a hallucinatory insanity.";
    public override string LoseMessage => "You are no longer afflicted by a hallucinatory insanity!";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (SaveGame.Rng.DieRoll(6400) != 42)
        {
            return;
        }
        if (saveGame.HasChaosResistance)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.SingletonRepository.FlaggedActions.Get<PrExtraRedrawActionGroupSetFlaggedAction>().Set();
        saveGame.TimedHallucinations.AddTimer(SaveGame.Rng.RandomLessThan(50) + 20);
    }
}