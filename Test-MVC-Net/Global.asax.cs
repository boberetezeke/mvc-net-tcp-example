
﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestMVCNet
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public LogInfo logInfo;
		public Thread listenerThread;
		public AsynchronousSocketListener socketListener;

		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");

			routes.MapRoute (
				"Default",
				"{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", id = "" }
			);

		}

		public static void RegisterGlobalFilters (GlobalFilterCollection filters)
		{
			filters.Add (new HandleErrorAttribute ());
		}

		protected void Application_Start ()
		{
			AreaRegistration.RegisterAllAreas ();
			RegisterGlobalFilters (GlobalFilters.Filters);
			RegisterRoutes (RouteTable.Routes);

			logInfo = new LogInfo ();
			Application ["logInfo"] = logInfo;
			socketListener = new AsynchronousSocketListener (logInfo);
			listenerThread = new Thread (new ThreadStart (socketListener.StartListening));

			listenerThread.Start ();
		}
	}
}
