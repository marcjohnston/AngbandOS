// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronHastur : PatronGameConfiguration
{
    public override string ShortName => "Hastur";
    public override string LongName => "Hastur, the Unspeakable";
    public override string? PreferredAbilityBindingKey => null;
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.SerDemoReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.CurseArReward),
        nameof(RewardsEnum.LoseExpReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.LoseAblReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.DestructReward),
        nameof(RewardsEnum.MassGenReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.HurtLotReward),
        nameof(RewardsEnum.AugmAblReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.GreaObsReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}