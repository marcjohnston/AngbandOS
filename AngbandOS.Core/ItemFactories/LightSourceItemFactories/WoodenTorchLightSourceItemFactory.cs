// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WoodenTorchLightSourceItemFactory : ItemFactory
{
    private WoodenTorchLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because a torch can be used as fuel for another torch.
    /// </summary>
    public override bool IsFuelForTorch => true;

    /// <summary>
    /// Returns 1 because wooden torches consume a single turn of light for every world turn.
    /// </summary>
    public override int BurnRate => 1;

    protected override string SymbolBindingKey => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Wooden Torch";

    /// <summary>
    /// Returns 5000 because it is the maximum amount of fuel that can be used for a phlogiston.
    /// </summary>
    public override int? MaxPhlogiston => 5000;

    public override int Cost => 2;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool EasyKnow => true;
    protected override string? DescriptionSyntax => "Wooden Torch~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int InitialTurnsOfLight => 4000;
    public override int Weight => 30;
    protected override string? RefillScriptBindingKey => nameof(RefillLightSourceFromTorchScript);

    /// <summary>
    /// Returns a radius of 1 for a wooden torch.
    /// </summary>
    public override int Radius => 1;

    protected override string ItemClassBindingKey => nameof(LightSourcesItemClass);
    protected override string[] WieldSlotBindingKeys => new string[] { nameof(LightsourceWieldSlot) };

    protected override (int, string)[]? MassProduceBindingTuples => new (int, string)[]
    {
        (20, "3d5-3")
    };

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBindingTuples => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(PoorOrbOfLightEnchantmentScript) }),
        (new int[] {1}, null, new string[] { nameof(GoodOrbOfLightEnchantmentScript) }),
        (new int[] {2}, null, new string[] { nameof(GreatOrbOfLightEnchantmentScript) }),
         (null, true, new string[] { nameof(FillTorchEnchantmentScript) }),
        (null, false, new string[] { nameof(UsedTorchEnchantmentScript) })
    };

    protected override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}
