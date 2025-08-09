// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class EmptyBottleItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(ExclamationPointSymbol);
    public override string ItemClassBindingKey => nameof(BottlesItemClass);
    public override string? ItemEnhancementBindingKey => nameof(EmptyBottleItemFactoryItemEnhancement);
    public override int PackSort => 39;
    public override bool HatesCold => true;
    public override string BreakageChanceProbabilityExpression => "100/100";
    public override bool HatesAcid => true;
    public override string Name => "Empty Bottle";

    public override int DamageSides => 1;
    public override string? DescriptionSyntax => "Empty Bottle~";
}
