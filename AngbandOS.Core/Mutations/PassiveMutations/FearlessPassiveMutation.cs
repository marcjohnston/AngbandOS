﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class FearlessPassiveMutation : Mutation
{
    private FearlessPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 3;
    public override string GainMessage => "You become completely fearless.";
    public override string HaveMessage => "You are completely fearless.";
    public override string LoseMessage => "You begin to feel fear again.";
    public override MutationGroupEnum Group => MutationGroupEnum.Bravery;

    public override void OnGain()
    {
        Game.ResFear = true;
    }

    public override void OnLose()
    {
        Game.ResFear = false;
    }
}