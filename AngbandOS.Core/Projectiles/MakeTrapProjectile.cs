﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class MakeTrapProjectile : Projectile
{
    private MakeTrapProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightRedSparkleAnimation));

    protected override bool AffectFloor(int y, int x)
    {
        if (!Game.GridOpenNoItemOrCreature(y, x))
        {
            return false;
        }
        Game.PlaceTrap(y, x);
        return false;
    }

    protected override string AffectMonsterScriptBindingKey => nameof(MakeTrapMonsterEffect);
}