// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class Patron : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }
    public Patron(Game game, PatronGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        LongName = gameConfiguration.LongName;
        PreferredAbilityBindingKey = gameConfiguration.PreferredAbilityBindingKey;
        RewardBindingKeys = gameConfiguration.RewardBindingKeys;
        ShortName = gameConfiguration.ShortName;
    }

    public DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(RewardReceived), new BoolValueGameStateBag(RewardReceived))
        );
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        PatronGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            LongName = LongName,
            PreferredAbilityBindingKey = PreferredAbilityBindingKey,
            RewardBindingKeys = RewardBindingKeys,
            ShortName = ShortName
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public string Key { get; }

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState)
    {
        PreferredAbility = Game.SingletonRepository.GetNullable<Ability>(PreferredAbilityBindingKey);
        Rewards = Game.SingletonRepository.Get<Reward>(RewardBindingKeys);
    }

    public string LongName { get; }
    public bool RewardReceived;

    public Ability? PreferredAbility { get; private set; }
    private string? PreferredAbilityBindingKey { get; } = null;
    private Reward[] Rewards { get; set; }
    private string[] RewardBindingKeys { get; } 
    public string ShortName { get; }

    public void GetReward()
    {
        int type;
        int nastyChance = 6;
        if (RewardReceived)
        {
            return;
        }
        RewardReceived = true;
        if (Game.ExperienceLevel.IntValue == 13)
        {
            nastyChance = 2;
        }
        else if (Game.ExperienceLevel.IntValue % 13 == 0)
        {
            nastyChance = 3;
        }
        else if (Game.ExperienceLevel.IntValue % 14 == 0)
        {
            nastyChance = 12;
        }
        if (Game.DieRoll(nastyChance) == 1)
        {
            type = Game.DieRoll(20);
        }
        else
        {
            type = Game.DieRoll(15) + 5;
        }
        if (type < 1)
        {
            type = 1;
        }
        if (type > 20)
        {
            type = 20;
        }
        type--;
        Reward effect = Rewards[type];
        if (Game.DieRoll(6) == 1)
        {
            Game.MsgPrint($"{ShortName} rewards you with a mutation!");
            Game.RunScript(nameof(GainMutationScript));
            return;
        }
        effect.GetReward(this);
    }

    public override string ToString()
    {
        return ShortName;
    }
}