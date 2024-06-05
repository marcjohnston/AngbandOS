// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponBlessedRareItem : RareItem
{
    private WeaponBlessedRareItem(Game game) : base(game) { } // This object is a singleton.
    public override void ApplyMagic(Item item)
    {
        item.RandomPower = Game.SingletonRepository.ToWeightedRandom<Power>(_power => _power.IsAbility == true).Choose();
    }
    public override bool Blessed => true;
    public override int Cost => 5000;
    public override string FriendlyName => "(Blessed)";
    public override int MaxPval => 3;
    public override int TreasureRating => 20;
        public override bool Wis => true;
}
