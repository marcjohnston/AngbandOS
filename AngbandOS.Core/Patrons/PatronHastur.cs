// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronHastur : Patron
{
    private PatronHastur(Game game) : base(game) { }
    public override string ShortName => "Hastur";
    public override string LongName => "Hastur, the Unspeakable";
    public override int PreferredAbility => -1;
    protected override Reward[] Rewards => new Reward[]
    {
        Game.SingletonRepository.Get<Reward>(nameof(WrathReward)),
        Game.SingletonRepository.Get<Reward>(nameof(SerDemoReward)),
        Game.SingletonRepository.Get<Reward>(nameof(CurseWpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(CurseArReward)),
        Game.SingletonRepository.Get<Reward>(nameof(LoseExpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GainAblReward)),
        Game.SingletonRepository.Get<Reward>(nameof(LoseAblReward)),
        Game.SingletonRepository.Get<Reward>(nameof(PolyWndReward)),
        Game.SingletonRepository.Get<Reward>(nameof(PolySlfReward)),
        Game.SingletonRepository.Get<Reward>(nameof(IgnoreReward)),
        Game.SingletonRepository.Get<Reward>(nameof(DestructReward)),
        Game.SingletonRepository.Get<Reward>(nameof(MassGenReward)),
        Game.SingletonRepository.Get<Reward>(nameof(ChaosWpReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GreaObjReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HurtLotReward)),
        Game.SingletonRepository.Get<Reward>(nameof(AugmAblReward)),
        Game.SingletonRepository.Get<Reward>(nameof(RuinAblReward)),
        Game.SingletonRepository.Get<Reward>(nameof(HSummonReward)),
        Game.SingletonRepository.Get<Reward>(nameof(GreaObsReward)),
        Game.SingletonRepository.Get<Reward>(nameof(AugmAblReward))
    };
}