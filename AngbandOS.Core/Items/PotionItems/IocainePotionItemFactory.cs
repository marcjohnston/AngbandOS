// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class IocainePotionItemFactory : PotionItemFactory
{
    private IocainePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Iocaine";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Dd => 20;
    public override int Ds => 20;
    public override string FriendlyName => "Iocaine";
    public override int Level => 55;
    public override int[] Locale => new int[] { 55, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        // Iocaine simply does 5000 damage
        saveGame.MsgPrint("A feeling of Death flows through your body.");
        saveGame.Player.TakeHit(5000, "a potion of Death");
        return true;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        saveGame.Project(who, 1, y, x, 0, saveGame.SingletonRepository.Projectiles.Get<DeathRayProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new IocainePotionItem(SaveGame);
}
