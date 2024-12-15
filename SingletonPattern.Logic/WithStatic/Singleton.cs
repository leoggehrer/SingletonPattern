namespace SingletonPattern.Logic.WithStatic
{
    /// <summary>
    /// Provides a static singleton class with a method to perform an action.
    /// </summary>
    public static class Singleton
    {
        /// <summary>
        /// Executes an action and writes a message to the console.
        /// </summary>
        public static void DoSomething()
        {
            Console.WriteLine("Static Singleton is working!");
        }
    }
}

