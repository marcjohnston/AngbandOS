// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ArtifactBiasNullableReferenceAttribute : NullableReferenceAttribute<ArtifactBias?>, IGetKey, IToJson
{
    public ArtifactBiasNullableReferenceAttribute(Game game, ArtifactBiasNullableReferenceAttributeGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
    }
    public string Key { get; }

    public string GetKey => Key;
    public void Bind() { }
    public string ToJson()
    {
        return "";
    }
}
