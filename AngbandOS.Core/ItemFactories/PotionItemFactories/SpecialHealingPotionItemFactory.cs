// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpecialHealingPotionItemFactory : PotionItemFactory
{
    private SpecialHealingPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "*Healing*";

    public override int Cost => 1500;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "*Healing*";
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 4),
        (60, 2),
        (80, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // *Healing* heals you 1200 health, and cures blindness, confusion, stun, poison,
        // and bleeding
        if (Game.RestoreHealth(1200))
        {
            identified = true;
        }
        if (Game.BlindnessTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.ConfusedTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.PoisonTimer.ResetTimer())
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

        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 1, y, x, Game.DiceRoll(50, 50), Game.SingletonRepository.Get<Projectile>(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
}
