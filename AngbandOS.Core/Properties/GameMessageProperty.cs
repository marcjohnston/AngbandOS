// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Properties;

[Serializable]
internal class GameMessageProperty : Property
{
    protected GameMessageProperty(Game game) : base(game) { }
    private string _value = "";
    public Queue<string?> MessageQueue = new Queue<string?>();
    public string StringValue
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }


    public override string ToString()
    {
        return _value;
    }

    public void Add(params string?[] messages)
    {
        // There is no ability to enqueue multiple items.
        foreach (string? message in messages)
        {
            MessageQueue.Enqueue(message);
            SetChangedFlag();
        }
    }
}
