﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SmellMonActiveMutation : Mutation
{
    private SmellMonActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (Game.CheckIfRacialPowerWorks(5, 4, Game.IntelligenceAbility, 15))
        {
            Game.RunScript(nameof(DetectNormalMonstersScript));
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 5 ? "smell monsters   (unusable until level 5)" : "smell monsters   (cost 4, INT based)";
    }

    public override int Frequency => 4;
    public override string GainMessage => "You smell filthy monsters.";
    public override string HaveMessage => "You can smell nearby monsters.";
    public override string LoseMessage => "You no longer smell filthy monsters.";
}