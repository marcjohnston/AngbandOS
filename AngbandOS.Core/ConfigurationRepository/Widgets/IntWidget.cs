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
    public abstract string IntChangeTrackingName { get; }
    public IIntChangeTracking IntChangeTracking { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = SaveGame.SingletonRepository.Properties.TryGet(IntChangeTrackingName);
        if (property != null)
        {
            IntChangeTracking = (IIntChangeTracking)property;
        }
        else
        {
            Timer? timer= SaveGame.SingletonRepository.TimedActions.TryGet(IntChangeTrackingName);
            if (timer != null)
            {
                IntChangeTracking = (IIntChangeTracking)timer;
            }
            else
            {
                Function? function = SaveGame.SingletonRepository.Functions.TryGet(IntChangeTrackingName);
                if (function != null)
                {
                    IntChangeTracking = (IIntChangeTracking)function;
                }
                else
                {
                    throw new Exception($"The {nameof(IntChangeTrackingName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        } 
    }

    public override void Update()
    {
        // Check to see if the value has changed.
        if (IntChangeTracking.IsChanged)
        {
            // It has, invalidate the widget.
            base.Invalidate();
        }

        // Update the widget.
        base.Update();
    }

    public override string Text => IntChangeTracking.Value.ToString();
}
