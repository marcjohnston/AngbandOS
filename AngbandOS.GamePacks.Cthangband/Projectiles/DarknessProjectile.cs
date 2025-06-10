// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarknessProjectile : ProjectileGameConfiguration
{
    public override string? BoltProjectileGraphicBindingKey => nameof(BlackBoltProjectileGraphic);

    public override string? ImpactProjectileGraphicBindingKey => nameof(BlackSplatProjectileGraphic);

    public override string FloorEffectBindingKey => nameof(FloorEffectScriptsEnum.DarknessFloorEffect);

    public override string MonsterEffectBindingKey => nameof(MonsterEffectScriptsEnum.DarknessMonsterEffect);

    public override string PlayerEffectBindingKey => nameof(PlayerEffectScriptsEnum.DarknessPlayerEffect);
}