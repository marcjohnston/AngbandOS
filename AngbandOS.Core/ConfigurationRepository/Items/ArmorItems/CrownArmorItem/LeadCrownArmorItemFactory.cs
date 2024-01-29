// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LeadCrownArmorItemFactory : CrownArmorItemFactory
{
    private LeadCrownArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Lead Crown";

    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Lead Crown~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int Level => 44;
    public override int Weight => 20;
    public override Item CreateItem() => new Item(SaveGame, this);
}
