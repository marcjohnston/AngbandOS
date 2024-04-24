// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class TimeWidget : TextWidget
{
    protected TimeWidget(Game game) : base(game) { }
    public abstract string DateAndTimeValueName { get; }
    public IDateAndTimeValue DateAndTimeValue { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = Game.SingletonRepository.Properties.TryGet(DateAndTimeValueName);
        if (property != null)
        {
            DateAndTimeValue = (IDateAndTimeValue)property;
        }
        else
        {
            Timer? timer= Game.SingletonRepository.Timers.TryGet(DateAndTimeValueName);
            if (timer != null)
            {
                DateAndTimeValue = (IDateAndTimeValue)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(DateAndTimeValueName);
                if (function != null)
                {
                    DateAndTimeValue = (IDateAndTimeValue)function;
                }
                else
                {
                    throw new Exception($"The {nameof(DateAndTimeValueName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        } 
    }

    public override string Text => DateAndTimeValue.DateAndTimeValue.ToString("h:mmtt");
}
