// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MissileProjectile : ProjectileGameConfiguration
{
    public override string? BoltProjectileGraphicBindingKey => nameof(BrightTurquoiseBoltProjectileGraphic);

    public override string? ImpactProjectileGraphicBindingKey => nameof(BrightTurquoiseSplatProjectileGraphic);

    public override string MonsterEffectBindingKey => nameof(MonsterEffectScriptsEnum.MissileMonsterEffect);

    public override string PlayerEffectBindingKey => nameof(PlayerEffectScriptsEnum.MissilePlayerEffect);
}