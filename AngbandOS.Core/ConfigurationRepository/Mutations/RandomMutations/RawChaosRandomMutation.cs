﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class RawChaosRandomMutation : Mutation
{
    private RawChaosRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You feel the universe is less stable around you.";
    public override string HaveMessage => "You occasionally are surrounded with raw chaos.";
    public override string LoseMessage => "You feel the universe is more stable around you.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (saveGame.HasAntiMagic || SaveGame.Rng.DieRoll(8000) != 1)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.MsgPrint("You feel the world warping around you!");
        saveGame.MsgPrint(null);
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<ChaosProjectile>(), 0, saveGame.ExperienceLevel, 8);
    }
}