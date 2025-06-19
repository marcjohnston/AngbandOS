// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronNyogtha : PatronGameConfiguration
{
    public override string ShortName => "Nyogtha";
    public override string LongName => "Nyogtha, the Thing Which Should Not Be";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.DreadCurseReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.SerMonsReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}