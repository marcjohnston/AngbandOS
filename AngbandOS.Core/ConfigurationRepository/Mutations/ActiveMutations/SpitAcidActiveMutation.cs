﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class SpitAcidActiveMutation : Mutation
{
    private SpitAcidActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(9, 9, Ability.Dexterity, 15))
        {
            return;
        }
        saveGame.MsgPrint("You spit acid...");
        if (saveGame.GetDirectionWithAim(out int dir))
        {
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), dir, saveGame.ExperienceLevel, 1 + (saveGame.ExperienceLevel / 30));
        }
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 9
            ? "spit acid        (unusable until level 9)"
            : $"spit acid        (cost 9, dam {lvl}, DEX based)";
    }

    public override int Frequency => 4;
    public override string GainMessage => "You gain the ability to spit acid.";
    public override string HaveMessage => "You can spit acid (dam lvl).";
    public override string LoseMessage => "You lose the ability to spit acid.";
}