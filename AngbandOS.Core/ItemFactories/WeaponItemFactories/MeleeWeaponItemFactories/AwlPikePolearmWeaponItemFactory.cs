// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AwlPikePolearmWeaponItemFactory : MeleeWeaponItemFactory
{
    private AwlPikePolearmWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ForwardSlashSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Awl-Pike";

    public override int Cost => 340;
    public override int DamageDice => 1;
    public override int DamageSides => 8;
    protected override string? DescriptionSyntax => "Awl-Pike~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 160;
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    protected override string ItemClassName => nameof(PolearmsItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Polearm;
    public override bool HatesFire => true;
    public override int PackSort => 29;
    public override bool HatesAcid => true;

    public override bool CanApplyBlessedArtifactBias => true;
}