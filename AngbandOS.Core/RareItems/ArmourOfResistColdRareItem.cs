// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class ArmorOfResistColdRareItem : RareItem
{
    private ArmorOfResistColdRareItem(Game game) : base(game) { } // This object is a singleton.
    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Armor of Resist Cold";
    public override int Cost => 600;
    public override string FriendlyName => "of Resist Cold";
    public override bool IgnoreCold => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override int Rarity => 0;
    public override int Rating => 12;
    public override bool ResCold => true;
    public override int Slot => 30;
}