// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfPoisoningRareItem : RareItem
{
    private WeaponOfPoisoningRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool BrandPois => true;
    public override int? AdditiveBundleValue => 4500;
    public override string? FriendlyName => "of Poisoning";
    public override int TreasureRating => 20;
    public override bool ResPois => true;
    }
