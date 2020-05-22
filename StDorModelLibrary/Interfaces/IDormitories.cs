using StDorModelLibrary.DTOClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace StDorModelLibrary.Interfaces
{
    public interface IDormitories : IBaseModelWorker<DormitoryDTO>
    {
        event ChangedDormitoriesHandler ChangedDormitoriesEvent;
    }
}
