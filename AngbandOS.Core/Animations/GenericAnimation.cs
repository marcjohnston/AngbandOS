// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Animations;

[Serializable]
internal class GenericAnimation : Animation
{
    public GenericAnimation(Game game, AnimationGameConfiguration animationDefinition) : base(game)
    {
        AlternateColor = animationDefinition.AlternateColor;
        Character = animationDefinition.Character;
        Color = animationDefinition.Color;
        Key = animationDefinition.Key;
        Name = animationDefinition.Name;
        Sequence = animationDefinition.Sequence;
    }
    public override string Key { get; }
    public override char Character { get; }
    public override ColorEnum Color { get; }
    public override string Name { get; }
    public override ColorEnum AlternateColor { get; }
    public override string Sequence { get; }
}
