// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class BoolWidget : TextWidget
{
    protected BoolWidget(Game game) : base(game) { }
    public abstract string BoolValueName { get; }
    public IBoolValue BoolValue { get; private set; }

    public override void Bind()
    {
        base.Bind();
        Property? property = Game.SingletonRepository.Properties.TryGet(BoolValueName);
        if (property != null)
        {
            BoolValue = (IBoolValue)property;
        }
        else
        {
            Timer? timer = Game.SingletonRepository.Timers.TryGet(BoolValueName);
            if (timer != null)
            {
                BoolValue = (IBoolValue)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(BoolValueName);
                if (function != null)
                {
                    BoolValue = (IBoolValue)function;
                }
                else
                {
                    throw new Exception($"The {nameof(BoolValueName)} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        }
    }

    public abstract string TrueValue { get; }
    public abstract string FalseValue { get; }

    public override string Text => BoolValue.BoolValue ? TrueValue : FalseValue;
}
