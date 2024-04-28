// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
        BoolValue = Game.SingletonRepository.Get<IBoolValue>(BoolValueName);
    }

    public abstract string TrueValue { get; }
    public abstract string FalseValue { get; }

    public override string Text => BoolValue.BoolValue ? TrueValue : FalseValue;
}
