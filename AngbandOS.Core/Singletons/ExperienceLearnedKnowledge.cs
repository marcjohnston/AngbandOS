// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class ExperienceLearnedKnowledge : LearnedKnowledge, IGetKey, IToJson, IGameSerialize
{
    public ExperienceLearnedKnowledge(Game game, ExperienceLearnedKnowledgeGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.GetKey;
        ExperienceLearnedKnowledgeBindingTuples = gameConfiguration.ExperienceLearnedKnowledgeBindingTuples;
    }

    public (int? MaxExperienceLevel, string LearnedKnowledgeBindingKey)[] ExperienceLearnedKnowledgeBindingTuples { get; }
    public (int? MaxExperienceLevel, LearnedKnowledge LearnedKnowledge)[] ExperienceLearnedKnowledgeTuples { get; private set; }
    public override string LearnedDetails
    {
        get
        {
            int index = 0;
            while (Game.ExperienceLevel.IntValue > ExperienceLearnedKnowledgeTuples[index].MaxExperienceLevel)
            {
                index++;
            }
            LearnedKnowledge learnedKnowledge = ExperienceLearnedKnowledgeTuples[index].LearnedKnowledge;
            return learnedKnowledge.LearnedDetails;
        }
    }

    public string Key { get; }

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
    {
        if (ExperienceLearnedKnowledgeBindingTuples.Length < 1)
        {
            throw new Exception("ExperienceLearnedKnowledge must have at least one ExperienceLearnedKnowledgeBindingTuple.");
        }

        List<(int? MaxExperienceLevel, LearnedKnowledge LearnedKnowledge)> ExperienceLearnedKnowledgeTupleList = new();
        foreach ((int? MaxExperienceLevel, string LearnedKnowledgeBindingKey) in ExperienceLearnedKnowledgeBindingTuples)
        {
            LearnedKnowledge learnedKnowledge = Game.SingletonRepository.Get<LearnedKnowledge>(LearnedKnowledgeBindingKey);
            ExperienceLearnedKnowledgeTupleList.Add((MaxExperienceLevel, learnedKnowledge));
        }
        ExperienceLearnedKnowledgeTuples = ExperienceLearnedKnowledgeTupleList.ToArray();
    }
    public string ToJson()
    {
        ExperienceLearnedKnowledgeGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            ExperienceLearnedKnowledgeBindingTuples = ExperienceLearnedKnowledgeBindingTuples,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public GameStateBag? Serialize(SaveGameState saveGameState) => null;
}
