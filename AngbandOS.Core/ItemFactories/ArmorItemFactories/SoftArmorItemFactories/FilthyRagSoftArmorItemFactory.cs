// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FilthyRagSoftArmorItemFactory : ArmorItemFactory
{
    private FilthyRagSoftArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenParenthesisSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Filthy Rag";

    public override int ArmorClass => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int Cost => 1;
    protected override string? DescriptionSyntax => "Filthy Rag~";
    public override int BonusArmorClass => -1;
    public override int Weight => 20;

    /// <summary>
    /// Returns the on-body inventory slot for soft armor.
    /// </summary>
    public override int WieldSlot => InventorySlot.OnBody;

    protected override string ItemClassName => nameof(SoftArmorsItemClass);
    public override int PackSort => 21;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;
    public override bool CanApplyArtifactBiasResistance => true;

    /// <summary>
    /// Returns true because broken armor should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Armor. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
    public override bool IsArmor => true;
    public override bool IdentityCanBeSensed => true;
    public override bool IsWearableOrWieldable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => BonusArmorClass >= 0;
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleSoftArmorEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorSoftArmorEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodSoftArmorEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatSoftArmorEnchantmentScript) })
    };
}
