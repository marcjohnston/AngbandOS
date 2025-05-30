﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal abstract class TimeWidget : TextWidget
{
    protected TimeWidget(Game game) : base(game) { }
    public abstract string DateAndTimeValueName { get; }
    public IDateAndTimeValue DateAndTimeValue { get; private set; }

    public override void Bind()
    {
        base.Bind();
        DateAndTimeValue = Game.SingletonRepository.Get<IDateAndTimeValue>(DateAndTimeValueName);
    }

    public override string Text => DateAndTimeValue.DateAndTimeValue.ToString("h:mmtt");
    public override string ToJson()
    {
        TimeWidgetGameConfiguration timeWidgetGameConfiguration = new TimeWidgetGameConfiguration()
        {
            Key = Key,
            DateAndTimeValueName = DateAndTimeValueName,
            Color = Color,
            X = X ,            Y = Y ,            Width = Width,
            JustificationName = JustificationName,
            ChangeTrackerNames = ChangeTrackerNames,
        };
        return JsonSerializer.Serialize(timeWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }
}
