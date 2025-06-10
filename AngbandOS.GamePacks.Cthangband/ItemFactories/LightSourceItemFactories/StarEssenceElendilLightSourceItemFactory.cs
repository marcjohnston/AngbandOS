// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarEssenceElendilLightSourceItemFactory : ItemFactoryGameConfiguration
{
    public override string SymbolBindingKey => nameof(AsteriskSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Star Essence Elendil";

    public override int Cost => 25000;

    /// <summary>
    /// Returns a radius of 2 for a star of essence.
    /// </summary>
    public override int Radius => 2;

    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string? DescriptionSyntax => "Star Essence~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 30;
    public override int Weight => 5;
    public override bool ProvidesSunlight => true;

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
        (new int[] {2}, null, new string[] { nameof(SystemScriptsEnum.GreatOrbOfLightEnchantmentScript) })
    };

    public override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}
