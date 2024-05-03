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

    public override int Cost => 15;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Cure Light Wounds";
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1),
        (1, 1),
        (3, 1)
    };
    public override int InitialNutritionalValue => 50;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;
        // Cure light wounds heals you 2d8 health and reduces bleeding
        if (Game.RestoreHealth(Game.DiceRoll(2, 8)))
        {
            identified = true;
        }
        if (Game.BleedingTimer.AddTimer(-10))
        {
            identified = true;
        }
        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, Game.DiceRoll(2, 3), Game.SingletonRepository.Get<Projectile>(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(Game, this);
}
