// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class TownsRepositoryCollection : DictionaryRepositoryCollection<Town>
{
    public TownsRepositoryCollection(SaveGame saveGame) : base(saveGame) { }

    public override void Load()
    {
        if (SaveGame.Configuration.Towns == null)
        {
            base.Load();
        }
        else
        {
            foreach (TownDefinition townDefinition in SaveGame.Configuration.Towns)
            {
                Add(new GenericTown(SaveGame, townDefinition));
            }
        }
    }

    public override void Loaded()
    {
        base.Loaded();

        // THIS IS USED TO CREATE A TOWN.JSON FILE

        //var serializeOptions = new JsonSerializerOptions
        //{
        //    WriteIndented = true,
        //    Converters = {
        //        new ArrayOfStoreJsonConverter(SaveGame)
        //    }
        //};
        //foreach (Town town in this)
        //{
        //    Assembly assembly = Assembly.GetAssembly(this.GetType());
        //    string json = JsonSerializer.Serialize<Town>(town, serializeOptions);
        //    string path = "D:\\OneDrive\\Programming\\AngbandOS\\AngbandOS.Core\\ConfigurationRepository\\Towns\\";
        //    File.WriteAllText(path, json);

        //}
    }
}