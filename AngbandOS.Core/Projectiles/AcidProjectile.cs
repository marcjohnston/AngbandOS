// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class AcidProjectile : Projectile
{
    private AcidProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BrightChartreuseBoltProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BrightChartreuseSplatProjectileGraphic));

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items.ToArray()) // Prevent collection modified error
        {
            bool ignore = false;
            bool plural = false;
            bool doKill = false;
            string noteKill = null;
            ItemCharacteristics mergedCharacteristics = oPtr.GetMergedCharacteristics();
            if (oPtr.Count > 1)
            {
                plural = true;
            }
            if (oPtr.HatesAcid())
            {
                doKill = true;
                noteKill = plural ? " melt!" : " melts!";
                if (mergedCharacteristics.IgnoreAcid)
                {
                    ignore = true;
                }
            }
            if (doKill)
            {
                if (oPtr.WasNoticed)
                {
                    obvious = true;
                    oName = oPtr.GetDescription(false);
                }
                if (oPtr.IsArtifact || ignore)
                {
                    if (oPtr.WasNoticed)
                    {
                        string s = plural ? "are" : "is";
                        Game.MsgPrint($"The {oName} {s} unaffected!");
                    }
                }
                else
                {
                    if (oPtr.WasNoticed && string.IsNullOrEmpty(noteKill))
                    {
                        Game.MsgPrint($"The {oName}{noteKill}");
                    }
                    bool isPotion = oPtr.Factory.CanBeQuaffed;
                    Game.DeleteObject(oPtr);
                    if (isPotion)
                    {
                        PotionItemFactory potion = (PotionItemFactory)oPtr.Factory;
                        potion.Smash(who, y, x);
                    }
                    Game.MainForm.RefreshMapLocation(y, x);
                }
            }
        }
        return obvious;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = seen;
        string? note = null;
        if (rPtr.ImmuneAcid)
        {
            note = " resists a lot.";
            dam /= 9;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ImmuneAcid = true;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
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
            Game.MsgPrint("You are hit by acid!");
        }
        Game.AcidDam(dam, killer);
        return true;
    }
}