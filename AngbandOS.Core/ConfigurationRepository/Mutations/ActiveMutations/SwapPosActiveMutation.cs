﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SwapPosActiveMutation : Mutation
{
    private SwapPosActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(15, 12, Ability.Dexterity, 16))
        {
            return;
        }
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.TeleportSwap(dir);
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 15 ? "swap position    (unusable until level 15)" : "swap position    (cost 12, DEX based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "You feel like walking a mile in someone else's shoes.";
    public override string HaveMessage => "You can switch locations with another being.";
    public override string LoseMessage => "You feel like staying in your own shoes.";
}