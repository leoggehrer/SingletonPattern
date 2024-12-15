namespace SingletonPattern.ConApp
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method that runs the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Demo Singleton-Pattern!");

            RunWithEagerSingleton();
            RunWithLazySingleton();
            RunWithLockSingleton();
            RunWithStaticSingleton();
        }

        /// <summary>
        /// Demonstrates the use of the eager singleton pattern.
        /// </summary>
        static void RunWithEagerSingleton()
        {
            var singleton1 = Logic.WithEager.Singleton.Instance;
            var singleton2 = Logic.WithEager.Singleton.Instance;

            singleton1.DoSomething();
            Console.WriteLine($"Instances are equals: {singleton1 == singleton2}");
        }

        /// <summary>
        /// Demonstrates the use of the lazy singleton pattern.
        /// </summary>
        static void RunWithLazySingleton()
        {
            var singleton1 = Logic.WithLazy.Singleton.Instance;
            var singleton2 = Logic.WithLazy.Singleton.Instance;

            singleton1.DoSomething();
            Console.WriteLine($"Instances are equals: {singleton1 == singleton2}");
        }

        /// <summary>
        /// Demonstrates the use of the singleton pattern with locking.
        /// </summary>
        static void RunWithLockSingleton()
        {
            var singleton1 = Logic.WithLock.Singleton.Instance;
            var singleton2 = Logic.WithLock.Singleton.Instance;

            singleton1.DoSomething();
            Console.WriteLine($"Instances are equals: {singleton1 == singleton2}");
        }

        /// <summary>
        /// Demonstrates the use of the static singleton pattern.
        /// </summary>
        static void RunWithStaticSingleton()
        {
            Logic.WithStatic.Singleton.DoSomething();
        }
    }
}