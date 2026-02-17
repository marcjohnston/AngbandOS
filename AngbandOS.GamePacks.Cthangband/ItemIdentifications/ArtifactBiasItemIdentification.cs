namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ArtifactBiasItemIdentification : ItemIdentificationGameConfiguration
    {
        public override bool? ArtifactBiasAttributeNonNull => true;
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(SystemAttributes.ArtifactBiasAttribute) };
        public override string[] EffectDescription => new string[] { "It has an affinity for {0}." };
    }
}