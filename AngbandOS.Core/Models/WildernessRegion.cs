// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class WildernessRegion : IGameSerialize
{
    /// <summary>
    /// Returns the dungeon that is located in this region; or null, if there is none.
    /// </summary>
    public Dungeon? Dungeon = null;

    /// <summary>
    /// Returns the town that is located in this region; or null, if there is none.
    /// </summary>
    public Town? Town = null;

    public int RoadMap = 0;
    public int Seed = 0;
    public WildernessRegion() { }
    public WildernessRegion(Game game, RestoreGameState restoreGameState)
    {
        Dungeon = restoreGameState.GetReferenceOrDefault<Dungeon>(nameof(Dungeon));
        Town = restoreGameState.GetReferenceOrDefault<Town>(nameof(Town));
        RoadMap = restoreGameState.GetInt(nameof(RoadMap));
        Seed = restoreGameState.GetInt(nameof(Seed));
    }

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Dungeon), saveGameState.CreateGameStateBag(Dungeon)),
            (nameof(Town), saveGameState.CreateGameStateBag(Town)),
            (nameof(RoadMap), saveGameState.CreateGameStateBag(RoadMap)),
            (nameof(Seed), saveGameState.CreateGameStateBag(Seed))
        );
    }
}