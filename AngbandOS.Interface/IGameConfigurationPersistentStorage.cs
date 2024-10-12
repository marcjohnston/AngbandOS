namespace AngbandOS.Core.Interface;

public interface IGameConfigurationPersistentStorage
{
    bool PersistGameConfiguration(GameConfiguration gameConfiguration, string configurationName, bool overwrite);
    GameConfiguration LoadConfiguration();
}
