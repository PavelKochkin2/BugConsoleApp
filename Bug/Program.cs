using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var bugs = new List<Bug>();
            var testCases = new List<TestCase>();

            while (true)
            {
                Console.WriteLine("If you want work with bug press B and if you want to work with TestCase press T");

                var actionKey = Console.ReadLine();


                switch (actionKey.ToUpper())
                {
                    case "B":
                        Console.WriteLine("Press G to get bugs or A to add a new one");
                        var actionBagKey = Console.ReadLine();
                        if (actionBagKey.ToUpper() == "G")
                        {
                            bugs.ForEach(Console.WriteLine);
                        }
                        else if (actionBagKey.ToUpper() == "A")
                        {
                            var bug = InitBug();
                            bugs.Add(bug);
                        }
                        else break;

                        break;
                    case "T":
                        Console.WriteLine("Press G to get Test Cases or A to add a new one");
                        var actionTestCasesKey = Console.ReadLine();
                        if (actionTestCasesKey.ToUpper() == "G")
                        {
                            testCases.ForEach(Console.WriteLine);
                        }
                        else if (actionTestCasesKey.ToUpper() == "A")
                        {
                            var testCase = InitTestCase();
                            testCases.Add(testCase);
                        }
                        else break;

                        break;
                    default:
                        Console.WriteLine("Incorrect input. Please follow the instructions above");
                        break;
                }

            }
        }

        private static Bug InitBug()
        {
            //priority for bug

            Priority priority;
            while (true)
            {
                Console.WriteLine("Enter bug priority: l for low, m for medium, h for high");
                string priorityStr = Console.ReadLine().ToUpper();
                if (priorityStr == "M" || priorityStr == "L" || priorityStr == "H")
                {
                    priority = ProcessPriority(priorityStr);
                    break;
                }
                else
                {
                    Console.WriteLine("Uncorrect data, try on");
                    continue;
                }
            }

            //summary for Bug

            string summary = string.Empty;
            bool validInputRecievedSummary = true;
            do
            {
                Console.WriteLine($"Enter {nameof(Bug.Summary)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                summary = input;
                validInputRecievedSummary = false;

            } while (validInputRecievedSummary);

            //precondition for Bug

            string precondition = string.Empty;
            bool validInputRecievedPrecondition = true;
            do
            {
                Console.WriteLine($"Enter {nameof(Bug.Precondition)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                precondition = input;
                validInputRecievedPrecondition = false;

            } while (validInputRecievedPrecondition);

            //testCaseId for Bug

            string testCaseIdStr = string.Empty;
            int testCaseId = 0;
            do
            {
                Console.WriteLine($"Enter {nameof(Bug.TestCaseId)}");
                testCaseIdStr = Console.ReadLine();
            } while (!(int.TryParse(testCaseIdStr, out testCaseId)));

            //stepNumber for Bug

            string stepNumberStr = string.Empty;
            int stepNumber = 0;
            do
            {
                Console.WriteLine($"Enter {nameof(Bug.StepNumber)}");
                stepNumberStr = Console.ReadLine();
            } while (!(int.TryParse(stepNumberStr, out stepNumber)));

            //actualResult for Bug

            string actualResult = string.Empty;
            bool validInputRecievedActualResult = true;
            do
            {
                Console.WriteLine($"Enter {nameof(Bug.ActualResult)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                actualResult = input;
                validInputRecievedActualResult = false;

            } while (validInputRecievedActualResult);

            //expectedResult for Bug

            string expectedResult = string.Empty;
            bool validInputRecievedExpectedResult = true;
            do
            {
                Console.WriteLine($"Enter {nameof(Bug.ExpectedResult)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                expectedResult = input;
                validInputRecievedExpectedResult = false;

            } while (validInputRecievedExpectedResult);

            var bug = new Bug()
            {
                Priority = priority,
                Summary = summary,
                Precondition = precondition,
                TestCaseId = testCaseId,
                StepNumber = stepNumber,
                ActualResult = actualResult,
                ExpectedResult = expectedResult
            };

            return bug;
        }

        private static TestCase InitTestCase()
        {
            Priority priority;
            while (true)
            {
                Console.WriteLine("Enter Test Case priority: l for low, m for medium, h for high");
                string priorityStr = Console.ReadLine().ToUpper();
                if (priorityStr == "M" || priorityStr == "L" || priorityStr == "H")
                {
                    priority = ProcessPriority(priorityStr);
                    break;
                }
                else
                {
                    Console.WriteLine("Uncorrect data, try on");
                    continue;
                }
            }

            //summary for TestCase

            string summary = string.Empty;
            bool validInputRecievedSummary = true;
            do
            {
                Console.WriteLine($"Enter {nameof(TestCase.Summary)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                summary = input;
                validInputRecievedSummary = false;

            } while (validInputRecievedSummary);



            //precondition for TestCase

            string precondition = string.Empty;
            bool validInputRecievedPrecondition = true;
            do
            {
                Console.WriteLine($"Enter {nameof(TestCase.Precondition)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                precondition = input;
                validInputRecievedPrecondition = false;

            } while (validInputRecievedPrecondition);


            var steps = new List<Step>();
            var step = InitStep();
            steps.Add(step);

            var testCase = new TestCase()
            {
                Priority = priority,
                Summary = summary,
                Precondition = precondition,
                Steps = steps,

            };

            return testCase;
        }

        private static Step InitStep()
        {
            //action for Step

            string action = string.Empty;
            bool validInputRecievedAction = true;
            do
            {
                Console.WriteLine($"Enter {nameof(Step.Action)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                action = input;
                validInputRecievedAction = false;

            } while (validInputRecievedAction);

            //result for Step

            string result = string.Empty;
            bool validInputRecievedResult = true;
            do
            {
                Console.WriteLine($"Enter {nameof(Step.Result)}");
                var input = Console.ReadLine();
                var isInputValid = !(string.IsNullOrEmpty(input));
                if (!isInputValid) continue;
                result = input;
                validInputRecievedResult = false;

            } while (validInputRecievedResult);


            var step = new Step()
            {
                Action = action,
                Result = result,
            };

            return step;

        }

        private static Priority ProcessPriority(string priority)
        {
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
        public Guid Id { get; set; }
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
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Status = Status.New;
        }

        public override string ToString()
        {
            return $"Id = {Id}, \n CreationDate = {CreationDate}, \n" +
                   $"Priority = {Priority}, \n" +
                   $"Summary = {Summary}, \n" +
                   $"Precondition = {Precondition}, \n" +
                   $"Status = {Status}, \n" +
                   $"TestCaseId = {TestCaseId}, \n" +
                   $"StepNumber = {StepNumber}, \n" +
                   $"ActualResult = {ActualResult}, \n" +
                   $"ExpectedResult = {ExpectedResult}";
        }
    }

    public class Step
    {
        public Guid Number { get; set; }
        public string Action { get; set; }
        public string Result { get; set; }

        public Step()
        {
            Number = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Step Number = {Number}, \n " +
                   $"Step Action = {Action}, \n " +
                   $"Step Result = {Result}. \n";
        }
    }

    public class TestCase
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Priority Priority { get; set; }
        public string Summary { get; set; }
        public string Precondition { get; set; }
        public Status Status { get; set; }
        public List<Step> Steps { get; set; }

        public TestCase()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Status = Status.New;
        }

        public override string ToString()
        {
            string stepsStr = string.Empty;

            foreach (var step in Steps)
            {
                stepsStr = stepsStr + step.ToString() + " ";
            }

            return $"Id = {Id}, \n CreationDate = {CreationDate}, \n" +
                   $"Priority = {Priority}, \n" +
                   $"Summary = {Summary}, \n" +
                   $"Precondition = {Precondition}, \n" +
                   $"Status = {Status}, \n" +
                   $"Step = {Steps.ForEach(x => x.ToString())}";
        }
    }
}