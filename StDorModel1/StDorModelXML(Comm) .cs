using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using StDorModel.XMLClases;
using StDorModelLibrary;
using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;

namespace StDorModel
{
    /// <summary>Модель для работы с XML файлом</summary>
    public partial class StDorModelXML : StDorModelBase
    {
        /// <summary>Возвращает тип и значения свойств IsDisposable, IsLoaded, Source</summary>
        /// <returns>string со строковым представлением</returns>
        public override string ToString() => $"{this.GetType().FullName}: " +
            $"IsDisposable: {IsDisposable}, IsLoaded: {IsLoaded}, Source: {(Source == null ? "null" : '"' + Source + '"')}";

        /// <summary>Сериализатор типа StudentDormitoriesXML</summary>
        protected readonly XmlSerializer serializer = new XmlSerializer(typeof(StudentDormitoriesXML));
        /// <summary>Десериализованный экземпляр</summary>
        protected StudentDormitoriesXML studentDormitories;
        /// <summary>Словарь десериализованных общежитий с ключом по ID</summary>
        protected Dictionary<int, DormitoryXML> dormitoriesXML;
        /// <summary>Множество общежитий для ViewModel</summary>
        protected readonly ImmutableHashSet<DormitoryDTO>.Builder dormitoriesDTO = ImmutableHashSet.CreateBuilder<DormitoryDTO>();
        /// <summary>Словарь десериализованных комнат с ключом по ID</summary>
        protected Dictionary<int, RoomXML> roomsXML;
        /// <summary>Множество комнат для ViewModel</summary>
        protected readonly ImmutableHashSet<RoomDTO>.Builder roomsDTO = ImmutableHashSet.CreateBuilder<RoomDTO>();

        /// <summary>Создает экземпляр DTO общежития из XML типа</summary>
        /// <param name="dormitory">Экземпляр XML типа</param>
        /// <returns>DormitoryDTO</returns>
        protected static DormitoryDTO CreateDormitoryDTO(DormitoryXML dormitory) => 
            new DormitoryDTO(dormitory.ID, dormitory.Title, dormitory.Address);
        /// <summary>Создает экземпляр XML общежития из DTO типа</summary>
        /// <param name="dormitory">Экземпляр DTO типа</param>
        /// <returns>DormitoryXML</returns>
        protected static DormitoryXML CreateDormitoryXML(DormitoryDTO dormitory) => 
            new DormitoryXML() { ID = dormitory.ID, Title = dormitory.Title, Address = dormitory.Address };
        /// <summary>Копирует в XML тип данные из DTO типа</summary>
        /// <param name="source">Экземпляр DTO типа</param>
        /// <param name="target">Экземпляр XML типа</param>
        protected static void CopyToDormitoryXML(DormitoryDTO source, DormitoryXML target) =>
            (target.ID, target.Title, target.Address) = (source.ID, source.Title, source.Address);
        /// <summary>Сравнивает все значения двух экземпляров разных типов (DTO и XML)</summary>
        /// <param name="source">Экземпляр DTO типа</param>
        /// <param name="target">Экземпляр XML типа</param>
        /// <returns><see langword="true"/> если все значения равны</returns>
        protected static bool EqualsDormitory(DormitoryDTO source, DormitoryXML target) =>
            target.ID == source.ID && target.Title == source.Title && target.Address == source.Address;


        /// <summary>Создает экземпляр DTO комнаты из XML типа</summary>
        /// <param name="room">Экземпляр XML типа</param>
        /// <returns>DormitoryDTO</returns>
        protected static RoomDTO CreateRoomDTO(RoomXML room) =>
            new RoomDTO(room.ID, room.DormitoryID, room.Number);
        /// <summary>Создает экземпляр XML комнаты из DTO типа</summary>
        /// <param name="room">Экземпляр DTO типа</param>
        /// <returns>RoomXML</returns>
        protected static RoomXML CreateRoomXML(RoomDTO room) =>
            new RoomXML() { ID = room.ID, DormitoryID = room.DormitoryID, Number = room.Number };
        /// <summary>Копирует в XML тип данные из DTO типа</summary>
        /// <param name="source">Экземпляр DTO типа</param>
        /// <param name="target">Экземпляр XML типа</param>
        protected static void CopyToRoomXML(RoomDTO source, RoomXML target) =>
            (target.ID, target.DormitoryID, target.Number) = (source.ID, source.DormitoryID, source.Number);
        /// <summary>Сравнивает все значения двух экземпляров разных типов (DTO и XML)</summary>
        /// <param name="source">Экземпляр DTO типа</param>
        /// <param name="target">Экземпляр XML типа</param>
        /// <returns><see langword="true"/> если все значения равны</returns>
        protected static bool EqualsRoom(RoomDTO source, RoomXML target) =>
            target.ID == source.ID && target.DormitoryID == source.DormitoryID && target.Number == source.Number;

        protected override void Load(string source)
        {
            try
            {
                using (var file = File.OpenRead(source)) 
                    studentDormitories = (StudentDormitoriesXML)serializer.Deserialize(file);

                dormitoriesXML = studentDormitories.Dormitories.ToDictionary(key => key.ID);
                roomsXML = studentDormitories.Rooms.ToDictionary(key => key.ID);

                dormitoriesDTO.Clear();
                dormitoriesDTO.UnionWith(studentDormitories.Dormitories.Select(xml => CreateDormitoryDTO(xml)));
                roomsDTO.Clear();
                roomsDTO.UnionWith(studentDormitories.Rooms.Select(xml => CreateRoomDTO(xml)));

                base.Load(source);
            }
            catch (Exception ex)
            {
                throw new StDorModelException($"Ошибка загрузки XML файла \"{source}\"", StDorModelExceptionEnum.LoadingData, ex);
            }
        }
       /// <summary>Сериализует базу общежитий в файл</summary>
        protected void Save()
        {
            try
            {
                using (var file = File.Create(Source))
                    serializer.Serialize(file, studentDormitories);
            }
            catch (Exception ex)
            {
                throw new StDorModelException($"Ошибка сохранения XML файла \"{Source}\"", StDorModelExceptionEnum.SaveData, ex);
            }
        }
        public override void Dispose()
        {
            base.Dispose();
            studentDormitories = null;
            dormitoriesXML = null;
            roomsXML = null;

            dormitoriesDTO.Clear();
            roomsDTO.Clear();
        }
    }
}
