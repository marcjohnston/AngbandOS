// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronHastur : Patron
{
    private PatronHastur(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Hastur";
    public override string LongName => "Hastur, the Unspeakable";
    public override int PreferredAbility => -1;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get<WrathReward>(),
        SaveGame.SingletonRepository.Rewards.Get<SerDemoReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<CurseArReward>(),
        SaveGame.SingletonRepository.Rewards.Get<LoseExpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GainAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<LoseAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PolyWndReward>(),
        SaveGame.SingletonRepository.Rewards.Get<PolySlfReward>(),
        SaveGame.SingletonRepository.Rewards.Get<IgnoreReward>(),
        SaveGame.SingletonRepository.Rewards.Get<DestructReward>(),
        SaveGame.SingletonRepository.Rewards.Get<MassGenReward>(),
        SaveGame.SingletonRepository.Rewards.Get<ChaosWpReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GreaObjReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HurtLotReward>(),
        SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<RuinAblReward>(),
        SaveGame.SingletonRepository.Rewards.Get<HSummonReward>(),
        SaveGame.SingletonRepository.Rewards.Get<GreaObsReward>(),
        SaveGame.SingletonRepository.Rewards.Get<AugmAblReward>()
    };
}