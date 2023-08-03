// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronYogSothoth : Patron
{
    private PatronYogSothoth(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Yog Sothoth";
    public override string LongName => "Yog Sothoth, the Gate and the Key";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
        SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HurtLotReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PissOffReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HSummonReward>(),
        SaveGame.SingletonRepository.Rewards.Get<SummonMReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<DestructReward>(),
        SaveGame.SingletonRepository.Rewards.Get<SerUndeReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CarnageReward>(),
        SaveGame.SingletonRepository.Rewards.Get<MassGenReward>(),
        SaveGame.SingletonRepository.Rewards.Get<MassGenReward>(),
        SaveGame.SingletonRepository.Rewards.Get<DispelCReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObjReward>(),
        SaveGame.SingletonRepository.Rewards.Get<ChaosWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObsReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObsReward>(),
        SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>()
    };
}