// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class IntWidget : Widget
{
    protected IntWidget(SaveGame saveGame) : base(saveGame) { }
    public abstract string IntChangeTrackableName { get; }
    public IIntChangeTrackable IntChangeTrackable { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = SaveGame.SingletonRepository.Properties.TryGet(IntChangeTrackableName);
        if (property != null)
        {
            IntChangeTrackable = (IIntChangeTrackable)property;
        }
        else
        {
            Timer? timer= SaveGame.SingletonRepository.TimedActions.TryGet(IntChangeTrackableName);
            if (timer != null)
            {
                IntChangeTrackable = (IIntChangeTrackable)timer;
            }
            else
            {
                throw new Exception($"The {nameof(IntChangeTrackableName)} property does not specify a valid {nameof(Property)} or {nameof(Timer)}.");
            }
        } 
    }

    protected virtual bool ValueChanged => IntChangeTrackable.IsChanged;

    public override void Update()
    {
        // Check to see if the value has changed.
        if (ValueChanged)
        {
            // It has, invalidate the widget.
            base.Invalidate();
        }

        // Update the widget.
        base.Update();
    }

    protected override void Paint()
    {
        // Paint the widget.
        base.Paint();

        // The widget has been painted.  Clear the change tracking flag.
        IntChangeTrackable.Clear();
    }

    public override string Text => IntChangeTrackable.Value.ToString();
}
