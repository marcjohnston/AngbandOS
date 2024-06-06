// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class RangerArtifactBias : ArtifactBias
{
    private RangerArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Rangers";
    public override bool ApplyBonuses(Item item)
    {
        if (!item.Characteristics.Con)
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
        else if (!item.Characteristics.Str)
        {
            item.Characteristics.Str = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }

        return false;
    }
    public override bool ApplyMiscPowers(Item item)
    {
        if (!item.Characteristics.SustCon)
        {
            item.Characteristics.SustCon = true;
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
            if (!item.Characteristics.SlayAnimal)
            {
                item.Characteristics.SlayAnimal = true;
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
        if (Game.DieRoll(20) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(CharmAnimalEvery500Activation));
        }
        else if (Game.DieRoll(7) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SummonAnimalActivation));
        }
        else if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(CharmAnimal1xEvery300Activation));
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
