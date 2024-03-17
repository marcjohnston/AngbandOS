// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Diagnostics;
using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class DynamicWidget : Widget
{
    protected DynamicWidget(SaveGame saveGame) : base(saveGame) { }
    public abstract string IntChangeTrackableName { get; }
    public IIntChangeTracking IntChangeTrackable { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = SaveGame.SingletonRepository.Properties.TryGet(IntChangeTrackableName);
        if (property != null)
        {
            IntChangeTrackable = (IIntChangeTracking)property;
        }
        else
        {
            Timer? timer= SaveGame.SingletonRepository.TimedActions.TryGet(IntChangeTrackableName);
            if (timer != null)
            {
                IntChangeTrackable = (IIntChangeTracking)timer;
            }
            else
            {
                Function? function = SaveGame.SingletonRepository.Functions.TryGet(IntChangeTrackableName);
                if (function != null)
                {
                    IntChangeTrackable = (IIntChangeTracking)function;
                }
                else
                {
                    throw new Exception($"The {nameof(IntChangeTrackableName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
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

            // The widget will be painted.  Clear the change tracking flag.
            IntChangeTrackable.ClearChangedFlag();
        }

        // Update the widget.
        base.Update();
    }

    public override string Text => IntChangeTrackable.Value.ToString();
}
