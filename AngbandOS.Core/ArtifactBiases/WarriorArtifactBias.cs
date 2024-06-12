// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class WarriorArtifactBias : ArtifactBias 
{
    private WarriorArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Warriors";
    public override bool ApplyBonuses(Item item)
    {
        if (!item.Characteristics.Str)
        {
            item.Characteristics.Str = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (!item.Characteristics.Con)
        {
            item.Characteristics.Con = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        else if (!item.Characteristics.Dex)
        {
            item.Characteristics.Dex = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    protected override (string ItemCharacteristicTestName, string ItemAdditiveBundleProbabilityExpression, string ItemAdditiveBundleName, string MoreProbabilityExpression)[]? RandomResistanceTuples => new (string, string, string, string)[]
    {
        (nameof(FalseResistFearItemTest), "2/3", nameof(ResistFearItemAdditiveBundle), "1/2"),
        (nameof(FalseNoMagicItemTest), "1/3", nameof(NoMagicItemAdditiveBundle), "1/2"),
        (nameof(FalseResistDarknessItemTest), "1", nameof(ResistDarknessItemAdditiveBundle), "1/2")
    };

    public override int ActivationPowerChance => 80;
    public override Activation GetActivationPowerType(Item item)
    {
        if (Game.DieRoll(100) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(InvulnActivation));

        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(Berserk50p1d50Every100p1d100Activation));
        }
    }
}
