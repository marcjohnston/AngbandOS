// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RuinationPotionItemFactory : PotionItemFactory
{
    private RuinationPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Ruination";

    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Dd => 20;
    public override int Ds => 20;
    public override string FriendlyName => "Ruination";
    public override int LevelNormallyFound => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Ruination does 10d10 damage and reduces all your ability scores, bypassing
        // sustains and divine protection
        Game.MsgPrint("Your nerves and muscles feel weak and lifeless!");
        Game.TakeHit(Game.DiceRoll(10, 10), "a potion of Ruination");
        Game.DecreaseAbilityScore(Ability.Dexterity, 25, true);
        Game.DecreaseAbilityScore(Ability.Wisdom, 25, true);
        Game.DecreaseAbilityScore(Ability.Constitution, 25, true);
        Game.DecreaseAbilityScore(Ability.Strength, 25, true);
        Game.DecreaseAbilityScore(Ability.Charisma, 25, true);
        Game.DecreaseAbilityScore(Ability.Intelligence, 25, true);
        return true;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, Game.DiceRoll(25, 25), Game.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}