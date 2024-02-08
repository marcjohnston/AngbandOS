// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ConfigurationRepository.Shopkeepers;
using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.RepositoryCollections;

[Serializable]
internal class HelpGroupsRepositoryCollection : DictionaryRepositoryCollection<string, HelpGroup>
{
    public HelpGroupsRepositoryCollection(SaveGame saveGame) : base(saveGame) { }
    public override void Load()
    {
        if (SaveGame.Configuration.HelpGroups == null)
        {
            base.Load();
        }
        else
        {
            foreach (HelpGroupDefinition helpGroupDefinition in SaveGame.Configuration.HelpGroups)
            {
                Add(new GenericHelpGroup(SaveGame, helpGroupDefinition));
            }
        }
    }
}