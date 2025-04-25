// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OldSpeedProjectile : ProjectileGameConfiguration
{
    public override string? BoltProjectileGraphicBindingKey => nameof(BrightBlueBulletProjectileGraphic);

    public override string? EffectAnimationBindingKey => nameof(BrightBlueSwirlAnimation);

    public override string MonsterEffectBindingKey => nameof(MonsterEffectScripts.OldSpeedMonsterEffect);

    public override string PlayerEffectBindingKey => nameof(PlayerEffectScripts.OldSpeedPlayerEffect);
}