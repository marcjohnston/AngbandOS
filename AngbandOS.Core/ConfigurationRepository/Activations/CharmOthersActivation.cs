﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm multiple monsters.
/// </summary>
[Serializable]
internal class CharmOthersActivation : Activation
{
    private CharmOthersActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 25;

    public override string? PreActivationMessage => "";

    public override bool Activate()
    {
        SaveGame.CharmMonsters(SaveGame.ExperienceLevel * 2);
        return true;
    }

    public override int RechargeTime() => 750;

    public override int Value => 17500;

    public override string Description => "mass charm every 750 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen = true;
}