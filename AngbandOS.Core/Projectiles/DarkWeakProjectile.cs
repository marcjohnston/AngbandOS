// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class DarkWeakProjectile : Projectile
{
    private DarkWeakProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(GreyBoltProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(GreySplatProjectileGraphic));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = SaveGame.PlayerCanSeeBold(y, x);
        cPtr.TileFlags.Clear(GridTile.SelfLit);
        if (cPtr.FeatureType.IsOpenFloor)
        {
            cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
            SaveGame.NoteSpot(y, x);
        }
        SaveGame.RedrawSingleLocation(y, x);
        if (cPtr.MonsterIndex != 0)
        {
            SaveGame.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
        }
        return obvious;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        ApplyProjectileDamageToMonster(who, mPtr, dam, null);
        return false;
    }
}