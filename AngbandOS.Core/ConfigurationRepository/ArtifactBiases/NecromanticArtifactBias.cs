﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class NecromanticArtifactBias : ArtifactBias
{
    private NecromanticArtifactBias(SaveGame saveGame) : base(saveGame) { }
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandartItemCharacteristics.ResNether)
        {
            item.RandartItemCharacteristics.ResNether = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandartItemCharacteristics.ResPois)
        {
            item.RandartItemCharacteristics.ResPois = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandartItemCharacteristics.ResDark)
        {
            item.RandartItemCharacteristics.ResDark = true;
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyArtifactBiasSlaying)
        {
            if (!item.RandartItemCharacteristics.Vampiric)
            {
                item.RandartItemCharacteristics.Vampiric = true;
                if (SaveGame.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandartItemCharacteristics.BrandPois && SaveGame.Rng.DieRoll(2) == 1)
            {
                item.RandartItemCharacteristics.BrandPois = true;
                if (SaveGame.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (SaveGame.Rng.DieRoll(66) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<WraithActivation>();
        }
        else if (SaveGame.Rng.DieRoll(13) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<DispGoodActivation>();
        }
        else if (SaveGame.Rng.DieRoll(9) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<MassGenoActivation>();
        }
        else if (SaveGame.Rng.DieRoll(8) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<CarnageActivation>();
        }
        else if (SaveGame.Rng.DieRoll(13) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<SummonUndeadActivation>();
        }
        else if (SaveGame.Rng.DieRoll(9) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<Vampire2Activation>();
        }
        else if (SaveGame.Rng.DieRoll(6) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<CharmUndeadActivation>();
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get<Vampire1Activation>();
        }
    }
}