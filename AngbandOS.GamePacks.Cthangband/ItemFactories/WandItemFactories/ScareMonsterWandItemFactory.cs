// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScareMonsterWandItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(MinusSignSymbol);
    public override string Name => "Scare Monster";
    public override string? DescriptionSyntax => "$Flavor$ Wand~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Wand~";
    public override string? FlavorSuppressedDescriptionSyntax => "Wand~ of $Name$";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 4)
    };
    public override string? ItemEnhancementBindingKey => nameof(ScareMonsterWandItemFactoryItemEnhancement);

    public override (string, string, int, int)? AimingBindingTuple => (nameof(TurnAll10ProjectileScript), "1d5+3", 25, 150);
    public override string ItemClassBindingKey => nameof(WandsItemClass);

    public override string? RechargeScriptBindingKey => nameof(SystemScriptsEnum.RechargeWandScript);

    public override string? EatMagicScriptBindingKey => nameof(SystemScriptsEnum.WandEatMagicScript);

    /// <summary>
    /// Returns true, because wands are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public override string BreakageChanceProbabilityExpression => "25/100";
    public override int PackSort => 14;
    public override int BaseValue => 50;
    public override bool HatesElectricity => true;

}
