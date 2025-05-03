// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class PriestlyArtifactBias : ArtifactBias
{
    private PriestlyArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Priests";

    public override bool ApplyRandomArtifactBonuses(RwItemPropertySet characteristics)
    {
        if (!characteristics.Wis)
        {
            characteristics.Wis = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplySlaying(RwItemPropertySet characteristics)
    {
        if (characteristics.CanApplyBlessedArtifactBias && !characteristics.Blessed)
        {
            characteristics.Blessed = true;
        }
        return false;
    }

    public override Activation GetActivationPowerType()
    {
        if (Game.DieRoll(13) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(EnslaveUndead1xEvery333DirectionalActivation));
        }
        else if (Game.DieRoll(12) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(BanishEvilEvery250p1d250Activation));
        }
        else if (Game.DieRoll(11) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(DispelEvil5xEvery300p1d300Activation));
        }
        else if (Game.DieRoll(10) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(ProtectionFromEvilActivation));
        }
        else if (Game.DieRoll(9) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(Heal1000Every888Activation));
        }
        else if (Game.DieRoll(8) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(Heal700Every25Activation));
        }
        else if (Game.DieRoll(7) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(RestAllActivation));
        }
        else if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(RestLifeActivation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(Heal4d8AndWoundsEvery3p1d3Activation));
        }
    }
}
