// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class LightProjectile : Projectile
{
    private LightProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(BrightWhiteBoltProjectileGraphic));

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get(nameof(BrightWhiteCloudAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = false;
        cPtr.TileFlags.Set(GridTile.SelfLit);
        SaveGame.NoteSpot(y, x);
        SaveGame.RedrawSingleLocation(y, x);
        if (SaveGame.PlayerCanSeeBold(y, x))
        {
            obvious = true;
        }
        if (cPtr.MonsterIndex != 0)
        {
            SaveGame.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
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

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = SaveGame.TimedBlindness.TurnsRemaining != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by something!");
        }
        if (SaveGame.HasLightResistance)
        {
            dam *= 4;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
        }
        else if (!blind && !SaveGame.HasBlindnessResistance)
        {
            SaveGame.TimedBlindness.AddTimer(SaveGame.Rng.DieRoll(5) + 2);
        }
        if (SaveGame.Race.IsBurnedBySunlight)
        {
            SaveGame.MsgPrint("The light scorches your flesh!");
            dam *= 2;
        }
        SaveGame.TakeHit(dam, killer);
        if (SaveGame.TimedEtherealness.TurnsRemaining != 0)
        {
            SaveGame.TimedEtherealness.SetValue();
            SaveGame.MsgPrint("The light forces you out of your incorporeal shadow form.");
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        return true;
    }
}