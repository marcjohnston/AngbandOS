﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DirectionalActivations;

[Serializable]
internal class BizarreThingsEvery1d450p450DirectionalActivation : DirectionalActivation
{
    private BizarreThingsEvery1d450p450DirectionalActivation(Game game) : base(game) { }

    public override string? PreActivationMessage => "Your {0} glows intensely black...";
    protected override string RechargeTimeRollExpression => "1d450+450";

    protected override bool Activate(int direction)
    {
        switch (Game.DieRoll(10))
        {
            case 1:
            case 2:
                {
                    // Decrease all the players ability scores, bypassing sustain and divine protection
                    Game.MsgPrint("You are surrounded by a malignant aura.");
                    Game.DecreaseAbilityScore(AbilityEnum.Strength, 50, true);
                    Game.DecreaseAbilityScore(AbilityEnum.Intelligence, 50, true);
                    Game.DecreaseAbilityScore(AbilityEnum.Wisdom, 50, true);
                    Game.DecreaseAbilityScore(AbilityEnum.Dexterity, 50, true);
                    Game.DecreaseAbilityScore(AbilityEnum.Constitution, 50, true);
                    Game.DecreaseAbilityScore(AbilityEnum.Charisma, 50, true);
                    // Reduce both experience and maximum experience
                    Game.ExperiencePoints.IntValue -= Game.ExperiencePoints.IntValue / 4;
                    Game.MaxExperienceGained.IntValue -= Game.ExperiencePoints.IntValue / 4;
                    Game.CheckExperience();
                    break;
                }
            case 3:
                {
                    // Dispel monsters
                    Game.MsgPrint("You are surrounded by a powerful aura.");
                    Game.DispelMonsters(1000);
                    break;
                }
            case 4:
            case 5:
            case 6:
                {
                    // Do a 300 damage mana ball
                    Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile)), direction, 300, 3);
                    break;
                }
            case 7:
            case 8:
            case 9:
            case 10:
                {
                    // Do a 250 damage mana bolt
                    Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile)), direction, 250);
                    break;
                }
        }
        return true;
    }

    public override int Value => 5000;

    public override string Name => "Bizarre things";

}

