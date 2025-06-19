// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronNyarlathotep : PatronGameConfiguration
{
    public override string ShortName => "Nyarlathotep";
    public override string LongName => "Nyarlathotep, the Crawling Chaos";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.DreadCurseReward),
        nameof(RewardsEnum.HurtLotReward),
        nameof(RewardsEnum.CurseWpReward),
        nameof(RewardsEnum.CurseArReward),
        nameof(RewardsEnum.RuinAblReward),
        nameof(RewardsEnum.SummonMReward),
        nameof(RewardsEnum.LoseExpReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolyWndReward),
        nameof(RewardsEnum.SerUndeReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.HealFulReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.GreaObsReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}