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
    public override string AffinityName => "Fire";
    public override bool ApplyRandomResistances(Item item)
    {
        if (!item.Characteristics.ResFire)
        {
            item.Characteristics.ResFire = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (item.Factory.CanApplyArtifactBiasResistance && !item.Characteristics.ShFire)
        {
            item.Characteristics.ShFire = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        if (Game.DieRoll(ImmunityLuckOneInChance) == 1 && !item.Characteristics.ImFire)
        {
            item.Characteristics.ImFire = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplyMiscPowers(Item item)
    {
        item.Characteristics.Radius = 3;
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyArtifactBiasSlaying)
        {
            if (!item.Characteristics.BrandFire)
            {
                item.Characteristics.BrandFire = true;
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
            return Game.SingletonRepository.Get<Activation>(nameof(FireBolt9d8Every8p1d8Activation));
        }
        else if (Game.DieRoll(5) != 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BallOfFire72r2Every400Activation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(FireBall120r3Every225p1d225Activation));
        }
    }
}
