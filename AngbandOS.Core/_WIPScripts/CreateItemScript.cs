// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]

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
        Item qPtr = itemFactory.GenerateItem();
        qPtr.StackCount = Game.CommandArgument == 0 ? 1 : Game.CommandArgument;
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

        qPtr.EnchantItem(Game.Difficulty, allowFixedArtifact, good, great, true);
        Game.DropNear(qPtr, null, Game.MapY.IntValue, Game.MapX.IntValue);
        Game.MsgPrint("Allocated.");
        return;
    }

    private ItemFactory? WizardSelectItemFactory()
    {
        char[] _head = { 'a', 'A', '0' };
        int num;
        int col, row;
        char ch;
        int[] choice = new int[60];
        Game.Screen.Clear();
        for (num = 0; num < 60 && num < Game.SingletonRepository.Count<ItemClass>(); num++)
        {
            ItemClass itemClass = Game.SingletonRepository.Get<ItemClass>(num);
            row = 2 + (num % 20);
            col = 30 * (num / 20);
            ch = (char)(_head[num / 20] + (char)(num % 20));
            Game.Screen.PrintLine($"[{ch}] {Game.Pluralize(itemClass.Name)}", row, col);
        }
        int maxNum = num;
        if (!Game.GetCom("Get what type of object? ", out ch))
        {
            return null;
        }
        num = -1;
        if (ch >= _head[0] && ch < _head[0] + 20)
        {
            num = ch - _head[0];
        }
        if (ch >= _head[1] && ch < _head[1] + 20)
        {
            num = ch - _head[1] + 20;
        }
        if (ch >= _head[2] && ch < _head[2] + 10)
        {
            num = ch - _head[2] + 40;
        }
        if (num < 0 || num >= maxNum)
        {
            return null;
        }
        ItemClass selectedItemClass = Game.SingletonRepository.Get<ItemClass>(num);
        string tvalDesc = Game.Pluralize(selectedItemClass.Name);
        Game.Screen.Clear();
        const int maxLetters = 26;
        const int maxNumbers = 10;
        const int maxCount = maxLetters * 2 + maxNumbers; // 26 lower case, 26 uppercase, 10 numbers
        ItemFactory[] itemFactories = Game.SingletonRepository.Get<ItemFactory>().Where(_itemFactory => _itemFactory.ItemClass == selectedItemClass).OrderBy(_itemFactory => _itemFactory.BookIndex).ToArray();
        for (num = 0; num < maxCount && num < itemFactories.Length; num++)
        {
            ItemFactory kPtr = itemFactories[num];
            row = 2 + (num % maxLetters);
            col = 30 * (num / maxLetters);
            ch = (char)(_head[num / maxLetters] + (char)(num % maxLetters));
            string itemName = kPtr.Name;

            Game.Screen.PrintLine($"[{ch}] {itemName}", row, col);
            choice[num] = num;
        }
        maxNum = num;
        if (!Game.GetCom($"What Kind of {tvalDesc}? ", out ch))
        {
            return null;
        }
        num = -1;
        if (ch >= _head[0] && ch < _head[0] + maxLetters)
        {
            num = ch - _head[0];
        }
        if (ch >= _head[1] && ch < _head[1] + maxLetters)
        {
            num = ch - _head[1] + maxLetters;
        }
        if (ch >= _head[2] && ch < _head[2] + maxNumbers)
        {
            num = ch - _head[2] + maxLetters * 2;
        }
        if (num < 0 || num >= maxNum)
        {
            return null;
        }
        return itemFactories[num];
    }
}
