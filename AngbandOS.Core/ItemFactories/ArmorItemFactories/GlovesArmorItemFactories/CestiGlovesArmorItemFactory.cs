// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CestiGlovesArmorItemFactory : GlovesArmorItemFactory
{
    private CestiGlovesArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Set of Cesti";

    public override int Ac => 5;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Set~ of Cesti";
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int Weight => 40;
    public override Item CreateItem() => new Item(SaveGame, this);
}
