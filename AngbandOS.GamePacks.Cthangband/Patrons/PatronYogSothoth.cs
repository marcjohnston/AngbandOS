// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronYogSothoth : PatronGameConfiguration
{
    public override string ShortName => "Yog Sothoth";
    public override string LongName => "Yog Sothoth, the Gate and the Key";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.HurtLotReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.HSummonReward),
        nameof(RewardsEnum.SummonMReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.DestructReward),
        nameof(RewardsEnum.SerUndeReward),
        nameof(RewardsEnum.CarnageReward),
        nameof(RewardsEnum.MassGenReward),
        nameof(RewardsEnum.MassGenReward),
        nameof(RewardsEnum.DispelCReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.GoodObsReward),
        nameof(RewardsEnum.AugmAblReward),
        nameof(RewardsEnum.AugmAblReward)
    };
}