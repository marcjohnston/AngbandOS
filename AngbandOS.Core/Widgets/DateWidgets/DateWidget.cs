// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class DateWidget : TextWidget
{
    protected DateWidget(Game game) : base(game) { }
    public abstract string DateValueName { get; }
    public IDateAndTimeValue DateValue { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = Game.SingletonRepository.Properties.TryGet(DateValueName);
        if (property != null)
        {
            DateValue = (IDateAndTimeValue)property;
        }
        else
        {
            Timer? timer= Game.SingletonRepository.Timers.TryGet(DateValueName);
            if (timer != null)
            {
                DateValue = (IDateAndTimeValue)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(DateValueName);
                if (function != null)
                {
                    DateValue = (IDateAndTimeValue)function;
                }
                else
                {
                    throw new Exception($"The {nameof(DateValueName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        } 
    }

    public override string Text => DateValue.DateAndTimeValue.ToString("MMM d");
}
