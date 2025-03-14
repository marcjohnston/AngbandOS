﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class JamDoorProjectile : Projectile
{
    private JamDoorProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(YellowSwirlAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        if (cPtr.FeatureType.IsVisibleDoor)
        {
            Tile? jammedTile = cPtr.FeatureType.OnJammedTile;
            if (jammedTile == null)
            {
                throw new Exception("No jammed door specified.");
            }
            cPtr.SetFeature(jammedTile);
            if (Game.PlayerHasLosBold(y, x))
            {
                Game.MsgPrint("The door seems stuck.");
                obvious = true;
            }
        }
        return obvious;
    }

    protected override string AffectMonsterScriptBindingKey => nameof(JamDoorMonsterEffect);
}