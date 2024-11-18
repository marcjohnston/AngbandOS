// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OrbLightSourceItemFactory : ItemFactory
{
    private OrbLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because orbs of light should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    protected override string SymbolBindingKey => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    public override string Name => "Orb";

    /// <summary>
    /// Returns a radius of 2 for an orb of light.
    /// </summary>
    public override int Radius => 4;

    public override bool IdentityCanBeSensed => true;
    public override int Cost => 1000;
    public override int DamageDice => 1;

    public override int DamageSides => 1;
    protected override string? DescriptionSyntax => "Orb~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 50;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Orbs of light. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;

    protected override string ItemClassBindingKey => nameof(LightSourcesItemClass);
    protected override string[] BaseWieldSlotBindingKeys => new string[] { nameof(LightsourceInventorySlot) };

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (20, "3d5-3")
    };

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(PoorOrbOfLightEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodOrbOfLightEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatOrbOfLightEnchantmentScript) })
    };

    protected override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}
