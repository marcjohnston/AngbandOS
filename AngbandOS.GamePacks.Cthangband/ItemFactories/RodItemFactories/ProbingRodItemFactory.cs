// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ProbingRodItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(MinusSignSymbol);
    public override string Name => "Probing";
    public override string? DescriptionSyntax => "$Flavor$ Rod~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Rod~";
    public override string? FlavorSuppressedDescriptionSyntax => "Rod~ of $Name$";
    public override int Cost => 4000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 4)
    };
    public override (string, string, bool, int)? ZapBindingTuple => (nameof(SystemScriptsEnum.ProbingScript), "50", false, 250);
    public override string ItemClassBindingKey => nameof(RodsItemClass);

    public override string? RechargeScriptBindingKey => nameof(SystemScriptsEnum.RechargeRodScript);

    public override string? EatMagicScriptBindingKey => nameof(SystemScriptsEnum.RodEatMagicScript);

    /// <summary>
    /// Returns true, because rods are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;
    public override string? ItemEnhancementBindingKey => nameof(ProbingRodItemFactoryItemEnhancement);
    public override int PackSort => 13;
    public override int BaseValue => 90;
    public override ColorEnum Color => ColorEnum.Turquoise;
}
