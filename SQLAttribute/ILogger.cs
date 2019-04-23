using System;

namespace SQLAttribute
{
    public interface ILogger
    {
      
            void Debug(string message);
            void Error(string message, Exception exception = null);
            void Fatal(string message, Exception exception = null);
            void Info(string message);
            void Warn(string message);
            void WriteToCategory(object data, string category);
        
    }
}