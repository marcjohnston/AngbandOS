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
    public override bool ApplyBonuses(Item item)
    {
        if (!item.RandomArtifactItemCharacteristics.Wis)
        {
            item.RandomArtifactItemCharacteristics.Wis = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override bool ApplySlaying(Item item)
    {
        if (item.Factory.CanApplyBlessedArtifactBias && !item.RandomArtifactItemCharacteristics.Blessed)
        {
            item.RandomArtifactItemCharacteristics.Blessed = true;
        }
        return false;
    }

    public override Activation GetActivationPowerType(Item item)
    {
        if (Game.DieRoll(13) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(EnslaveUndead1xEvery333Activation));
        }
        else if (Game.DieRoll(12) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(BanishEvilEvery250p1d250Activation));
        }
        else if (Game.DieRoll(11) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(DispelEvil5xEvery300p1d300Activation));
        }
        else if (Game.DieRoll(10) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(ProtectionFromEvilActivation));
        }
        else if (Game.DieRoll(9) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(Heal1000Every888Activation));
        }
        else if (Game.DieRoll(8) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(Heal700Every25Activation));
        }
        else if (Game.DieRoll(7) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(RestAllActivation));
        }
        else if (Game.DieRoll(6) == 1)
        {
            return Game.SingletonRepository.Activations.Get(nameof(RestLifeActivation));
        }
        else
        {
            return Game.SingletonRepository.Activations.Get(nameof(Heal4d8AndWoundsEvery3p1d3Activation));
        }
    }
}
