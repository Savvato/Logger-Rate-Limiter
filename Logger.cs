using System.Collections.Concurrent;
using System.Collections.Generic;
namespace LoggerRateLimiter
{
    public class Logger
    {
        private ConcurrentDictionary<string, int> messages;

        public Logger()
        {
            this.messages = new ConcurrentDictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            bool isAdded = false;
            int storedTimestamp = this.messages.GetOrAdd(
                key: message,
                valueFactory: message =>
                {
                    isAdded = true;
                    return timestamp;
                }
            );
            
            if (isAdded) return true;

            if ((timestamp - storedTimestamp) >= 10)
            {
                this.messages[message] = timestamp;
                return true;
            }
            return false;
        }
    }
}