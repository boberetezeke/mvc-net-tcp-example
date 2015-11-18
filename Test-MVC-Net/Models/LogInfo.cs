using System;
using System.Collections.Generic;

namespace TestMVCNet
{
	public class LogInfo
	{
		public List<string> logLines {
			get;
		}
		public string testString { get; }
	
		public LogInfo ()
		{
			logLines = new List<string>();
			logLines.Add ("--- Start of Log -----");

			testString = "The first attempt at logging";
		}

		public void appendLogEntry(string logEntry)
		{
			logLines.Add(logEntry);
		}
	}
}

