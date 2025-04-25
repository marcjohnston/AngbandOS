// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HellfireProjectile : ProjectileGameConfiguration
{
    public override string? BoltProjectileGraphicBindingKey => nameof(RedSplatProjectileGraphic);

    public override string? EffectAnimationBindingKey => nameof(RedBlackFlashAnimation);

    public override string ItemEffectBindingKey => nameof(ItemEffectScripts.HellfireItemEffect);

    public override string MonsterEffectBindingKey => nameof(MonsterEffectScripts.HellfireMonsterEffect);

    public override string PlayerEffectBindingKey => nameof(PlayerEffectScripts.HellfirePlayerEffect);
}