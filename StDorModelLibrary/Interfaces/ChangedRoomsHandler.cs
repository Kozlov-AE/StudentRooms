using StDorModelLibrary.DTOClasses;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Делегат события изменения комнат</summary>
    /// <param name="sender">Объект где возникло событие</param>
    /// <param name="action">Какое было изменение</param>
    /// <param name="dormitories">Список измененных комнат</param>
    public delegate void ChangedRoomsHandler(object sender, ActionChanged action, ImmutableHashSet<RoomDTO> rooms);
}
