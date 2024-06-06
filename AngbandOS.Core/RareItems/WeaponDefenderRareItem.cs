// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponDefenderRareItem : RareItem
{
    private WeaponDefenderRareItem(Game game) : base(game) { } // This object is a singleton.
    public override void ApplyMagic(Item item)
    {
        item.RandomPower = Game.SingletonRepository.Get<ItemAdditiveBundleWeightedRandom>(nameof(SustainItemAdditiveBundleWeightedRandom)).Choose();
    }
    public override int Cost => 15000;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "(Defender)";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int MaxPval => 4;
    public override int MaxToA => 8;
    public override int MaxToD => 4;
    public override int MaxToH => 4;
    public override int TreasureRating => 25;
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
        public override bool Stealth => true;
}
