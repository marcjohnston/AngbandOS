// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CuringPotionItemFactory : PotionItemFactory
{
    private CuringPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Curing";

    public override int Cost => 250;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Curing";
    public override int LevelNormallyFound => 18;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (18, 1),
        (40, 1)
    };
    public override int InitialNutritionalValue => 100;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;
        // Curing heals you 50 health, and cures blindness, confusion, stun, poison,
        // bleeding, and hallucinations
        if (Game.RestoreHealth(50))
        {
            identified = true;
        }
        if (Game.BlindnessTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.PoisonTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.ConfusedTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.HallucinationsTimer.ResetTimer())
        {
            identified = true;
        }
        return identified;
    }
    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, Game.DiceRoll(6, 3), Game.SingletonRepository.Get<Projectile>(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(Game, this);
}
