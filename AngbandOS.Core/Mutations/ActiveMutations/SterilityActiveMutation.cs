﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SterilityActiveMutation : Mutation
{
    private SterilityActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(20, 40, Game.CharismaAbility, 18))
        {
            return;
        }
        Game.MsgPrint("You suddenly have a headache!");
        Game.TakeHit(base.Game.DieRoll(30) + 30, "the strain of forcing abstinence");
        Game.NumRepro += Constants.MaxRepro;
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 20 ? "sterilize        (unusable until level 20)" : "sterilize        (cost 40, CHA based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "You can give everything around you a headache.";
    public override string HaveMessage => "You can cause mass impotence.";
    public override string LoseMessage => "You hear a massed sigh of relief.";
}