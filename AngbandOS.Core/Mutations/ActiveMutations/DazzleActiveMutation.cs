﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class DazzleActiveMutation : Mutation
{
    private DazzleActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(7, 15, Game.CharismaAbility, 8))
        {
            return;
        }
        Game.RunScript(nameof(StunAtLos1xProjectileScript));
        Game.RunScript(nameof(OldConfuseAtLos4xProjectileScript));
        Game.RunScript(nameof(TurnAllAtLos4xProjectileScript));
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 7 ? "dazzle           (unusable until level 7)" : "dazzle           (cost 15, CHA based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You gain the ability to emit dazzling lights.";
    public override string HaveMessage => "You can emit confusing, blinding radiation.";
    public override string LoseMessage => "You lose the ability to emit dazzling lights.";
}