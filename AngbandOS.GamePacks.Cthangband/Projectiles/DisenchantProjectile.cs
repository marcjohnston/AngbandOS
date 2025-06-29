﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DisenchantProjectile : ProjectileGameConfiguration
{
    public override string? BoltProjectileGraphicBindingKey => nameof(ChartreuseSplatProjectileGraphic);

    public override string? ImpactProjectileGraphicBindingKey => nameof(ChartreuseSplatProjectileGraphic);

    public override string MonsterEffectBindingKey => nameof(MonsterEffectScriptsEnum.DisenchantMonsterEffect);

    public override string PlayerEffectBindingKey => nameof(PlayerEffectScriptsEnum.DisenchantPlayerEffect);
}