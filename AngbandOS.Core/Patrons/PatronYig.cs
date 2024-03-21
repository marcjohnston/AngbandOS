// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronYig : Patron
{
    private PatronYig(Game game) : base(game) { }
    public override string ShortName => "Yig";
    public override string LongName => "Yig, Father of Serpents";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        Game.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        Game.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        Game.SingletonRepository.Rewards.Get(nameof(RuinAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(SerUndeReward)),
        Game.SingletonRepository.Rewards.Get(nameof(DestructReward)),
        Game.SingletonRepository.Rewards.Get(nameof(CarnageReward)),
        Game.SingletonRepository.Rewards.Get(nameof(MassGenReward)),
        Game.SingletonRepository.Rewards.Get(nameof(MassGenReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        Game.SingletonRepository.Rewards.Get(nameof(AugmAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(AugmAblReward))
    };
}