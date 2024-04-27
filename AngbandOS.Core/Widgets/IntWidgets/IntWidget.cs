// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class IntWidget : TextWidget
{
    protected IntWidget(Game game) : base(game) { }
    public abstract string IntValueName { get; }
    public IIntValue IntValue { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// This override is sealed because the data source for the Text property is being rerouted from a property with a non-string property.
    /// </remarks>
    public sealed override string Text => IntValue.IntValue.ToString();

    public override void Bind()
    {
        base.Bind();
        IntValue = Game.SingletonRepository.Get<IIntValue>(IntValueName);
    }
}
