// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RestoreManaPotionItemFactory : PotionItemFactory
{
    private RestoreManaPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Restore Mana";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 350;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Restore Mana";
    public override int LevelNormallyFound => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Restore mana restores your to maximum mana
        if (SaveGame.Mana.Value < SaveGame.MaxMana.Value)
        {
            SaveGame.Mana.Value = SaveGame.MaxMana.Value;
            SaveGame.FractionalMana = 0;
            SaveGame.MsgPrint("Your feel your head clear.");
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawManaFlaggedAction)).Set();
            return true;
        }
        return false;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 1, y, x, SaveGame.DiceRoll(10, 10), SaveGame.SingletonRepository.Projectiles.Get(nameof(ManaProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
