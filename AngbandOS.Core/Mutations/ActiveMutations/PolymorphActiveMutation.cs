﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class PolymorphActiveMutation : Mutation
{
    private PolymorphActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (Game.CheckIfRacialPowerWorks(18, 20, Ability.Constitution, 18))
        {
            Game.RunScript(nameof(PolymorphSelfScript));
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 18 ? "polymorph        (unusable until level 18)" : "polymorph        (cost 20, CON based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "Your body seems mutable.";
    public override string HaveMessage => "You can polymorph yourself at will.";
    public override string LoseMessage => "Your body seems stable.";
}