// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LifePotionItemFactory : PotionItemFactory
{
    private LifePotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Life";

    public override int Cost => 5000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Life";
    public override int LevelNormallyFound => 60;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (60, 4),
        (100, 2)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Life heals you 5000 health, removes experience and ability score drains, and
        // cures blindness, confusion, stun, poison, and bleeding
        Game.MsgPrint("You feel life flow through your body!");
        Game.RunScript(nameof(RestoreLevelScript));
        Game.RestoreHealth(5000);
        Game.PoisonTimer.ResetTimer();
        Game.BlindnessTimer.ResetTimer();
        Game.ConfusedTimer.ResetTimer();
        Game.HallucinationsTimer.ResetTimer();
        Game.StunTimer.ResetTimer();
        Game.BleedingTimer.ResetTimer();
        Game.TryRestoringAbilityScore(Ability.Strength);
        Game.TryRestoringAbilityScore(Ability.Constitution);
        Game.TryRestoringAbilityScore(Ability.Dexterity);
        Game.TryRestoringAbilityScore(Ability.Wisdom);
        Game.TryRestoringAbilityScore(Ability.Intelligence);
        Game.TryRestoringAbilityScore(Ability.Charisma);
        return true;
    }
    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 1, y, x, Game.DiceRoll(50, 50), Game.SingletonRepository.Get<Projectile>(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(Game, this);
}
