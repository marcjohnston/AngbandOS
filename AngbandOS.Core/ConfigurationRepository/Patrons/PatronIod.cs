// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronIod : Patron
{
    private PatronIod(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Iod";
    public override string LongName => "Iod, the Shining Hunter";
    public override int PreferredAbility => Ability.Charisma;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseArReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseArReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PolySlfReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PolySlfReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PolyWndReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HealFulReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HealFulReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GainExpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObjReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GoodObjReward>(),
        SaveGame.SingletonRepository.Rewards.Get<ChaosWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GreaObjReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GreaObsReward>()
    };
}