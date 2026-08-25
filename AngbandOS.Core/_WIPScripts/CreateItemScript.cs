// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Xml.Linq;

namespace AngbandOS.Core.Scripts;


internal class CreateItemScript : Script, IScript, ICastSpellScript
{
    private CreateItemScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the create item script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.SetBackground(BackgroundImageEnum.Normal);
        ItemFactory? itemFactory = WizardSelectItemFactory();
        Game.Screen.Restore(savedScreen);
        Game.FullScreenOverlay = false;
        Game.SetBackground(BackgroundImageEnum.Overhead);
        if (itemFactory == null)
        {
            return;
        }
        Item qPtr = new Item(Game, itemFactory);
        if (!Game.GetBool($"Random Artifact (0=False, 1=True)? ", out bool randomArtifact))
        {
            return;
        }
        if (randomArtifact)
        {
            qPtr.CreateRandomArtifact(true);
        }
        else
        {
            if (!Game.GetBool($"Allow Fixed Artifact (0=False, 1=True)? ", out bool allowFixedArtifact))
            {
                return;
            }
            if (!Game.GetBool($"Good Item (0=False, 1=True)? ", out bool good))
            {
                return;
            }
            if (!Game.GetBool($"Great Item (0=False, 1=True)? ", out bool great))
            {
                return;
            }
            if (!Game.GetBool($"Store Stock (0=False, 1=True)? ", out bool storeStock))
            {
                return;
            }

            int initialStackCount = Game.CommandArgument == 0 ? 1 : Game.CommandArgument;
            if (!Game.GetInt($"Stack count? ", initialStackCount, out int? stackCount) || !stackCount.HasValue)
            {
                return;
            }

            qPtr.EnchantItem(Game.Difficulty, allowFixedArtifact, good, great, storeStock);
            qPtr.StackCount = stackCount.Value;
            Game.CommandArgument = 0;
        }
        Game.DropNear(qPtr, null, Game.MapY.IntValue, Game.MapX.IntValue);
        Game.MsgPrint("Allocated.");
        return;
    }

    private ItemFactory? WizardSelectItemFactory()
    {
        ItemFactory[] itemFactories = Game.SingletonRepository.Get<ItemFactory>().OrderBy(_itemFactory => _itemFactory.Name).ToArray();
        ConsoleTableWithRowHighlighting<ItemFactory> table = new ConsoleTableWithRowHighlighting<ItemFactory>(itemFactories, new (string, Func<ItemFactory, string>)[]
        {
            ("Name", _itemFactory => _itemFactory.Name),
            ("Type", _itemFactory => _itemFactory.Symbol.Name.ToString()),
            ("Character", _itemFactory => _itemFactory.Symbol.Character.ToString())
        });
        ItemFactory? selectedItemFactory = Game.SelectFromConsoleTable<ItemFactory>(table, "Select Item:");
        return selectedItemFactory;
    }
}
