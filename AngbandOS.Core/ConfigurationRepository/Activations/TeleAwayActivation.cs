﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Teleport away an opponent.
/// </summary>
[Serializable]
internal class TeleAwayActivation : DirectionalActivation
{
    private TeleAwayActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override int RechargeTime() => 200;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBeam(SaveGame.SingletonRepository.Projectiles.Get<TeleportAwayAllProjectile>(), direction, SaveGame.ExperienceLevel);
        return true;
    }

    public override int Value => 2000;

    public override string Description => "teleport away every 200 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
}