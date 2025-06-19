// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronIod : PatronGameConfiguration
{
    public override string ShortName => "Iod";
    public override string LongName => "Iod, the Shining Hunter";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.CurseArReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.CurseArReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.AugmAblReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.GreaObsReward)
    };
}