// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WonderProjectileWeightedRandom : ProjectileWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(Acid60r2ProjectileScript), 2),
        (nameof(Acid3d8ProjectileScript), 1),
        (nameof(AcidBeam3d8ProjectileScript), 1),
        (nameof(Charm45ProjectileScript), 2),
        (nameof(OldCloneProjectileScript), 2),
        (nameof(Cold48r2ProjectileScript), 2),
        (nameof(Cold3d8ProjectileScript), 2),
        (nameof(OldConfuse10ProjectileScript), 2),
        (nameof(DestroyTrapProjectileScript), 2),
        (nameof(OldDrainLife75ProjectileScript), 2),
        (nameof(Electricity32r2ProjectileScript), 2),
        (nameof(TurnAll10ProjectileScript), 2),
        (nameof(Fire72r2ProjectileScript), 2),
        (nameof(Fire6d8ProjectileScript), 2),
        (nameof(OldSpeed1xProjectileScript), 2),
        (nameof(OldHeal4d6ProjectileScript), 2),
        (nameof(LightWeak6d8ProjectileScript), 2),
        (nameof(Missile2d6ProjectileScript), 1),
        (nameof(MissileBeam2d6ProjectileScript), 1),
        (nameof(OldPolymorph1xProjectileScript), 2),
        (nameof(OldSleep1xProjectileScript), 2),
        (nameof(OldSlow1xProjectileScript), 2),
        (nameof(Poison12r2ProjectileScript), 2),
        (nameof(WallToMud1d30p20ProjectileScript), 2),
        (nameof(TeleportAwayAll100ProjectileScript), 2),
        (nameof(DestroyTrapOrDoorProjectileScript), 2)
    };
}
