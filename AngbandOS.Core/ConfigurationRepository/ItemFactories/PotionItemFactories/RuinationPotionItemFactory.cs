// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RuinationPotionItemFactory : PotionItemFactory
{
    private RuinationPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Ruination";

    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Dd => 20;
    public override int Ds => 20;
    public override string FriendlyName => "Ruination";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Ruination does 10d10 damage and reduces all your ability scores, bypassing
        // sustains and divine protection
        SaveGame.MsgPrint("Your nerves and muscles feel weak and lifeless!");
        SaveGame.TakeHit(SaveGame.DiceRoll(10, 10), "a potion of Ruination");
        SaveGame.DecreaseAbilityScore(Ability.Dexterity, 25, true);
        SaveGame.DecreaseAbilityScore(Ability.Wisdom, 25, true);
        SaveGame.DecreaseAbilityScore(Ability.Constitution, 25, true);
        SaveGame.DecreaseAbilityScore(Ability.Strength, 25, true);
        SaveGame.DecreaseAbilityScore(Ability.Charisma, 25, true);
        SaveGame.DecreaseAbilityScore(Ability.Intelligence, 25, true);
        return true;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, SaveGame.DiceRoll(25, 25), SaveGame.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
