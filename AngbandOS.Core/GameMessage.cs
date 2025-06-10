// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class GameMessage : IGameMessage
{
    public int Count { get; set; }
    public string Text { get; }
    public GameMessage(string text)
    {
        Text = text;
        Count = 1;
    }
}
