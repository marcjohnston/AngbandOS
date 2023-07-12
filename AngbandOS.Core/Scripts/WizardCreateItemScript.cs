// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]

    /// <summary>
    /// Give us a rumour, if possible one that we've not heard before
    /// </summary>
    internal class WizardCreateItemScript : Script
    {
        private WizardCreateItemScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
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
                return false;
            }
            ItemFactory itemClass = SaveGame.SingletonRepository.ItemFactories[kIdx];
            Item qPtr = itemClass.CreateItem();
            qPtr.ApplyMagic(SaveGame.Difficulty, false, false, false, null);
            SaveGame.Level.DropNear(qPtr, -1, SaveGame.Player.MapY, SaveGame.Player.MapX);
            SaveGame.MsgPrint("Allocated.");
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
            for (num = 0; num < 60 && TvalDescriptionPair.Tvals[num].Tval != 0; num++)
            {
                row = 2 + (num % 20);
                col = 30 * (num / 20);
                ch = (char)(_head[num / 20] + (char)(num % 20));
                SaveGame.Screen.PrintLine($"[{ch}] {TvalDescriptionPair.Tvals[num].Desc}", row, col);
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
            ItemTypeEnum tval = TvalDescriptionPair.Tvals[num].Tval;
            string tvalDesc = TvalDescriptionPair.Tvals[num].Desc;
            SaveGame.Screen.Clear();
            const int maxLetters = 26;
            const int maxNumbers = 10;
            const int maxCount = maxLetters * 2 + maxNumbers; // 26 lower case, 26 uppercase, 10 numbers
            for (num = 0, i = 1; num < maxCount && i < SaveGame.SingletonRepository.ItemFactories.Count; i++)
            {
                ItemFactory kPtr = SaveGame.SingletonRepository.ItemFactories[i];
                if (kPtr.CategoryEnum == tval)
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
}
