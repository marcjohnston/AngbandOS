// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BeakedAxePolearmWeaponItemFactory : PolearmWeaponItemFactory
{
    private BeakedAxePolearmWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ForwardSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Beaked Axe";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 408;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "& Beaked Axe~";
    public override int LevelNormallyFound => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 180;
    public override Item CreateItem() => new Item(Game, this);
}
