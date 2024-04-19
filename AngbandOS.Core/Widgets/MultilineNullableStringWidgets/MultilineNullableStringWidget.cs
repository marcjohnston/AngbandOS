// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class MultilineNullableStringWidget : MultilineNullableWidget
{
    protected MultilineNullableStringWidget(Game game) : base(game) { }

    public abstract string MultilineNullableStringChangeTrackingName { get; }
    public IMultilineNullableStringChangeTracking MultilineNullableStringChangeTracking { get; private set; }
    public override string[]? Text => MultilineNullableStringChangeTracking.Value;
    public override void Bind()
    {
        base.Bind();
        Property? property = Game.SingletonRepository.Properties.TryGet(MultilineNullableStringChangeTrackingName);
        if (property != null)
        {
            MultilineNullableStringChangeTracking = (IMultilineNullableStringChangeTracking)property;
        }
        else
        {
            Timer? timer = Game.SingletonRepository.Timers.TryGet(MultilineNullableStringChangeTrackingName);
            if (timer != null)
            {
                MultilineNullableStringChangeTracking = (IMultilineNullableStringChangeTracking)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(MultilineNullableStringChangeTrackingName);
                if (function != null)
                {
                    MultilineNullableStringChangeTracking = (IMultilineNullableStringChangeTracking)function;
                }
                else
                {
                    throw new Exception($"The {nameof(MultilineNullableStringChangeTrackingName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        }
    }

    public override void Update()
    {
        // Check to see if the value has changed.
        if (MultilineNullableStringChangeTracking.IsChanged)
        {
            // It has, invalidate the widget.
            Invalidate();
        }

        base.Update();
    }
}
