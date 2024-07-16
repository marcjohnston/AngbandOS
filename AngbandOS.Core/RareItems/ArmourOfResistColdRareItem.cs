// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class ArmorOfResistColdRareItem : ItemAdditiveBundle
{
    private ArmorOfResistColdRareItem(Game game) : base(game) { } // This object is a singleton.
    public override int? AdditiveBundleValue => 600;
    public override string? FriendlyName => "of Resist Cold";
    public override bool IgnoreCold => true;
    public override int TreasureRating => 12;
    public override bool ResCold => true;
    }
