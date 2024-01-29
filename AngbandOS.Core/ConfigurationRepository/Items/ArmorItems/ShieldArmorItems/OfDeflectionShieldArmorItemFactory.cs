// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OfDeflectionShieldArmorItemFactory : ShieldArmorItemFactory
{
    private OfDeflectionShieldArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Shield of Deflection";

    public override int Ac => 10;
    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 10000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Shield~ of Deflection";
    public override bool IgnoreAcid => true;
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int ToA => 10;
    public override int Weight => 100;
    public override Item CreateItem() => new Item(SaveGame, this);
}
