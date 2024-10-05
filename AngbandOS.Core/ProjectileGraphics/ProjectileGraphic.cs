// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal abstract class ProjectileGraphic : IGetKey
{
    protected Game Game;
    protected ProjectileGraphic(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ProjectileGraphicConfiguration projectileGraphicDefinition = new()
        {
            Key = Key,
            Character = Character,
            Color = Color
        };
        return JsonSerializer.Serialize<ProjectileGraphicConfiguration>(projectileGraphicDefinition);
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public virtual void Bind() { }

    /// <summary>
    /// Returns the character to be used for the projectile.
    /// </summary>
    public abstract char Character { get; }

    /// <summary>
    /// Returns the color to be used for the projectile.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;
}
