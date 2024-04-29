// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class DisintegrateProjectile : Projectile
{
    private DisintegrateProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.ProjectileGraphics.Get(nameof(GreenBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(GreenContractAnimation));

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items)
        {
            bool plural = false;
            if (oPtr.Count > 1)
            {
                plural = true;
            }
            string noteKill = plural ? " evaporate!" : " evaporates!";
            if (oPtr.Marked)
            {
                obvious = true;
                oName = oPtr.Description(false, 0);
            }
            if (oPtr.IsArtifact)
            {
                if (oPtr.Marked)
                {
                    string s = plural ? "are" : "is";
                    Game.MsgPrint($"The {oName} {s} unaffected!");
                }
            }
            else
            {
                if (oPtr.Marked && string.IsNullOrEmpty(noteKill))
                {
                    Game.MsgPrint($"The {oName}{noteKill}");
                }
                bool isPotion = oPtr.Factory.CategoryEnum == ItemTypeEnum.Potion;
                Game.DeleteObject(oPtr);
                if (isPotion)
                {
                    PotionItemFactory potion = (PotionItemFactory)oPtr.Factory;
                    potion.Smash(who, y, x);
                }
                Game.MainForm.RefreshMapLocation(y, x);
            }
        }
        return obvious;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        string? noteDies = null;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.HurtByRock)
        {
            if (seen)
            {
                rPtr.Knowledge.Characteristics.HurtByRock = true;
            }
            note = " loses some skin!";
            noteDies = " evaporates!";
            dam *= 2;
        }
        if (rPtr.Unique)
        {
            if (Game.RandomLessThan(rPtr.Level + 10) > Game.RandomLessThan(Game.ExperienceLevel.IntValue))
            {
                note = " resists.";
                dam >>= 3;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by pure energy!");
        }
        Game.TakeHit(dam, killer);
        return true;
    }
}