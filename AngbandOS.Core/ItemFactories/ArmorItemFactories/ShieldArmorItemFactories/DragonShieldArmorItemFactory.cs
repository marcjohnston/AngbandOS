// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonShieldArmorItemFactory : ShieldArmorItemFactory
{
    private DragonShieldArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Dragon Shield";

    /// <summary>
    /// Returns the base dragon scale mail rating plus 5 for shields of dragon scale mail.
    /// </summary>
    public override int TreasureRating => base.TreasureRating + 5;

    /// <summary>
    /// Applies special magic to this dragon shield.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        // Apply the standard armor characteristics, regardless of the power level.
        base.ApplyMagic(item, level, power, null);

        ApplyDragonscaleResistance(item);
    }

    public override int ArmorClass => 8;
    public override int Cost => 10000;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    protected override string? DescriptionSyntax => "Dragon Shield~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 70;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (80, 4)
    };
    public override int BonusArmorClass => 10;
    public override int Weight => 100;

    /// <summary>
    /// Returns the arm inventory slot for shields.
    /// </summary>
    public override int WieldSlot => InventorySlot.Arm;

    protected override string ItemClassName => nameof(ShieldsItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(ArmInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Shield;
    public override int PackSort => 23;
    public override bool HatesAcid => true;

    public override bool CanReflectBoltsAndArrows => true;

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
    public override bool IsWearable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => BonusArmorClass >= 0;
}
