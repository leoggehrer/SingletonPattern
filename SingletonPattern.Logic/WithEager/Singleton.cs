namespace SingletonPattern.Logic.WithEager
{
    /// <summary>
    /// Represents a thread-safe singleton class with lazy initialization and double-check locking.
    /// </summary>
    public sealed class Singleton
    {
        /// <summary>
        /// The static variable that holds the singleton instance.
        /// </summary>
        private static Singleton _instance = new Singleton();

        /// <summary>
        /// Private constructor prevents instantiation from outside the class.
        /// </summary>
        private Singleton()
        {
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Example method of the singleton class.
        /// </summary>
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance with eager is working!");
        }
    }
}