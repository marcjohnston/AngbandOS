// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class SwordWeaponItemFactory : MeleeWeaponItemFactory
{
    public SwordWeaponItemFactory(Game game) : base(game) { }
    protected override bool CanBeWeaponOfLaw => true;
    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (100, "3d5-3")
    };

    protected override bool CanBeWeaponOfSharpness => true;
    protected override bool CapableOfVorpalSlaying => true;
    protected override string ItemClassName => nameof(SwordsItemClass);
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Sword;
    public override bool HatesAcid => true;
    public override int PackSort => 28;

    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override bool CanApplyBlessedArtifactBias => true;
    public override bool CanVorpalSlay => true;
}
