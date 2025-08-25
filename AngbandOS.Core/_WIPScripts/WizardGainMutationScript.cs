// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WizardGainMutationScript : Script, IScript
{
    private WizardGainMutationScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        ScreenBuffer savedScreen = Game.Screen.Clone();
        char[] _head = { 'a', 'A', '0' };
        int num;
        int col, row;
        char ch;
        int[] choice = new int[62];
        Game.Screen.Clear();
        for (num = 0; num < 62 && num < Game.MutationsNotPossessed.Count; num++)
        {
            Mutation mutation = Game.MutationsNotPossessed[num];
            row = 2 + (num % 26);
            col = 30 * (num / 26);
            ch = (char)(_head[num / 26] + (char)(num % 26));
            string title = mutation.Key.Replace("Mutation", "");
            Game.Screen.PrintLine($"[{ch}] {title}", row, col);
        }
        int maxNum = num;
        if (!Game.GetCom("Select mutation? ", out ch))
        {
            Game.Screen.Restore(savedScreen);
            Game.FullScreenOverlay = false;
            Game.SetBackground(BackgroundImageEnum.Overhead);
            return;
        }
        Game.Screen.Restore(savedScreen);
        Game.FullScreenOverlay = false;
        Game.SetBackground(BackgroundImageEnum.Overhead);
        num = -1;
        if (ch >= _head[0] && ch < _head[0] + 26)
        {
            num = ch - _head[0];
        }
        if (ch >= _head[1] && ch < _head[1] + 26)
        {
            num = ch - _head[1] + 26;
        }
        if (ch >= _head[2] && ch < _head[2] + 10)
        {
            num = ch - _head[2] + 52;
        }
        if (num < 0 || num >= Game.MutationsNotPossessed.Count)
        {
            return;
        }
        Mutation selectedMutation = Game.MutationsNotPossessed[num];
        Game.GainMutation(selectedMutation);
    }
}

