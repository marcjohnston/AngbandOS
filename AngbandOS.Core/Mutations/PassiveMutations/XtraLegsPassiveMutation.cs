﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class XtraLegsPassiveMutation : Mutation
{
    private XtraLegsPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "You grow an extra pair of legs!";
    public override string HaveMessage => "You have an extra pair of legs (+3 speed).";
    public override string LoseMessage => "Your extra legs disappear!";

    public override void OnGain()
    {
        Game.SpeedBonus += 3;
    }

    public override void OnLose()
    {
        Game.SpeedBonus -= 3;
    }
}