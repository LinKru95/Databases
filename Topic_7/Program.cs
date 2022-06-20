using System;
using System.Collections.Generic;
using System.Text.Json;
using MongoDB.Driver;
using Newtonsoft.Json;
using MongoDB.Bson;

namespace Topic_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot()
            {
                Arms = new List<Arm>
                {
                    new Arm{
                        Material = "Steel",
                        NumberOfJoints = 2,
                        NumberOfFingers = 4
                    },
                    new Arm{
                        Material = "Copper",
                        NumberOfJoints = 3,
                        NumberOfFingers = 3
                    }
                },
                Legs = new List<Leg>
                {
                    new Leg
                    {
                        Material = "Bronze",
                        NumberOfJoints = 1,
                        SizeOfFoot = 20
                    },
                    new Leg
                    {
                        Material = "Carbon",
                        NumberOfJoints = 2,
                        SizeOfFoot = 20
                    }
                },
                Torso = new Torso
                {
                    ChestMeasurements = 90,
                    WaistMeasurements = 60
                },
                Head = Head.Square
            };

            var robot2 = new Robot()
            {
                Arms = new List<Arm>
                {
                    new Arm{
                        Material = "Steel",
                        NumberOfJoints = 2,
                        NumberOfFingers = 4
                    },
                    new Arm{
                        Material = "Copper",
                        NumberOfJoints = 3,
                        NumberOfFingers = 3
                    }
                },
                Legs = new List<Leg>
                {
                    new Leg
                    {
                        Material = "Bronze",
                        NumberOfJoints = 1,
                        SizeOfFoot = 20
                    },
                    new Leg
                    {
                        Material = "Carbon",
                        NumberOfJoints = 2,
                        SizeOfFoot = 20
                    }
                },
                Torso = new Torso
                {
                    ChestMeasurements = 90,
                    WaistMeasurements = 60
                },
                Head = Head.Square
            };

            var robot3 = new Robot()
            {
                Arms = new List<Arm>
                {
                    new Arm{
                        Material = "Steel",
                        NumberOfJoints = 2,
                        NumberOfFingers = 4
                    },
                    new Arm{
                        Material = "Copper",
                        NumberOfJoints = 3,
                        NumberOfFingers = 3
                    }
                },
                Legs = new List<Leg>
                {
                    new Leg
                    {
                        Material = "Bronze",
                        NumberOfJoints = 1,
                        SizeOfFoot = 20
                    },
                    new Leg
                    {
                        Material = "Carbon",
                        NumberOfJoints = 2,
                        SizeOfFoot = 20
                    }
                },
                Torso = new Torso
                {
                    ChestMeasurements = 90,
                    WaistMeasurements = 60
                },
                Head = Head.Square
            };

            // Creating JSON

            //Console.WriteLine(JsonConvert.SerializeObject(robot).ToString());

            //Robot robot2 = new Robot();
            //robot2.JsonConvert.SerializeObject(@"C:\Users\linas.k\OneDrive - Baltijos Brasta\Desktop\New folder\Skaidrės\Databases\Robot.json"); 
            //------------------------------------------------------------------------------------------------------------------------------------

            var robots = new List<Robot>();

            robots.Add(robot);
            robots.Add(robot2);
            robots.Add(robot3);

            //SaveRobotIntoDb(robot);
            //SaveRobotIntoDb(robots);
            //SelectRobotById("62b0a909606d3a42aeb765de");
            //SelectRobotByHeadform(1);
            //DeleteRobotById("62b0a909606d3a42aeb765de");
            UpdateRobotHead("62b0a78320207de306a79bdc", 1);
        }
        public static void SaveRobotIntoDb(Robot robot)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

            robotCollection.InsertOne(robot);
        }
        public static void SaveRobotIntoDb(List<Robot> robots)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

            robotCollection.InsertMany(robots);
        }
        public static void SelectRobotById(string id)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

            var searchFilter = Builders<Robot>.Filter.Eq("_id", new ObjectId(id));
            var results = robotCollection.Find(searchFilter).ToList();

            Console.WriteLine(results.Count);
        }
        public static void SelectRobotByHeadform(int headform)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

            var searchFilter = Builders<Robot>.Filter.Eq("Head", headform);
            var results = robotCollection.Find(searchFilter).ToList();

            Console.WriteLine(results.Count);
        }
        public static void DeleteRobotById(string id)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

            var deleteFilter = Builders<Robot>.Filter.Eq("_id", new ObjectId(id));
            robotCollection.DeleteOne(deleteFilter);
        }
        public static void UpdateRobotHead(string id, int headform)
        {
            var client = new MongoClient("mongodb+srv://LinKru95:Kompiuteris.1@cluster0.8l9v5zd.mongodb.net/?retryWrites=true&w=majority");
            var robotCollection = client.GetDatabase("Robots").GetCollection<Robot>("Robots");

            var searchFilter = Builders<Robot>.Filter.Eq("_id", new ObjectId(id));
            var results = robotCollection.Find(searchFilter).ToList();

            foreach (var item in results)
            {
                item.Head = (Head)headform;
            }

            var update = Builders<Robot>.Update.Set("Head", headform);
        }
    }
}
