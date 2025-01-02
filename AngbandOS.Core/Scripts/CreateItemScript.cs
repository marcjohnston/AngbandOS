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
    /// Executes the create item script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.SetBackground(BackgroundImageEnum.Normal);
        int kIdx = WizCreateItemtype();
        Game.Screen.Restore(savedScreen);
        Game.FullScreenOverlay = false;
        Game.SetBackground(BackgroundImageEnum.Overhead);
        if (kIdx == 0)
        {
            return;
        }
        ItemFactory itemFactory = Game.SingletonRepository.Get<ItemFactory>(kIdx);
        Item qPtr = itemFactory.GenerateItem();
        qPtr.StackCount = Game.CommandArgument == 0 ? 1 : Game.CommandArgument;
        if (!Game.GetBool($"Allow Fixed Artifact (0=False, 1=True)? ", out bool ok))
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

        qPtr.EnchantItem(Game.Difficulty, ok, good, great, true);
        Game.DropNear(qPtr, -1, Game.MapY.IntValue, Game.MapX.IntValue);
        Game.MsgPrint("Allocated.");
        return;
    }

    private int WizCreateItemtype()
    {
        char[] _head = { 'a', 'A', '0' };
        int i, num;
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
            return 0;
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
            return 0;
        }
        ItemClass selectedItemClass = Game.SingletonRepository.Get<ItemClass>(num);
        string tvalDesc = Game.Pluralize(selectedItemClass.Name);
        Game.Screen.Clear();
        const int maxLetters = 26;
        const int maxNumbers = 10;
        const int maxCount = maxLetters * 2 + maxNumbers; // 26 lower case, 26 uppercase, 10 numbers
        for (num = 0, i = 1; num < maxCount && i < Game.SingletonRepository.Count<ItemFactory>(); i++)
        {
            ItemFactory kPtr = Game.SingletonRepository.Get<ItemFactory>(i);
            if (kPtr.ItemClass == selectedItemClass)
            {
                row = 2 + (num % maxLetters);
                col = 30 * (num / maxLetters);
                ch = (char)(_head[num / maxLetters] + (char)(num % maxLetters));
                string itemName = kPtr.Name;

                Game.Screen.PrintLine($"[{ch}] {itemName}", row, col);
                choice[num++] = i;
            }
        }
        maxNum = num;
        if (!Game.GetCom($"What Kind of {tvalDesc}? ", out ch))
        {
            return 0;
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
            return 0;
        }
        return choice[num];
    }
}
