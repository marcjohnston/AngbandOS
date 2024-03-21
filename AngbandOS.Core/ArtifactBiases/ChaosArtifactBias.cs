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
    private ChaosArtifactBias(Game game) : base(game) { }

    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.ResChaos)
        {
            item.RandomArtifactItemCharacteristics.ResChaos = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandomArtifactItemCharacteristics.ResConf)
        {
            item.RandomArtifactItemCharacteristics.ResConf = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandomArtifactItemCharacteristics.ResDisen)
        {
            item.RandomArtifactItemCharacteristics.ResDisen = false;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.Teleport)
        {
            item.RandomArtifactItemCharacteristics.Teleport = true;
            if (Game.DieRoll(2) == 1)
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
            if (!item.RandomArtifactItemCharacteristics.Chaotic)
            {
                item.RandomArtifactItemCharacteristics.Chaotic = true;
                if (Game.DieRoll(2) == 1)
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
        if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(SummonDemonActivation));
        }
        else
        {
            return Game.SingletonRepository.Activations.Get(nameof(CallChaosEvery350Activation));
        }
    }
}
