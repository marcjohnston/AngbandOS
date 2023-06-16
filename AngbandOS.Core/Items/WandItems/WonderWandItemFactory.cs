namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class WonderWandItemFactory : WandItemFactory
{
    private WonderWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '-';
    public override string Name => "Wonder";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Wonder";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int? SubCategory => WandType.Wonder;
    public override int Weight => 10;
    public override bool ExecuteActivation(SaveGame saveGame, int dir)
    {
        switch (Program.Rng.RandomLessThan(24))
        {
            case 0:
                // Acid ball
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), dir, 60, 2);
                return true;
            case 1:
                // Acid bolt
                saveGame.FireBoltOrBeam(20, saveGame.SingletonRepository.Projectiles.Get<AcidProjectile>(), dir, Program.Rng.DiceRoll(3, 8));
                return true;
            case 2:
                // CharmMonster
                return saveGame.CharmMonster(dir, 45);
            case 3:
                // CloneMonster
                return saveGame.CloneMonster(dir);
            case 4:
                // ColdBall
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 48, 2);
                return true;
            case 5:
                // ColdBolt
                saveGame.FireBoltOrBeam(20, saveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, Program.Rng.DiceRoll(3, 8));
                return true;
            case 6:
                // ConfuseMonster
                return saveGame.ConfuseMonster(dir, 10);
            case 7:
                // Disarming
                return saveGame.DisarmTrap(dir);
            case 8:
                // DrainLife
                return saveGame.DrainLife(dir, 75);
            case 9:
                // ElecBall
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<ElecProjectile>(), dir, 32, 2);
                return true;
            case 10:
                // FearMonster
                return saveGame.FearMonster(dir, 10);
            case 11:
                // FireBall
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, 72, 2);
                return true;
            case 12:
                // FireBolt
                saveGame.FireBoltOrBeam(20, saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, Program.Rng.DiceRoll(6, 8));
                return true;
            case 13:
                // HasteMonster
                return saveGame.SpeedMonster(dir);
            case 14:
                // HealMonster
                return saveGame.HealMonster(dir);
            case 15:
                // Light
                saveGame.MsgPrint("A line of blue shimmering light appears.");
                saveGame.LightLine(dir);
                return true;
            case 16:
                // MagicMissile
                saveGame.FireBoltOrBeam(20, saveGame.SingletonRepository.Projectiles.Get<MissileProjectile>(), dir, Program.Rng.DiceRoll(2, 6));
                return true;
            case 17:
                // Polymorph
                return saveGame.PolyMonster(dir);
            case 18:
                // SleepMonster
                return saveGame.SleepMonster(dir);
            case 19:
                // SlowMonster
                return saveGame.SlowMonster(dir);
            case 20:
                // StinkingCloud
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), dir, 12, 2);
                return true;
            case 21:
                // StoneToMud
                return saveGame.WallToMud(dir);
            case 22:
                // TeleportAway
                return saveGame.TeleportMonster(dir);
            case 23:
                // TrapDoorDest
                return saveGame.DestroyDoor(dir);
            default:
                throw new Exception("Internal error.");
        }
    }
    public override Item CreateItem() => new WonderWandItem(SaveGame);
}
