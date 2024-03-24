// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class StringWidget : TextWidget
{
    protected StringWidget(Game game) : base(game) { }
    public abstract string StringChangeTrackingName { get; }
    public IStringChangeTracking StringChangeTracking { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = Game.SingletonRepository.Properties.TryGet(StringChangeTrackingName);
        if (property != null)
        {
            StringChangeTracking = (IStringChangeTracking)property;
        }
        else
        {
            Timer? timer = Game.SingletonRepository.TimedActions.TryGet(StringChangeTrackingName);
            if (timer != null)
            {
                StringChangeTracking = (IStringChangeTracking)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(StringChangeTrackingName);
                if (function != null)
                {
                    StringChangeTracking = (IStringChangeTracking)function;
                }
                else
                {
                    throw new Exception($"The {nameof(StringChangeTrackingName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        }
    }

    public override void Update()
    {
        // Check to see if the value has changed.
        if (StringChangeTracking.IsChanged)
        {
            // It has, invalidate the widget.
            base.Invalidate();
        }

        // Update the widget.
        base.Update();
    }

    public override string Text => StringChangeTracking.Value;
}
