// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interfaces;
using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class StringWidget : TextWidget
{
    protected StringWidget(Game game) : base(game) { }
    public abstract string StringValueName { get; }
    public IStringValue StringValue { get; private set; }

    public override void Bind()
    {
        base.Bind();
        StringValue = Game.SingletonRepository.Get<IStringValue>(StringValueName);
    }

    public override string Text => StringValue.StringValue;
}
