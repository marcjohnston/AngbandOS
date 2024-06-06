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

    public override string AffinityName => "Chaos";
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.Characteristics.ResChaos)
        {
            item.Characteristics.ResChaos = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.Characteristics.ResConf)
        {
            item.Characteristics.ResConf = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.Characteristics.ResDisen)
        {
            item.Characteristics.ResDisen = false;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.Characteristics.Teleport)
        {
            item.Characteristics.Teleport = true;
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
            if (!item.Characteristics.Chaotic)
            {
                item.Characteristics.Chaotic = true;
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
            return Game.SingletonRepository.Get<Activation>(nameof(SummonDemonActivation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(CallChaosEvery350Activation));
        }
    }
}
