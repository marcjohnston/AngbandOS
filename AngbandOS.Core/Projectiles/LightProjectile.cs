// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class LightProjectile : Projectile
    {
        public LightProjectile(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightWhiteBolt";

        protected override string EffectAnimation => "BrightWhiteCloud";

        protected override bool AffectFloor(int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            bool obvious = false;
            cPtr.TileFlags.Set(GridTile.SelfLit);
            SaveGame.Level.NoteSpot(y, x);
            SaveGame.Level.RedrawSingleLocation(y, x);
            if (SaveGame.Level.PlayerCanSeeBold(y, x))
            {
                obvious = true;
            }
            if (cPtr.MonsterIndex != 0)
            {
                SaveGame.Level.Monsters.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
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
            bool blind = SaveGame.Player.TimedBlindness.TurnsRemaining != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.IndefiniteVisibleName;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by something!");
            }
            if (SaveGame.Player.HasLightResistance)
            {
                dam *= 4;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            else if (!blind && !SaveGame.Player.HasBlindnessResistance)
            {
                SaveGame.Player.TimedBlindness.AddTimer(Program.Rng.DieRoll(5) + 2);
            }
            if (SaveGame.Player.Race.IsBurnedBySunlight)
            {
                SaveGame.MsgPrint("The light scorches your flesh!");
                dam *= 2;
            }
            SaveGame.Player.TakeHit(dam, killer);
            if (SaveGame.Player.TimedEtherealness.TurnsRemaining != 0)
            {
                SaveGame.Player.TimedEtherealness.SetValue();
                SaveGame.MsgPrint("The light forces you out of your incorporeal shadow form.");
                SaveGame.RedrawMapFlaggedAction.Set();
                SaveGame.UpdateMonstersFlaggedAction.Set();
            }
            return true;
        }
    }
}