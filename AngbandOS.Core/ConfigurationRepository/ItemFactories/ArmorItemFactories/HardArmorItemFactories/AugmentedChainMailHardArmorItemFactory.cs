// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AugmentedChainMailHardArmorItemFactory : HardArmorItemFactory
{
    private AugmentedChainMailHardArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Augmented Chain Mail";

    public override int Ac => 16;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 900;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "Augmented Chain Mail~";
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int ToH => -2;
    public override int Weight => 270;
    public override Item CreateItem() => new Item(SaveGame, this);
}