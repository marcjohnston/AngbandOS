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
    private PatronYig(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Yig";
    public override string LongName => "Yig, Father of Serpents";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
        SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseArReward>(),
        SaveGame.SingletonRepository.Rewards.Get<RuinAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<SerUndeReward>(),
        SaveGame.SingletonRepository.Rewards.Get<DestructReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CarnageReward>(),
        SaveGame.SingletonRepository.Rewards.Get<MassGenReward>(),
        SaveGame.SingletonRepository.Rewards.Get<MassGenReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HealFulReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GainAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GainAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<ChaosWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObsReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObsReward>(),
        SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>()
    };
}