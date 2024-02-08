// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ConfigurationRepository.Shopkeepers;
using AngbandOS.Core.Interface.Definitions;
using System.Text.Json;

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class ShopkeepersRepository : DictionaryRepository<string, Shopkeeper>
{
    public ShopkeepersRepository(SaveGame saveGame) : base(saveGame) { }

    public override void Load()
    {
        if (SaveGame.Configuration.Shopkeepers == null)
        {
            base.Load();
        }
        else
        {
            foreach (ShopkeeperDefinition shopkeeperDefinition in SaveGame.Configuration.Shopkeepers)
            {
                Add(new GenericShopkeeper(SaveGame, shopkeeperDefinition));
            }
        }
    }
}
