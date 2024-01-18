// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Patrons;

[Serializable]
internal class PatronShubNiggurath : Patron
{
    private PatronShubNiggurath(SaveGame saveGame) : base(saveGame) { }
    public override string ShortName => "Shub Niggurath";
    public override string LongName => "Shub Niggurath, Black Goat of the Woods";
    public override int PreferredAbility => Ability.Intelligence;
    protected override Reward[] Rewards => new Reward[]
    {
        SaveGame.SingletonRepository.Rewards.Get(nameof(WrathReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(CurseArReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(RuinAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(LoseAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(LoseExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(IgnoreReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolySlfReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(PolyWndReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(HealFulReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(ChaosWpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GreaObjReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainAblReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(GainExpReward)),
        SaveGame.SingletonRepository.Rewards.Get(nameof(AugmAblReward))
    };
}