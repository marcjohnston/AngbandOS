﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Dispel good with a strength of x5.
/// </summary>
[Serializable]
internal class DispGoodActivation : Activation
{
    private DispGoodActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "It floods the area with evil...";

    public override bool Activate()
    {
        SaveGame.DispelGood(SaveGame.ExperienceLevel * 5);
        return true;
    }

    public override int RechargeTime() => SaveGame.Rng.RandomLessThan(300) + 300;

    public override int Value => 3500;

    public override string Description => "dispel good (level*5) every 300+d300 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource = true;
}