// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfLengRareItem : ItemAdditiveBundle
{
    private WeaponOfLengRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool Aggravate => true;
    public override int? AdditiveBundleValue => 0;
    public override bool IsCursed => true;
    public override string? FriendlyName => "of Leng";
    public override bool HeavyCurse => true;
    public override int MaxToA => 10;
    public override int MaxToD => 20;
    public override int MaxToH => 20;
    public override int TreasureRating => 0;
    public override bool SeeInvis => true;
    }
