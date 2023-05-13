// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    [Serializable]
    internal class MakeDoorProjectile : Projectile
    {
        private MakeDoorProjectile(SaveGame saveGame) : base(saveGame) { }

        protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<BrightBrownSparkleAnimation>();

        protected override bool AffectFloor(int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            bool obvious = false;
            if (!SaveGame.Level.GridOpenNoItemOrCreature(y, x))
            {
                return false;
            }
            SaveGame.Level.CaveSetFeat(y, x, "LockedDoor0");
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
            {
                obvious = true;
            }
            SaveGame.UpdateMonstersFlaggedAction.Set();
            SaveGame.UpdateLightFlaggedAction.Set();
            SaveGame.UpdateViewFlaggedAction.Set();
            return obvious;
        }

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            return false;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            MonsterRace rPtr = mPtr.Race;
            string? note = null;
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return false;
        }
    }
}