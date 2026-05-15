// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class God : IGetKey, IToJson, IGameSerialize
{
    #region State Data
    public int Favor;
    public bool IsPatron;
    public int RestingFavor;
    #endregion

    private Game Game { get; }
    public God(Game game, GodGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        LongName = gameConfiguration.LongName;
        ShortName = gameConfiguration.ShortName;
        FavorDescription = gameConfiguration.FavorDescription;
    }

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Favor), saveGameState.CreateGameStateBag(Favor)),
            (nameof(IsPatron), saveGameState.CreateGameStateBag(IsPatron)),
            (nameof(RestingFavor), saveGameState.CreateGameStateBag(RestingFavor))
        );
    }
    public string LongName { get; }
    public string ShortName { get; }
    private const int PatronMultiplier = 2;

    public int AdjustedFavour
    {
        get
        {
            if (Favor <= 0)
            {
                return 0;
            }
            var adjusted = IsPatron ? Favor * PatronMultiplier : Favor;
            return Math.Min(adjusted.ToString().Length, 10);
        }
    }


    public string FavorDescription { get; }

    public string Key { get; }

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
    {
        if (restoreGameState is not null)
        {
            Favor = restoreGameState.GetByKey(nameof(Favor)).GetInt();
            IsPatron = restoreGameState.GetByKey(nameof(IsPatron)).GetBool();
            RestingFavor = restoreGameState.GetByKey(nameof(RestingFavor)).GetInt();   
        }
    }

    public string ToJson()
    {
        GodGameConfiguration definition = new GodGameConfiguration()
        {
            LongName = LongName,
            ShortName = ShortName,
            Key = Key,
            FavorDescription = FavorDescription
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }
}
