﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class VteleportActiveMutation : Mutation
{
    private VteleportActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(7, 7, Ability.Wisdom, 15))
        {
            return;
        }
        saveGame.MsgPrint("You concentrate...");
        saveGame.TeleportPlayer(10 + (4 * saveGame.ExperienceLevel));
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 7 ? "teleport         (unusable until level 7)" : "teleport         (cost 7, WIS based)";
    }

    public override int Frequency => 3;
    public override string GainMessage => "You gain the power of teleportation at will.";
    public override string HaveMessage => "You can teleport at will.";
    public override string LoseMessage => "You lose the power of teleportation at will.";
}