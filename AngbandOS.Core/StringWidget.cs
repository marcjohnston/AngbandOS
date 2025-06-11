// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

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

    public override string ToJson()
    {
        StringWidgetGameConfiguration stringWidgetGameConfiguration = new StringWidgetGameConfiguration()
        {
            Key = Key,
            StringValueName = StringValueName,
            Color = Color, 
            X = X,
            Y = Y,
            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(stringWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }
}
