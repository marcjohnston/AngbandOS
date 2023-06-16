namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RestoreManaPotionItemFactory : PotionItemFactory
{
    private RestoreManaPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Restore Mana";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 350;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Restore Mana";
    public override int Level => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int? SubCategory => (int)PotionType.RestoreMana;
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        // Restore mana restores your to maximum mana
        if (saveGame.Player.Mana < saveGame.Player.MaxMana)
        {
            saveGame.Player.Mana = saveGame.Player.MaxMana;
            saveGame.Player.FractionalMana = 0;
            saveGame.MsgPrint("Your feel your head clear.");
            saveGame.RedrawManaFlaggedAction.Set();
            return true;
        }
        return false;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        saveGame.Project(who, 1, y, x, Program.Rng.DiceRoll(10, 10), saveGame.SingletonRepository.Projectiles.Get<ManaProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new RestoreManaPotionItem(SaveGame);
}
