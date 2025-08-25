// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection.PortableExecutable;
namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class RangerArtifactBias : ArtifactBias
{
    private RangerArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Rangers";

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomSlayingTuples => new (string, string, string, string)[]
    {
        (nameof(CanSlayAndFalseSlayAnimalItemFilter), "1", nameof(SlayAnimalItemEnhancement), "1/2")
    };

    public override bool ApplyRandomArtifactBonuses(EffectiveAttributeSet characteristics)
    {
        if (characteristics.BonusConstitution == 0)
        {
            characteristics.BonusConstitution = Game.EnchantBonus(characteristics.BonusConstitution);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (characteristics.BonusDexterity == 0)
        {
            characteristics.BonusDexterity = Game.EnchantBonus(characteristics.BonusDexterity);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (characteristics.BonusStrength == 0)
        {
            characteristics.BonusStrength = Game.EnchantBonus(characteristics.BonusStrength);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }

        return false;
    }

    public override bool ApplyMiscPowers(EffectiveAttributeSet characteristics)
    {
        if (!characteristics.SustCon)
        {
            characteristics.SetBoolValue(AttributeEnum.SustCon, true);
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override Activation GetActivationPowerType()
    {
        if (Game.DieRoll(20) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(CharmAnimalEvery500Activation));
        }
        else if (Game.DieRoll(7) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SummonFriendlyAnimalActivation));
        }
        else if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(CharmAnimal1xEvery300DirectionalActivation));
        }
        else if (Game.DieRoll(4) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(ResistAll40p1d40Activation));
        }
        else if (Game.DieRoll(3) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SatiateActivation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(RemoveFearAndPoisonEvery5Activation));
        }
    }
}
