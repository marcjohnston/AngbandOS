// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PatronCyaegha : PatronGameConfiguration
{
    public override string ShortName => "Cyaegha";
    public override string LongName => "Cyaegha, the Destroying Eye";
    public override string? PreferredAbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string[] RewardBindingKeys => new string[]
    {
        nameof(RewardsEnum.WrathReward),
        nameof(RewardsEnum.HurtLotReward),
        nameof(RewardsEnum.PissOffReward),
        nameof(RewardsEnum.LoseAblReward),
        nameof(RewardsEnum.LoseExpReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.IgnoreReward),
        nameof(RewardsEnum.DispelCReward),
        nameof(RewardsEnum.DoHavocReward),
        nameof(RewardsEnum.DoHavocReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.PolySlfReward),
        nameof(RewardsEnum.GainExpReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.GainAblReward),
        nameof(RewardsEnum.SerMonsReward),
        nameof(RewardsEnum.GoodObjReward),
        nameof(RewardsEnum.ChaosWpReward),
        nameof(RewardsEnum.GreaObjReward),
        nameof(RewardsEnum.GoodObsReward)
    };
}