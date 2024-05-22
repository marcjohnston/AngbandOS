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
    private LeadCrownArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Lead Crown";

    public override int Cost => 1000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "& Lead Crown~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 44;
    public override int Weight => 20;
    /// <summary>
    /// Returns the head inventory slot, for crowns.
    /// </summary>
    public override int WieldSlot => InventorySlot.Head;

    protected override string ItemClassName => nameof(CrownsItemClass);

    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(HeadInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Crown;
    public override bool HatesAcid => true;

    public override int PackSort => 24;
}
