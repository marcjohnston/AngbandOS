// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ArtifactBiases;

[Serializable]
internal class MageArtifactBias : ArtifactBias
{
    private MageArtifactBias(Game game) : base(game) { }
    public override string AffinityName => "Mages";

    public override bool ApplyRandomArtifactBonuses(RandomArtifactCharacteristics characteristics)
    {
        if (!characteristics.Int)
        {
            characteristics.Int = true;
            if (Game.DieRoll(2) == 1)
            {
                return true;
            }
        }
        return false;
    }

    public override int ActivationPowerChance => 66;

    public override Activation GetActivationPowerType()
    {
        if (Game.DieRoll(20) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SummonElementalActivation));
        }
        else if (Game.DieRoll(10) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(SummonPhantomActivation));
        }
        else if (Game.DieRoll(5) == 1)
        {
            return Game.SingletonRepository.Get<Activation>(nameof(RuneExploActivation));
        }
        else
        {
            return Game.SingletonRepository.Get<Activation>(nameof(TemporaryEsp20p1d30Every200Activation));
        }
    }
}
