// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�


namespace AngbandOS.Core.RareItems;

[Serializable]
internal class ArmorOfPermanenceRareItem : ItemAdditiveBundle
{
    private ArmorOfPermanenceRareItem(Game game) : base(game) { } // This object is a singleton.
    public override ItemAdditiveBundle? RandomPower => Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(ResistanceItemAdditiveBundleWeightedRandom)).Choose();
    public override int? AdditiveBundleValue => 30000;
    public override string? FriendlyName => "of Permanence";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int MaxToA => 10;
    public override int TreasureRating => 30;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
        public override bool SustCha => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
}
