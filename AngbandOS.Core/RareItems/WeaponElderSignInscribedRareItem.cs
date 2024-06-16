// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponElderSignInscribedRareItem : RareItem
{
    private WeaponElderSignInscribedRareItem(Game game) : base(game) { } // This object is a singleton.
    public override void ApplyMagic(Item item)
    {
        item.RandomPower = Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(SustainItemAdditiveBundleWeightedRandom)).Choose();
    }
    public override bool Blessed => true;
    public override int Cost => 20000;
    public override string FriendlyName => "(Elder Sign Inscribed)";
    protected override string? BonusWisdomRollExpression => "1d4";
    public override int MaxToA => 4;
    public override int MaxToD => 6;
    public override int MaxToH => 6;
    public override int TreasureRating => 30;
    public override bool ResFear => true;
    public override bool SeeInvis => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Wis => true;
}
