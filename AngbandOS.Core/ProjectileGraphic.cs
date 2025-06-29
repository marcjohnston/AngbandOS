﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ProjectileGraphic : IGetKey, IToJson
{
    protected Game Game;
    public ProjectileGraphic(Game game, ProjectileGraphicGameConfiguration projectileGraphicGameConfiguration)
    {
        Game = game;
        Key = projectileGraphicGameConfiguration.Key ?? projectileGraphicGameConfiguration.GetType().Name;
        Character = projectileGraphicGameConfiguration.Character;
        Color = projectileGraphicGameConfiguration.Color;
    }


    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ProjectileGraphicGameConfiguration projectileGraphicDefinition = new()
        {
            Key = Key,
            Character = Character,
            Color = Color
        };
        return JsonSerializer.Serialize(projectileGraphicDefinition, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Returns the character to be used for the projectile.
    /// </summary>
    public virtual char Character { get; }

    /// <summary>
    /// Returns the color to be used for the projectile.
    /// </summary>
    public virtual ColorEnum Color { get; } = ColorEnum.White;
}
