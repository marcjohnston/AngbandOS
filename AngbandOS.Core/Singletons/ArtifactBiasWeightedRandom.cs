// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
internal sealed class ArtifactBiasWeightedRandom : WeightedRandom<ArtifactBias?>, IGetKey, IToJson, ISaveGameState
{
    public ArtifactBiasWeightedRandom(Game game, ArtifactBiasWeightedRandomGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.GetKey;
        ArtifactBiasBindingKeyAndWeightTuples = gameConfiguration.ArtifactBiasBindingKeyAndWeightTuples;
    }

    public GameStateBag? SaveGame(SaveGameState saveGameState) => null;

    public string Key { get; }
    public string GetKey => Key;

    private (string?, int)[] ArtifactBiasBindingKeyAndWeightTuples { get; }

    public void Bind()
    {
        foreach ((string? artifactBiasBindingKey, int weight) in ArtifactBiasBindingKeyAndWeightTuples)
        {
            Add(weight, Game.SingletonRepository.GetNullable<ArtifactBias>(artifactBiasBindingKey));
        }
    }
    public void RestoreGame(RestoreGameState restoreGameState) { }
    public void InitializationComplete() { }

    public string ToJson()
    {
        ArtifactBiasWeightedRandomGameConfiguration definition = new ArtifactBiasWeightedRandomGameConfiguration()
        {
            Key = Key,
            ArtifactBiasBindingKeyAndWeightTuples = ArtifactBiasBindingKeyAndWeightTuples,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
}