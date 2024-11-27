// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponBlessedRareItem : ItemEnhancement
{
    private WeaponBlessedRareItem(Game game) : base(game) { } // This object is a singleton.
    public override ItemEnhancement? RandomPower => Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(AbilityItemEnhancementWeightedRandom)).Choose();
    public override bool Blessed => true;
    public override int? AdditiveBundleValue => 5000;
    public override string? FriendlyName => "(Blessed)";
    protected override string? BonusWisdomRollExpression => "1d3";
    public override int TreasureRating => 20;
    public override bool Wis => true;
}
