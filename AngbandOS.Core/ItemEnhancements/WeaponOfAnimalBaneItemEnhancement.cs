// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemEnhancements;

[Serializable]
internal class WeaponOfAnimalBaneItemEnhancement : ItemEnhancement
{
    private WeaponOfAnimalBaneItemEnhancement(Game game) : base(game) { } // This object is a singleton.
    public override int? Value => 6000;
    public override string? FriendlyName => "of Animal Bane";
    public override bool Int => true;
    protected override string? BonusIntelligenceRollExpression => "1d2";
    public override int TreasureRating => 20;
    public override bool Regen => true;
    public override bool SlayAnimal => true;
 }