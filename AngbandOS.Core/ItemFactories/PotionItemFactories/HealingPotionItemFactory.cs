// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HealingPotionItemFactory : PotionItemFactory
{
    private HealingPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(ExclamationPointSymbol));
    public override string Name => "Healing";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 300;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Healing";
    public override int LevelNormallyFound => 15;
    public override int[] Locale => new int[] { 15, 30, 60, 0 };
    public override int InitialTypeSpecificValue => 200;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // Healing heals you 300 health, and cures blindness, confusion, stun, poison, and bleeding
        if (Game.RestoreHealth(300))
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
        Game.Project(who, 2, y, x, Game.DiceRoll(10, 10), Game.SingletonRepository.Projectiles.Get(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(Game, this);
}
