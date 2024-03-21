// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class FireArtifactBias : ArtifactBias
{
    private FireArtifactBias(Game game) : base(game) { }
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.ResFire)
        {
            item.RandomArtifactItemCharacteristics.ResFire = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (item.Factory.CanApplyArtifactBiasResistance && !item.RandomArtifactItemCharacteristics.ShFire)
        {
            item.RandomArtifactItemCharacteristics.ShFire = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (Game.DieRoll(ImmunityLuckOneInChance) == 1 && !item.RandomArtifactItemCharacteristics.ImFire)
        {
            item.RandomArtifactItemCharacteristics.ImFire = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.Lightsource)
        {
            item.RandomArtifactItemCharacteristics.Lightsource = true;
        }
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyArtifactBiasSlaying)
        {
            if (!item.RandomArtifactItemCharacteristics.BrandFire)
            {
                item.RandomArtifactItemCharacteristics.BrandFire = true;
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
        if (Game.DieRoll(3) != 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(FireBolt9d8Every8p1d8Activation));
        }
        else if (Game.DieRoll(5) != 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(BallOfFire72r2Every400Activation));
        }
        else
        {
            return Game.SingletonRepository.Activations.Get(nameof(FireBall120r3Every225p1d225Activation));
        }
    }
}
