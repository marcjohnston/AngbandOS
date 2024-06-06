// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class LawArtifactBias : ArtifactBias
{
    private LawArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Law";
    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyArtifactBiasSlaying)
        {
            if (!item.Characteristics.SlayEvil)
            {
                item.Characteristics.SlayEvil = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.Characteristics.SlayUndead)
            {
                item.Characteristics.SlayUndead = true;
                if (Game.DieRoll(2) == 1)
                {
                    return true;
                }
            }
            if (!item.Characteristics.SlayDemon)
            {
                item.Characteristics.SlayDemon = true;
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
        if (Game.DieRoll(8) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BanishEvilEvery250p1d250Activation));
        }
        else if (Game.DieRoll(4) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(DispelEvil5xEvery300p1d300Activation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(ProtectionFromEvilActivation));
        }
    }
}
