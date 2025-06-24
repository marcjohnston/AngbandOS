// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
namespace AngbandOS.Core;

[Serializable]
internal class Gender : IGetKey
{
    protected readonly Game Game;
    public Gender(Game game, GenderGameConfiguration genderGameConfiguration)
    {
        Game = game;
        Key = genderGameConfiguration.Key ?? genderGameConfiguration.GetType().Name;
        Title = genderGameConfiguration.Title;
        Winner = genderGameConfiguration.Winner;
        CanBeRandomlySelected = genderGameConfiguration.CanBeRandomlySelected;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        GenderGameConfiguration definition = new GenderGameConfiguration()
        {
            Key = Key,
            Title = Title,
            Winner = Winner,
            CanBeRandomlySelected = CanBeRandomlySelected
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind() { }

    public virtual string Title { get; }
    public virtual string Winner { get; } // TODO ... this winner title to describe the type of winner is not rendered

    public virtual bool CanBeRandomlySelected { get; } = true;
}
