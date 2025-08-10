// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FireBallsRodItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(MinusSignSymbol);
    public override string Name => "Fire Balls";
    public override string? DescriptionSyntax => "$Flavor$ Rod~ of $Name$";
    public override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Rod~";
    public override string? FlavorSuppressedDescriptionSyntax => "Rod~ of $Name$";
    public override int LevelNormallyFound => 75;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (75, 1)
    };
    public override (string, string, bool, int)? ZapBindingTuple => (nameof(Fire72r2ProjectileScript), "30", true, 250);
    public override string ItemClassBindingKey => nameof(RodsItemClass);

    public override string? RechargeScriptBindingKey => nameof(SystemScriptsEnum.RechargeRodScript);

    public override string? EatMagicScriptBindingKey => nameof(SystemScriptsEnum.RodEatMagicScript);

    /// <summary>
    /// Returns true, because rods are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;
    public override string? ItemEnhancementBindingKey => nameof(FireBallsRodItemFactoryItemEnhancement);
    public override int PackSort => 13;
    public override int BaseValue => 90;
    public override ColorEnum Color => ColorEnum.Turquoise;
}
