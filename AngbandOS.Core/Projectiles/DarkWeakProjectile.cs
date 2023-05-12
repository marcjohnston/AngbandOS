// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class DarkWeakProjectile : Projectile
    {
        private DarkWeakProjectile(SaveGame saveGame) : base(saveGame) { }

        protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GreyBoltProjectileGraphic>();

        protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GreySplatProjectileGraphic>();

        protected override bool AffectFloor(int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            bool obvious = SaveGame.Level.PlayerCanSeeBold(y, x);
            cPtr.TileFlags.Clear(GridTile.SelfLit);
            if (cPtr.FeatureType.IsOpenFloor)
            {
                cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                SaveGame.Level.NoteSpot(y, x);
            }
            SaveGame.Level.RedrawSingleLocation(y, x);
            if (cPtr.MonsterIndex != 0)
            {
                SaveGame.Level.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
            }
            return obvious;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            ApplyProjectileDamageToMonster(who, mPtr, dam, null);
            return false;
        }
    }
}