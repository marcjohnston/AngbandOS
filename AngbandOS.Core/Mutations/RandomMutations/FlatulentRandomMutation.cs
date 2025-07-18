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
    private FlatulentRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You become subject to uncontrollable flatulence.";
    public override string HaveMessage => "You are subject to uncontrollable flatulence.";
    public override string LoseMessage => "You are no longer subject to uncontrollable flatulence.";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(3000) == 13)
        {
            Game.Disturb(false);
            Game.MsgPrint("BRRAAAP! Oops.");
            Game.MsgPrint(null);
            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile)), 0, Game.ExperienceLevel.IntValue, 3);
        }
    }
}