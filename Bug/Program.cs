using System;
using System.Collections.Generic;

namespace Bug
{
    class Program
    {
        static void Main(string[] args)
        {
            var bugs = new List<Bug>();

            while (true)
            {
                Console.WriteLine("Press G to get bugs or A to add a new one");

                var actionKey = Console.ReadLine();


                switch (actionKey.ToUpper())
                {
                    case "G":
                        bugs.ForEach(Console.WriteLine);
                        break;
                    case "A":
                        var bug = InitBug();
                        bugs.Add(bug);
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Please follow the instructions above");
                        break;
                }
            }
        }

        private static Bug InitBug()
        {
            //priority
            Console.WriteLine("Enter bug priority: l for low, m for medium, h for high");
            string priorityStr = Console.ReadLine();
            Priority priority = ProcessPriority(priorityStr);

            //summary
            Console.WriteLine($"Enter {nameof(Bug.Summary)}");
            string summary = Console.ReadLine();

            //precondition
            Console.WriteLine($"Enter {nameof(Bug.Precondition)}");
            string precondition = Console.ReadLine();

            //testCaseId
            Console.WriteLine($"Enter {nameof(Bug.TestCaseId)}");
            string testCaseIdStr = Console.ReadLine();
            int.TryParse(testCaseIdStr, out int testCaseId);

            var bug = new Bug()
            {
                Priority = priority,
                Summary = summary,
                Precondition = precondition,
                TestCaseId = testCaseId
            };

            return bug;
        }


        private static Priority ProcessPriority(string priority)
        {
            //if (priority != "l"  priority != "m" || priority != "h")
            //    throw new ArgumentException("Invalid priority");

            return priority switch
            {
                "l" => Priority.Low,
                "m" => Priority.Medium,
                "h" => Priority.High,
                _ => Priority.Medium
            };
        }

    }


    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        New,
        InProgress,
        Failed,
        Done
    }

    public class Bug
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public Priority Priority { get; set; }
        public string Summary { get; set; }
        public string Precondition { get; set; }
        public Status Status { get; set; }
        public int TestCaseId { get; set; }

        public int StepNumber { get; set; }

        public string ActualResult { get; set; }

        public string ExpectedResult { get; set; }

        public Bug()
        {
            Id = new Random().Next(1, 100);
            CreationDate = DateTime.UtcNow;
            Status = Status.New;
        }

        public override string ToString()
        {
            return $"Id = {Id} , CreationDate = {CreationDate}";
        }
    }
}
