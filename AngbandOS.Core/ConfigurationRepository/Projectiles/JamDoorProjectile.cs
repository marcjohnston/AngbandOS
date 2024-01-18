// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class JamDoorProjectile : Projectile
{
    private JamDoorProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get(nameof(YellowSwirlAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsClosedDoor)
        {
            if (cPtr.FeatureType.Name.Contains("Locked"))
            {
                cPtr.SetFeature(cPtr.FeatureType.Name.Replace("Locked", "Jammed"));
            }
            int strength = int.Parse(cPtr.FeatureType.Name.Substring(10));
            if (strength < 7)
            {
                cPtr.SetFeature($"JammedDoor{strength + 1}");
            }
            if (SaveGame.PlayerHasLosBold(y, x))
            {
                SaveGame.MsgPrint("The door seems stuck.");
                obvious = true;
            }
        }
        return obvious;
    }

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        string? note = null;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return false;
    }
}