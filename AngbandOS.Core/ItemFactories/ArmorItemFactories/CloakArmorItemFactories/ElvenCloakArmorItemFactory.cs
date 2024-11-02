// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ElvenCloakArmorItemFactory : ArmorItemFactory
{
    private ElvenCloakArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenParenthesisSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Elven Cloak";

    public override int InitialBonusSearch => Game.DieRoll(4);
    public override int InitialBonusStealth => Game.DieRoll(4);

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] { -2 }, null, new string[] { nameof(TerribleCloakEnchantmentScript) }),
        (new int[] { -1, -2 }, null, new string[] { nameof(PoorCloakEnchantmentScript) }),
        (new int[] { 1, 2 }, null, new string[] { nameof(GoodCloakEnchantmentScript) }),
        (new int[] { 2 }, null, new string[] { nameof(GreatCloakEnchantmentScript) })
    };

    public override int ArmorClass => 4;
    public override int Cost => 1500;
    protected override string? DescriptionSyntax => "Elven Cloak~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 4)
    };
    public override bool Search => true;
    public override bool Stealth => true;
    public override int BonusArmorClass => 4;
    public override int Weight => 5;

    /// <summary>
    /// Returns the about body inventory slot for cloaks.
    /// </summary>
    public override int WieldSlot => InventorySlot.AboutBody;

    protected override string ItemClassName => nameof(CloaksItemClass);
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override int PackSort => 22;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;

    public override bool CanReflectBoltsAndArrows => true;

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
}
