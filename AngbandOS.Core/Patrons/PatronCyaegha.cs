// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronCyaegha : Patron
{
    private PatronCyaegha(Game game) : base(game) { }
    public override string ShortName => "Cyaegha";
    public override string LongName => "Cyaegha, the Destroying Eye";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        Game.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        Game.SingletonRepository.Rewards.Get(nameof(HurtLotReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PissOffReward)),
        Game.SingletonRepository.Rewards.Get(nameof(LoseAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(LoseExpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        Game.SingletonRepository.Rewards.Get(nameof(DispelCReward)),
        Game.SingletonRepository.Rewards.Get(nameof(DoHavocReward)),
        Game.SingletonRepository.Rewards.Get(nameof(DoHavocReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        Game.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        Game.SingletonRepository.Rewards.Get(nameof(SerMonsReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GreaObjReward)),
        Game.SingletonRepository.Rewards.Get(nameof(GoodObsReward))
    };
}