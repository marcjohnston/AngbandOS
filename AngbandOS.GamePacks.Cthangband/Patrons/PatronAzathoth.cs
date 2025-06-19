// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronAzathoth : PatronGameConfiguration
{
    public override string ShortName => "Azathoth";
    public override string LongName => "Azathoth, the Daemon Sultan";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.DreadCurseReward),
        nameof(RewardsEnum.DreadCurseReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.LoseAblReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.CarnageReward),
        nameof(RewardsEnum.DispelCReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.SerMonsReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.AugmAblReward),
        nameof(RewardsEnum.GoodObsReward)
    };
}