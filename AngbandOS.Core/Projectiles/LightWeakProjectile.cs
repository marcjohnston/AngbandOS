// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class LightWeakProjectile : Projectile
{
    private LightWeakProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.ProjectileGraphics.Get(nameof(BrightWhiteBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightWhiteCloudAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        cPtr.SelfLit = true;
        Game.NoteSpot(y, x);
        Game.MainForm.RefreshMapLocation(y, x);
        if (Game.PlayerCanSeeBold(y, x))
        {
            obvious = true;
        }
        if (cPtr.MonsterIndex != 0)
        {
            Game.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
        }
        return obvious;
    }

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only friends that are hurt by light are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.HurtByLight;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        string? noteDies = null;
        if (rPtr.HurtByLight)
        {
            if (seen)
            {
                obvious = true;
            }
            if (seen)
            {
                rPtr.Knowledge.Characteristics.HurtByLight = true;
            }
            note = " cringes from the light!";
            noteDies = " shrivels away in the light!";
        }
        else
        {
            dam = 0;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }
}