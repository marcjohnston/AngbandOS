// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronAbhoth : Patron
{
    private PatronAbhoth(Game game) : base(game) { }
    public override string ShortName => "Abhoth";
    public override string LongName => "Abhoth, the Unclean";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        Game.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HurtLotReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HurtLotReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HSummonReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HSummonReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(SerMonsReward)),
        Game.SingletonRepository.Rewards.Get(nameof(SerDemoReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObsReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GreaObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GreaObsReward))
    };
}