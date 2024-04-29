// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfBurningRareItem : RareItem
{
    private WeaponOfBurningRareItem(Game game) : base(game) { } // This object is a singleton.
    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(VerticalBarSymbol));
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Weapon of Burning";
    public override bool BrandFire => true;
    public override int Cost => 3000;
    public override string FriendlyName => "of Burning";
    public override bool IgnoreFire => true;
    public override int Level => 0;
    public override bool Lightsource => true;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override bool ResFire => true;
    public override int Slot => 24;
}
