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
    public abstract string IntPropertyFormatterName { get; }
    public IntFormatter IntPropertyFormatter { get; private set; }
    public abstract ColorEnum Color { get; }
    public override void Bind()
    {
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

        IntPropertyFormatter = (IntFormatter)SaveGame.SingletonRepository.PropertyFormatters.Get(IntPropertyFormatterName);
    }

    /// <summary>
    /// Returns true, if the base <see cref="IntChangeTrackable"/> is flagged as changed.
    /// </summary>
    protected override bool QueryRedraw => IntChangeTrackable.IsChanged;

    /// <summary>
    /// Formats the integer value into a string using the IntPropertyFormatter and prints the value at the designated screen position.
    /// </summary>
    protected override void Paint()
    {
        string value = IntPropertyFormatter.Format(IntChangeTrackable.Value, Width);
        SaveGame.Screen.Print(Color, value, Y, X);
    }
}
