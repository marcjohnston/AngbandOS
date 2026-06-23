namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Returns the number of turns of light that is consumed per turn.  Defaults to zero; which means there is no consumption and that the light source lasts forever.
/// Torches and laterns have burn rates greater than zero.
/// </summary>
[Serializable]
public class BurnRateAttribute : SumAttributeGameConfiguration
{
}

