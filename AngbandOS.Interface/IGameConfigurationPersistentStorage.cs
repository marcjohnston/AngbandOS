namespace AngbandOS.Core.Interface;

public interface IGameConfigurationPersistentStorage
{
    bool PersistGameConfiguration(GameConfiguration gameConfiguration, string? username, string configurationName, bool overwrite);
    GameConfiguration LoadConfiguration(string? username, string configurationName);
}
