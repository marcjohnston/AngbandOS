﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class BersRageRandomMutation : Mutation
{
    private BersRageRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You become subject to fits of berserk rage!";
    public override string HaveMessage => "You are subject to berserker fits.";
    public override string LoseMessage => "You are no longer subject to fits of berserk rage!";

    public override void ProcessWorld()
    {
        if (base.Game.DieRoll(3000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("RAAAAGHH!");
        Game.MsgPrint("You feel a fit of rage coming over you!");
        Game.SuperheroismTimer.AddTimer(10 + base.Game.DieRoll(Game.ExperienceLevel.IntValue));
    }
}