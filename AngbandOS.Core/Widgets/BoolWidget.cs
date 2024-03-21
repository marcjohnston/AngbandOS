// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class BoolWidget : Widget
{
    protected BoolWidget(SaveGame saveGame) : base(saveGame) { }
    public abstract string BoolChangeTrackingName { get; }
    public IBoolChangeTracking BoolChangeTracking { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = SaveGame.SingletonRepository.Properties.TryGet(BoolChangeTrackingName);
        if (property != null)
        {
            BoolChangeTracking = (IBoolChangeTracking)property;
        }
        else
        {
            Timer? timer = SaveGame.SingletonRepository.TimedActions.TryGet(BoolChangeTrackingName);
            if (timer != null)
            {
                BoolChangeTracking = (IBoolChangeTracking)timer;
            }
            else
            {
                Function? function = SaveGame.SingletonRepository.Functions.TryGet(BoolChangeTrackingName);
                if (function != null)
                {
                    BoolChangeTracking = (IBoolChangeTracking)function;
                }
                else
                {
                    throw new Exception($"The {nameof(BoolChangeTrackingName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        }
    }

    public virtual string TrueValue => "Yes";
    public virtual string FalseValue => "No";

    public override void Update()
    {
        // Check to see if the value has changed.
        if (BoolChangeTracking.IsChanged)
        {
            // It has, invalidate the widget.
            base.Invalidate();
        }

        // Update the widget.
        base.Update();
    }

    public override string Text => BoolChangeTracking.Value ? TrueValue : FalseValue;
}
