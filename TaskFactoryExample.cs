using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactoryExample
{
    class TaskFactoryExample
    {
        static TaskFactory TF = new TaskFactory(TaskScheduler.Default);

        static void Main(string[] args)
        {
            List<Task> tasklist = new List<Task>();

            tasklist.Add(TF.StartNew(() => Worker("Task 1"), CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default));
            tasklist.Add(TF.StartNew(() => Worker("Task 2"), CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default));
            tasklist.Add(TF.StartNew(() => Worker("Task 3"), CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default));
            tasklist.Add(TF.StartNew(() => Worker("Task 4"), CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default));
            tasklist.Add(TF.StartNew(() => Worker("Task 5"), CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default));
            
            //wait for all tasks to complete.
            Task.WaitAll(tasklist.ToArray());

            //Wait for input before ending program.
            Console.WriteLine("All tasks completed. Press any key to exit.");
            Console.ReadKey();
        }

        static void Worker(String taskName)
        {
            Console.WriteLine("This is Task - {0}", taskName);
        }
    }
}
