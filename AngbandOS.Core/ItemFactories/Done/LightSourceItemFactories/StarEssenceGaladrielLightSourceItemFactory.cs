// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class StarEssenceGaladrielLightSourceItemFactory : ItemFactory
{
    private StarEssenceGaladrielLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(AsteriskSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Star Essence Galadriel";

    /// <summary>
    /// Returns a radius of 2 for a star of essense.
    /// </summary>
    public override int Radius => 2;

    public override int Cost => 10000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    protected override string? DescriptionSyntax => "Star Essence~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 1;
    public override int Weight => 10;
    public override bool ProvidesSunlight => true;
 
    /// <summary>
    /// Returns the lightsource inventory slot for light sources.
    /// </summary>
    public override int WieldSlot => InventorySlot.Lightsource;
    protected override string ItemClassName => nameof(LightSourcesItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(LightsourceInventorySlot));

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (20, "3d5-3")
    };

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
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
