using CommLibrary;
using StDorModel.XMLClases;
using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace StDorModel
{
    public partial class StDorModelXML : IDormitories
    {
        protected override void AddDormitory(DormitoryDTO dormitory)
        {
            DormitoryXML dormitoryXML = CreateDormitoryXML(dormitory); //Создаем новый объект общежития в формате XML
            dormitoryXML.ID = BaseId.NewId(studentDormitories.Dormitories); //Присваиваем новому общежитию уикальный ID
            studentDormitories.Dormitories.Add(dormitoryXML); //Добавляем общежитие в коллекцию общежитий
            Save(); //Записываем файл XML
            dormitoriesXML.Add(dormitoryXML.ID, dormitoryXML); //Добавляем в словарь общежитий (в памяти) новое общежитие (что бы не десериализовать файл)
            DormitoryDTO dormitoryDTO = CreateDormitoryDTO(dormitoryXML); //Создаем общежитие DTO типа в памяти
            dormitoriesDTO.Add(dormitoryDTO); //Добавляем общежитие DTO типа в коллекцию для ВьюМодел
            OnAddDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(dormitoryDTO));
        }

        protected override void ChangeDormitory(DormitoryDTO dormitory)
        {
            if (!dormitoriesXML.TryGetValue(dormitory.ID, out DormitoryXML dormitoryXML))
                throw new StDorModelException($"Не найдено общежитие с ID = {dormitory.ID}", StDorModelExceptionEnum.NoSuchID);
            CopyToDormitoryXML(dormitory, dormitoryXML);
            Save();
            DormitoryDTO dormitoryDTO = CreateDormitoryDTO(dormitoryXML);
            dormitoriesDTO.Remove(dormitoryDTO);
            dormitoriesDTO.Add(dormitoryDTO);
            OnChangedDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(dormitoryDTO));
        }

        protected override ImmutableHashSet<DormitoryDTO> GetDormitories()
            => dormitoriesDTO.ToImmutable();

        protected override void RemoveDormitory(DormitoryDTO dormitory)
        {
            if (!dormitoriesXML.TryGetValue(dormitory.ID, out DormitoryXML dormXML))
                throw new StDorModelException($"Не найдено общежитие с ID={dormitory.ID}", StDorModelExceptionEnum.NoSuchID);

            if (!EqualsDormitory(dormitory, dormXML))
                throw new StDorModelException($"Данные общежития с ID={dormitory.ID} не совпадают.", StDorModelExceptionEnum.DoNotMatch);

            studentDormitories.Dormitories.Remove(dormXML);
            dormitoriesXML.Remove(dormXML.ID);
            Save();
            dormitoriesDTO.Remove(dormitory);
            OnRemoveDormitoriesEvent(ImmutableHashSet<DormitoryDTO>.Empty.Add(dormitory));
        }
    }
}
