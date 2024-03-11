// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class TextWidget : Widget
{
    protected TextWidget(SaveGame saveGame) : base(saveGame) { }
    public abstract string Text { get; }
    public abstract ColorEnum Color { get; }
    public override int Width => Text.Length;
    public override int Height => 1;
    protected override void OnDraw()
    {
        if (Invalid)
        {
            SaveGame.Screen.Print(Color, Text, Y, X);
        }
    }
}
