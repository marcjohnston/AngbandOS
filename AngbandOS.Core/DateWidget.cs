// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
using System.Security.Cryptography.X509Certificates;
namespace AngbandOS.Core;

[Serializable]
internal abstract class DateWidget : TextWidget
{
    protected DateWidget(Game game) : base(game) { }
    public abstract string DateValueName { get; }
    public IDateAndTimeValue DateValue { get; private set; }

    public override void Bind()
    {
        base.Bind();
        DateValue = Game.SingletonRepository.Get<IDateAndTimeValue>(DateValueName);
    }

    public override string Text => DateValue.DateAndTimeValue.ToString("MMM d");
    public override string ToJson()
    {
        DateWidgetGameConfiguration dateWidgetGameConfiguration = new DateWidgetGameConfiguration()
        {
            Key = Key,
            DateValueName = DateValueName,
            Color = Color,
            X = X,
            Y = Y,
            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(dateWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }
}
