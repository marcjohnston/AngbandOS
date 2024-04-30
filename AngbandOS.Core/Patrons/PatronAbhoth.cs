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
        Game.SingletonRepository.Get<Reward>(nameof(WrathReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HurtLotReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HurtLotReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HSummonReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HSummonReward)),
        Game.SingletonRepository.Get<Reward>(nameof(IgnoreReward)),
        Game.SingletonRepository.Get<Reward>(nameof(IgnoreReward)),
        Game.SingletonRepository.Get<Reward>(nameof(IgnoreReward)),
        Game.SingletonRepository.Get<Reward>(nameof(SerMonsReward)),
        Game.SingletonRepository.Get<Reward>(nameof(SerDemoReward)),
        Game.SingletonRepository.Get<Reward>(nameof(PolySlfReward)),
        Game.SingletonRepository.Get<Reward>(nameof(PolyWndReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HealFulReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GoodObjReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GoodObjReward)),
        Game.SingletonRepository.Get<Reward>(nameof(ChaosWpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GoodObsReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GoodObsReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GreaObjReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GreaObsReward))
    };
}