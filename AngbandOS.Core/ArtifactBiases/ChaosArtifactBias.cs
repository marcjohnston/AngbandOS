// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class ChaosArtifactBias : ArtifactBias
{
    private ChaosArtifactBias(SaveGame saveGame) : base(saveGame) { }

    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandartItemCharacteristics.ResChaos)
        {
            item.RandartItemCharacteristics.ResChaos = true;
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandartItemCharacteristics.ResConf)
        {
            item.RandartItemCharacteristics.ResConf = true;
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandartItemCharacteristics.ResDisen)
        {
            item.RandartItemCharacteristics.ResDisen = false;
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.RandartItemCharacteristics.Teleport)
        {
            item.RandartItemCharacteristics.Teleport = true;
            if (Program.Rng.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }
    public override bool ApplySlaying(Item item)
    {
        if (item.Category != ItemTypeEnum.Bow)
        {
            if (!item.RandartItemCharacteristics.Chaotic)
            {
                item.RandartItemCharacteristics.Chaotic = true;
                if (Program.Rng.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override int ActivationPowerChance => 50;

    public override Activation GetActivationPowerType(Item item)
    {
        if (Program.Rng.DieRoll(6) == 1)
        {
            return SaveGame.SingletonRepository.Activations.Get<SummonDemonActivation>();
        }
        else
        {
            return SaveGame.SingletonRepository.Activations.Get<CallChaosActivation>();
        }
    }
}
