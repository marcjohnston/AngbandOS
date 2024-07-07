// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CureLightWoundsPotionItemFactory : PotionItemFactory
{
    private CureLightWoundsPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Cure Light Wounds";
    protected override string? DescriptionSyntax => "$Flavor$ Potion~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Potion~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Potion~ of $Name$";
    public override int Cost => 15;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1),
        (1, 1),
        (3, 1)
    };
    public override int InitialNutritionalValue => 50;
    public override int Weight => 4;
    protected override string? QuaffNoticeableScriptName => nameof(CureLightWounds2d8Script);
    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, Game.DiceRoll(2, 3), Game.SingletonRepository.Get<Projectile>(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
}
