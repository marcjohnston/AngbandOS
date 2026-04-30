// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class MartialArtsAttack : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }

    public MartialArtsAttack(Game game, MartialArtsAttackGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Chance = gameConfiguration.Chance;
        Dd = gameConfiguration.Dd;
        Desc = gameConfiguration.Desc;
        Ds = gameConfiguration.Ds;
        MartialArtsEffectBindingKey = gameConfiguration.MartialArtsEffectBindingKey;
        MinLevel = gameConfiguration.MinLevel;
        IsDefault = gameConfiguration.IsDefault;
    }
    public GameStateBag? Serialize(SaveGameState saveGameState) => null;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        MartialArtsAttackGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            Chance = Chance,
            Dd = Dd,
            Desc = Desc,
            Ds = Ds,
            MartialArtsEffectBindingKey = MartialArtsEffectBindingKey,
            MinLevel = MinLevel,
            IsDefault = IsDefault,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public string Key { get; }

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState)
    {
        MartialArtsAttackEffect = Game.SingletonRepository.Get<MartialArtsEffect>(MartialArtsEffectBindingKey);
    }

    public int Chance { get; }
    public int Dd { get; }
    public string Desc { get; }
    public int Ds { get; }
    public MartialArtsEffect MartialArtsAttackEffect { get; private set; }
    private string MartialArtsEffectBindingKey { get; }
    public int MinLevel { get;  }
    public bool IsDefault { get; } = false;
}