// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection.PortableExecutable;

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class NecromanticArtifactBias : ArtifactBias
{
    private NecromanticArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Necromancers";

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistNetherItemTest), "1", nameof(ResistNetherItemEnhancement), "1/2"),
        (nameof(FalseResistPoisonItemTest), "1", nameof(ResistPoisonItemEnhancement), "1/2"),
        (nameof(FalseResistDarknessItemTest), "1", nameof(ResistDarknessItemEnhancement), "1/2")
    };

    public override bool ApplySlaying(ItemCharacteristics characteristics)
    {
        if (characteristics.CanApplyArtifactBiasSlaying)
        {
            if (!characteristics.Vampiric)
            {
                characteristics.Vampiric = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!characteristics.BrandPois && Game.DieRoll(2) == 1)
            {
                characteristics.BrandPois = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType()
    {
        if (Game.DieRoll(66) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(WraithActivation));
        }
        else if (Game.DieRoll(13) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(DispelGood5xEvery300p1d300Activation));
        }
        else if (Game.DieRoll(9) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(MassCarnageActivation));
        }
        else if (Game.DieRoll(8) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(GenocideEvery500Activation));
        }
        else if (Game.DieRoll(13) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SummonFriendlyUndead2In3Activation));
        }
        else if (Game.DieRoll(9) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(Vampire100Every400DirectionalActivation));
        }
        else if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(EnslaveUndead1xEvery333DirectionalActivation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(Vampire50Every400DirectionalActivation));
        }
    }
}
