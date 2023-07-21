// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class LifePotionItemFactory : PotionItemFactory
{
    private LifePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Life";

    public override int[] Chance => new int[] { 4, 2, 0, 0 };
    public override int Cost => 5000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Life";
    public override int Level => 60;
    public override int[] Locale => new int[] { 60, 100, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Life heals you 5000 health, removes experience and ability score drains, and
        // cures blindness, confusion, stun, poison, and bleeding
        SaveGame.MsgPrint("You feel life flow through your body!");
        SaveGame.Player.RestoreLevel();
        SaveGame.Player.RestoreHealth(5000);
        SaveGame.Player.TimedPoison.ResetTimer();
        SaveGame.Player.TimedBlindness.ResetTimer();
        SaveGame.Player.TimedConfusion.ResetTimer();
        SaveGame.Player.TimedHallucinations.ResetTimer();
        SaveGame.Player.TimedStun.ResetTimer();
        SaveGame.Player.TimedBleeding.ResetTimer();
        SaveGame.Player.TryRestoringAbilityScore(Ability.Strength);
        SaveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
        SaveGame.Player.TryRestoringAbilityScore(Ability.Dexterity);
        SaveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
        SaveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
        SaveGame.Player.TryRestoringAbilityScore(Ability.Charisma);
        return true;
    }
    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 1, y, x, Program.Rng.DiceRoll(50, 50), SaveGame.SingletonRepository.Projectiles.Get<OldHealProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new LifePotionItem(SaveGame);
}
