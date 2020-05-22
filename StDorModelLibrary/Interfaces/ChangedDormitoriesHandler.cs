using StDorModelLibrary.DTOClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StDorModelLibrary.Interfaces
{
    /// <summary>Делегат события изменения общежитий</summary>
    /// <param name="sender">Объект где возникло событие</param>
    /// <param name="action">Какое было изменение</param>
    /// <param name="dormitories">Список измененных общежитий</param>
    public delegate void ChangedDormitoriesHandler(object sender, ActionChanged action, HashSet<DormitoryDTO> dormitories);
}
