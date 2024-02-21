// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DetonationsPotionItemFactory : PotionItemFactory
{
    private DetonationsPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Detonations";

    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 10000;
    public override int Dd => 25;
    public override int Ds => 25;
    public override string FriendlyName => "Detonations";
    public override int LevelNormallyFound => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Detonations does 50d20 damage, stuns you, and gives you a stupid amount of bleeding
        SaveGame.MsgPrint("Massive explosions rupture your body!");
        SaveGame.TakeHit(SaveGame.DiceRoll(50, 20), "a potion of Detonation");
        SaveGame.TimedStun.AddTimer(75);
        SaveGame.TimedBleeding.AddTimer(5000);
        return true;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, SaveGame.DiceRoll(25, 25), SaveGame.SingletonRepository.Projectiles.Get(nameof(ExplodeProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
