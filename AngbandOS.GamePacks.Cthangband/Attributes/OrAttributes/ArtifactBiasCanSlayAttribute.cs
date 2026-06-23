namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents an attribute that indicates whether an item can be given a slaying bonus during random artifact creation.  Bows return true, all other items return false.
/// </summary>
[Serializable]
public class ArtifactBiasCanSlayAttribute : OrAttributeGameConfiguration
{
}