// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class NecromanticArtifactBias : ArtifactBias
{
    private NecromanticArtifactBias(Game game) : base(game) { }
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.ResNether)
        {
            item.RandomArtifactItemCharacteristics.ResNether = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandomArtifactItemCharacteristics.ResPois)
        {
            item.RandomArtifactItemCharacteristics.ResPois = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (!item.RandomArtifactItemCharacteristics.ResDark)
        {
            item.RandomArtifactItemCharacteristics.ResDark = true;
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
            if (!item.RandomArtifactItemCharacteristics.Vampiric)
            {
                item.RandomArtifactItemCharacteristics.Vampiric = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.RandomArtifactItemCharacteristics.BrandPois && Game.DieRoll(2) == 1)
            {
                item.RandomArtifactItemCharacteristics.BrandPois = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (Game.DieRoll(66) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(WraithActivation));
        }
        else if (Game.DieRoll(13) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(DispelGood5xEvery300p1d300Activation));
        }
        else if (Game.DieRoll(9) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(MassCarnageActivation));
        }
        else if (Game.DieRoll(8) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(GenocideEvery500Activation));
        }
        else if (Game.DieRoll(13) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(SummonUndeadActivation));
        }
        else if (Game.DieRoll(9) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(Vampire2Activation));
        }
        else if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(EnslaveUndead1xEvery333Activation));
        }
        else
        {
            return Game.SingletonRepository.Activations.Get(nameof(Vampire1Activation));
        }
    }
}
