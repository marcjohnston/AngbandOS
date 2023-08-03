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
    private PatronCyaegha(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Cyaegha";
    public override string LongName => "Cyaegha, the Destroying Eye";
    public override int PreferredAbility => Ability.Strength;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HurtLotReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PissOffReward>(),
        SaveGame.SingletonRepository.Rewards.Get<LoseAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<LoseExpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<DispelCReward>(),
        SaveGame.SingletonRepository.Rewards.Get<DoHavocReward>(),
        SaveGame.SingletonRepository.Rewards.Get<DoHavocReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PolySlfReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PolySlfReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GainExpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GainAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GainAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<SerMonsReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObjReward>(),
        SaveGame.SingletonRepository.Rewards.Get<ChaosWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GreaObjReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObsReward>()
    };
}