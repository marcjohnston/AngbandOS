﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class FlatulentRandomMutation : Mutation
{
    private FlatulentRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You become subject to uncontrollable flatulence.";
    public override string HaveMessage => "You are subject to uncontrollable flatulence.";
    public override string LoseMessage => "You are no longer subject to uncontrollable flatulence.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (SaveGame.Rng.DieRoll(3000) == 13)
        {
            saveGame.Disturb(false);
            saveGame.MsgPrint("BRRAAAP! Oops.");
            saveGame.MsgPrint(null);
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), 0, saveGame.ExperienceLevel, 3);
        }
    }
}