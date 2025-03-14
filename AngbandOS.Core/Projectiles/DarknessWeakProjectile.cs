// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class DarknessWeakProjectile : Projectile
{
    private DarknessWeakProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(GreyBoltProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(GreySplatProjectileGraphic));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = Game.PlayerCanSeeBold(y, x);
        cPtr.SelfLit = false;
        if (cPtr.FeatureType.IsOpenFloor)
        {
            cPtr.PlayerMemorized = false;
            Game.NoteSpot(y, x);
        }
        Game.MainForm.RefreshMapLocation(y, x);
        if (cPtr.MonsterIndex != 0)
        {
            Game.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
        }
        return obvious;
    }

    protected override string AffectMonsterScriptBindingKey => nameof(DarknessWeakMonsterEffect);
}