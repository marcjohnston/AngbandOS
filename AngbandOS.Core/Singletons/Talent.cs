// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal sealed class Talent : IGetKey, IGameSerialize, IToJson
{
    protected Game Game { get; }
    private IScript UseScript { get; set; }
    public Talent(Game game, TalentGameConfiguration gameConfiguration) // This object is a singleton
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Name = gameConfiguration.Name;
        Level = gameConfiguration.Level;
        ManaCost = gameConfiguration.ManaCost;
        BaseFailure = gameConfiguration.BaseFailure;
        UseScriptBindingKey = gameConfiguration.UseScriptBindingKey;
        LearnedKnowledgeBindingKey = gameConfiguration.LearnedKnowledgeBindingKey;
    }
    public string Key { get; }

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState)
    {
        UseScript = Game.SingletonRepository.Get<IScript>(UseScriptBindingKey);
        LearnedKnowledge = Game.SingletonRepository.GetNullable<LearnedKnowledge>(LearnedKnowledgeBindingKey);
    }

    public GameStateBag? Serialize(SaveGameState saveGameState) => null;
    public string Name { get; }

    public int Level { get; }
    public int ManaCost { get; }
    public int BaseFailure { get; }
    public string UseScriptBindingKey { get; }
    public string ToJson()
    {
        TalentGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            Name = Name,
            Level = Level,
            ManaCost = ManaCost,
            BaseFailure = BaseFailure,
            UseScriptBindingKey = UseScriptBindingKey,
            LearnedKnowledgeBindingKey = LearnedKnowledgeBindingKey,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public int FailureChance()
    {
        int chance = BaseFailure;
        chance -= 3 * (Game.ExperienceLevel.IntValue - Level);
        chance -= 3 * (Game.CharacterClass.SpellStat.SpellFailureReduction - 1);
        if (ManaCost > Game.Mana.IntValue)
        {
            chance += 5 * (ManaCost - Game.Mana.IntValue);
        }
        int minfail = Game.CharacterClass.SpellStat.SpellMinFailChance;
        if (chance < minfail)
        {
            chance = minfail;
        }
        if (Game.StunTimer.Value > 50)
        {
            chance += 25;
        }
        else if (Game.StunTimer.Value != 0)
        {
            chance += 15;
        }
        if (chance > 95)
        {
            chance = 95;
        }
        return chance;
    }

    public string SummaryLine()
    {
        return $"{Name,-30}{Level,2} {ManaCost,4} {FailureChance(),3}% {LearnedDetails}";
    }

    public override string ToString()
    {
        return $"{Name} ({Level}, {ManaCost}, {BaseFailure})";
    }

    public void Use()
    {
        UseScript.ExecuteScript();
    }

    protected string? LearnedKnowledgeBindingKey { get; }
    public LearnedKnowledge? LearnedKnowledge { get; private set; }
    public string LearnedDetails => LearnedKnowledge is null ? string.Empty : LearnedKnowledge.LearnedDetails;
}