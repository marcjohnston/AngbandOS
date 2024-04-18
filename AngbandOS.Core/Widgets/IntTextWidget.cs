// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class IntTextWidget : TextWidget
{
    protected IntTextWidget(Game game) : base(game) { }
    public abstract string IntValuePropertyName { get; }
    public IIntValue IntValueProperty { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// This override is sealed because the data source for the Text property is being rerouted from a property with a non-string property.
    /// </remarks>
    public sealed override string Text => IntValueProperty.IntValue.ToString();

    public override void Bind()
    {
        base.Bind();
        Property? property = Game.SingletonRepository.Properties.TryGet(IntValuePropertyName);
        if (property != null)
        {
            IntValueProperty = (IIntValue)property;
        }
        else
        {
            Timer? timer = Game.SingletonRepository.Timers.TryGet(IntValuePropertyName);
            if (timer != null)
            {
                IntValueProperty = (IIntValue)timer;
            }
            else
            {
                Function? function = Game.SingletonRepository.Functions.TryGet(IntValuePropertyName);
                if (function != null)
                {
                    IntValueProperty = (IIntValue)function;
                }
                else
                {
                    throw new Exception($"The {IntValuePropertyName} property does not specify a valid {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                }
            }
        }
    }
}
