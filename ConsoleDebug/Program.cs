using StDorModel;
using StDorModelLibrary.DTOClasses;
using StDorModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            StDorModelXML modelXML = new StDorModelXML();
            modelXML.ChangedDormitoriesEvent += ModelXML_ChangedDormitoriesEvent;
            modelXML.ChangedRoomsEvent += ModelXML_ChangedRoomsEvent;

            string fileNameXML = "test.xml";

            Console.WriteLine("Загрузка данных");
            Task task = modelXML.LoadAsync(fileNameXML);
            task.Wait();
            Console.WriteLine("Загрузка окончена");

            Console.WriteLine("Вывод общежитий");
            Task<ImmutableHashSet<DormitoryDTO>> taskD = modelXML.GetDormitoriesAsync();
            taskD.Wait();
            ConsolePrint(taskD.Result);

            Console.WriteLine("Вывод комнат");
            Task<ImmutableHashSet<RoomDTO>> taskR = modelXML.GetRoomsAsync();
            taskR.Wait();
            ConsolePrint(taskR.Result);

            Console.WriteLine("Вывод комнат в порядке общежитий");
            foreach (var dormitory in taskD.Result)
            {
                taskR = modelXML.GetRoomsAsync(dormitory);
                ConsolePrint(Enumerable.Empty<DormitoryDTO>().Append(dormitory).ToImmutableHashSet());
                taskR.Wait();
                ConsolePrint(taskR.Result);
            }

            Console.WriteLine("добавление комнаты");
            modelXML.AddAsync(new RoomDTO(12312321, 1, 888)).Wait();

            Console.WriteLine("Удаление комнаты");
            modelXML.RemoveAsync(new RoomDTO(120, 12, 444)).Wait();

            Console.WriteLine("Вывод комнат");
            taskR = modelXML.GetRoomsAsync();
            taskR.Wait();
            ConsolePrint(taskR.Result);

            while (true)
            {
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }

        private static void ConsolePrint(ImmutableHashSet<RoomDTO> rooms) =>
            Console.WriteLine(string.Join("\r\n", rooms.Select(room => $"{room.ID} {room.DormitoryID} {room.Number}")));

        private static void ConsolePrint(ImmutableHashSet<DormitoryDTO> dormitories) =>
        Console.WriteLine(string.Join("\r\n", dormitories.Select(dormitory => $"{dormitory.ID} {dormitory.Title} {dormitory.Address}")));
        private static void ModelXML_ChangedRoomsEvent(object sender, ActionChanged action, ImmutableHashSet<RoomDTO> rooms)
        {
            Console.WriteLine($"ChangedRoomsEvent: {sender} Action = {action}");
            ConsolePrint(rooms);
        }

        private static void ModelXML_ChangedDormitoriesEvent(object sender, ActionChanged action, ImmutableHashSet<DormitoryDTO> dormitories)
        {
            Console.WriteLine($"ChangedDormitoriesEvent:{sender} Action={action}");
            ConsolePrint(dormitories);
        }
    }
}
