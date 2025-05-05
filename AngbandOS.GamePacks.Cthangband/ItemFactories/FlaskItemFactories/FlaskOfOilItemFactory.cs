// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FlaskOfOilItemFactory : ItemFactoryGameConfiguration
{
    /// <summary>
    /// Returns true because a flask of oil is valid as fuel for lanterns.
    /// </summary>
    public override bool IsLanternFuel => true;
    public override string SymbolBindingKey => nameof(ExclamationPointSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Flask of oil";

    public override int Cost => 3;
    public override int DamageDice => 2;
    public override int DamageSides => 6;
    public override string? DescriptionSyntax => "Flask~ of oil";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int InitialTurnsOfLight => 7500;
    public override int Weight => 10;
    public override string ItemClassBindingKey => nameof(FlasksItemClass);
    public override bool EasyKnow => true;
    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (20, "3d5-3")
    };

    public override string BreakageChanceProbabilityExpression => "100/100";
    public override bool HatesCold => true;
    public override int PackSort => 10;
}
