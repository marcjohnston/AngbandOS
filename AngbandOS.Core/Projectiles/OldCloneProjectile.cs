﻿// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class OldCloneProjectile : Projectile
    {
        public OldCloneProjectile(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "CopperBolt";

        protected override string EffectAnimation => "CopperExpand";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            // The attack will turn friends 1 in 8 times.
            return (Program.Rng.DieRoll(8) == 1);
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string? note = null;
            bool isFriend = false;
            if (seen)
            {
                obvious = true;
            }
            if (mPtr.SmFriendly && Program.Rng.DieRoll(3) != 1)
            {
                isFriend = true;
            }
            mPtr.Health = mPtr.MaxHealth;
            if (mPtr.Speed < 150)
            {
                mPtr.Speed += 10;
            }
            Monster targetMonster = SaveGame.Level.Monsters[cPtr.MonsterIndex];
            if (SaveGame.Level.Monsters.MultiplyMonster(targetMonster, isFriend, true))
            {
                note = " spawns!";
            }
            dam = 0;
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }
    }
}