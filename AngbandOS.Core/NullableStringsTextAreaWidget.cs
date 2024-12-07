// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class NullableStringsTextAreaWidget : NullableTextAreaWidget
{
    protected NullableStringsTextAreaWidget(Game game) : base(game) { }

    public abstract string NullableTextAreaValueName { get; }
    public INullableStringsValue NullableTextAreaValue { get; private set; }
    public override string[]? NullableText => NullableTextAreaValue.NullableStringsValue;
    public override void Bind()
    {
        base.Bind();
        NullableTextAreaValue = Game.SingletonRepository.Get<INullableStringsValue>(NullableTextAreaValueName);
    }
}
