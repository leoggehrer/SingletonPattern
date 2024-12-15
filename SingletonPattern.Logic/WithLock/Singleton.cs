using System;

namespace SingletonPattern.Logic.WithLock
{
    /// <summary>
    /// Represents a thread-safe singleton class with lazy initialization and double-check locking.
    /// </summary>
    public sealed class Singleton
    {
        /// <summary>
        /// The static variable that holds the singleton instance.
        /// </summary>
        private static Singleton? _instance;

        /// <summary>
        /// The lock object for thread safety.
        /// </summary>
        private static readonly object _lock = new object();

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
                // First check (without lock) to improve performance.
                if (_instance == null)
                {
                    // Lock to ensure only one thread creates the instance.
                    lock (_lock)
                    {
                        // Second check to prevent another thread from creating the instance
                        // while the first thread was waiting.
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Example method of the singleton class.
        /// </summary>
        public void DoSomething()
        {
            Console.WriteLine("Singleton instance with lock is working!");
        }
    }
}