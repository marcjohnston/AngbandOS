﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.PassiveMutations;

[Serializable]
internal class FleshRotPassiveMutation : Mutation
{
    private FleshRotPassiveMutation(Game game) : base(game) { }
    public override int Frequency => 3;
    public override string GainMessage => "Your flesh is afflicted by a rotting disease!";
    public override string HaveMessage => "Your flesh is rotting (-2 CON, -1 CHR).";
    public override string LoseMessage => "Your flesh is no longer afflicted by a rotting disease!";
    public override MutationGroupEnum Group => MutationGroupEnum.Skin;

    public override void OnGain()
    {
        Game.ConstitutionBonus -= 2;
        Game.CharismaBonus -= 1;
        Game.SuppressRegen = true;
    }

    public override void OnLose()
    {
        Game.ConstitutionBonus += 2;
        Game.CharismaBonus += 1;
        Game.SuppressRegen = false;
    }
}