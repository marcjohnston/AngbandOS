// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrassLanternLightSourceItemFactory : ItemFactoryGameConfiguration
{
    /// <summary>
    /// Returns 1 because a latern consumes a turn of light for every world turn.
    /// </summary>
    public override int BurnRate => 1;

    /// <summary>
    /// Returns 15000 because it is the maximum amount of fuel that can be used for a phlogiston.
    /// </summary>
    public override int? MaxPhlogiston => 15000;

    /// <summary>
    /// Returns true because a lantern contains oil which is valid as fuel for other lanterns.
    /// </summary>
    public override bool IsLanternFuel => true;

    public override string SymbolBindingKey => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Brass Lantern";

    public override int Cost => 35;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool EasyKnow => true;
    public override string? DescriptionSyntax => "Brass Lantern~";
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int InitialTurnsOfLight => 7500;
    public override int Weight => 50;


    /// <summary>
    /// Returns a radius of 2 for a brass lantern.
    /// </summary>
    public override int Radius => 2;

    public override string? RefillScriptBindingKey => nameof(SystemScriptsEnum.RefillLightSourceFromFlaskScript);

    public override string ItemClassBindingKey => nameof(LightSourcesItemClass);
    public override string[] WieldSlotBindingKeys => new string[] { nameof(WieldSlotsEnum.LightsourceWieldSlot) };

    public override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (20, "3d5-3")
    };

    public override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(SystemScriptsEnum.PoorOrbOfLightEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(SystemScriptsEnum.GoodOrbOfLightEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(SystemScriptsEnum.GreatOrbOfLightEnchantmentScript) }),
        (null, true, new string[] { nameof(SystemScriptsEnum.FillLanternEnchantmentScript) }),
        (null, false, new string[] { nameof(SystemScriptsEnum.UsedLanternEnchantmentScript) })
    };

    public override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}
