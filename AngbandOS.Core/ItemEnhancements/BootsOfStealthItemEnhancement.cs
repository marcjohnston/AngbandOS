// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class BootsOfStealthItemEnhancement : ItemEnhancement
{
    private BootsOfStealthItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override int? Value => 500;
    public override string? FriendlyName => "of Stealth";
    protected override string? BonusStealthRollExpression => "1d3";
    public override int TreasureRating => 16;
    public override bool Stealth => true;
}
