﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class RecallActiveMutation : Mutation
{
    private RecallActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(17, 50, Game.IntelligenceAbility, 16))
        {
            return;
        }
        Game.RunScript(nameof(ToggleRecallScript));
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 17 ? "recall           (unusable until level 17)" : "recall           (cost 50, INT based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You feel briefly homesick, but it passes.";
    public override string HaveMessage => "You can travel between town and the depths.";
    public override string LoseMessage => "You feel briefly homesick.";
}