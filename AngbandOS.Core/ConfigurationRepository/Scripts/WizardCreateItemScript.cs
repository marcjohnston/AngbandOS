// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]

/// <summary>
/// Give us a rumour, if possible one that we've not heard before
/// </summary>
internal class WizardCreateItemScript : Script, IScript
{
    private WizardCreateItemScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the create item script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.FullScreenOverlay = true;
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        SaveGame.SetBackground(BackgroundImageEnum.Normal);
        int kIdx = WizCreateItemtype();
        SaveGame.Screen.Restore(savedScreen);
        SaveGame.FullScreenOverlay = false;
        SaveGame.SetBackground(BackgroundImageEnum.Overhead);
        if (kIdx == 0)
        {
            return;
        }
        ItemFactory itemFactory = SaveGame.SingletonRepository.ItemFactories[kIdx];
        Item qPtr = itemFactory.CreateItem();

        if (!GetBool($"Ok Item (0=False, 1=True)? ", out bool ok))
        {
            return;
        }
        if (!GetBool($"Good Item (0=False, 1=True)? ", out bool good))
        {
            return;
        }
        if (!GetBool($"Great Item (0=False, 1=True)? ", out bool great))
        {
            return;
        }

        qPtr.ApplyMagic(SaveGame.Difficulty, ok, good, great, null);
        SaveGame.DropNear(qPtr, -1, SaveGame.MapY, SaveGame.MapX);
        SaveGame.MsgPrint("Allocated.");
        return;
    }

    private bool GetBool(string prompt, out bool value)
    {
        value = false;
        if (!SaveGame.GetCom(prompt, out char text))
        {
            return false;
        }
        if (text == '0')
        {
            value = false;
            return true;
        }
        if (text == '1')
        {
            value = true;
            return true;
        }
        return false;
    }

    private int WizCreateItemtype()
    {
        char[] _head = { 'a', 'A', '0' };
        int i, num;
        int col, row;
        char ch;
        int[] choice = new int[60];
        SaveGame.Screen.Clear();
        for (num = 0; num < 60 && num < SaveGame.SingletonRepository.ItemClasses.Count; num++)
        {
            ItemClass itemClass = SaveGame.SingletonRepository.ItemClasses[num];
            row = 2 + (num % 20);
            col = 30 * (num / 20);
            ch = (char)(_head[num / 20] + (char)(num % 20));
            SaveGame.Screen.PrintLine($"[{ch}] {itemClass.Description}", row, col);
        }
        int maxNum = num;
        if (!SaveGame.GetCom("Get what type of object? ", out ch))
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
        ItemClass selectedItemClass = SaveGame.SingletonRepository.ItemClasses[num];
        string tvalDesc = selectedItemClass.Description;
        SaveGame.Screen.Clear();
        const int maxLetters = 26;
        const int maxNumbers = 10;
        const int maxCount = maxLetters * 2 + maxNumbers; // 26 lower case, 26 uppercase, 10 numbers
        for (num = 0, i = 1; num < maxCount && i < SaveGame.SingletonRepository.ItemFactories.Count; i++)
        {
            ItemFactory kPtr = SaveGame.SingletonRepository.ItemFactories[i];
            if (kPtr.ItemClass == selectedItemClass)
            {
                row = 2 + (num % maxLetters);
                col = 30 * (num / maxLetters);
                ch = (char)(_head[num / maxLetters] + (char)(num % maxLetters));
                string itemName = kPtr.Name.Trim().Replace("$", "").Replace("~", "");

                SaveGame.Screen.PrintLine($"[{ch}] {itemName}", row, col);
                choice[num++] = i;
            }
        }
        maxNum = num;
        if (!SaveGame.GetCom($"What Kind of {tvalDesc}? ", out ch))
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
