// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FireBoltOrBeam8d8ProjectileScriptWeightedRandom : ProjectileScriptWeightedRandomGameConfiguration
{
    public override (string, int)[] NameAndWeightBindings => new (string, int)[]
    {
        (nameof(Fire8d8ProjectileScript), 1),
        (nameof(FireBeam8d8ProjectileScript), 1),
    };
}
