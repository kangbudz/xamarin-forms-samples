﻿using NUnit.Framework;
using System;
using Xamarin.UITest.Queries;
using System.Reflection;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using System.Linq;

namespace Todo.UITests
{
	/// <summary>
	/// iOS bootstrapper for the shared Xamarin.Forms tests
	/// </summary>
	[TestFixture ()]
	public class iOSTest : CrossPlatformTests
	{
		public string PathToIPA { get; set; }

		[TestFixtureSetUp]
		public void TestFixtureSetup()
		{
			string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
			FileInfo fi = new FileInfo(currentFile);
			string dir = fi.Directory.Parent.Parent.Parent.FullName;
			PathToIPA = Path.Combine(dir, "Todo.iOS", "bin", "iPhoneSimulator", "Debug", "TodoiOS.app");
		}

		[SetUp]
		public override void SetUp()
		{
			// an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
			// this works fine for local simulator testing though
			_app = ConfigureApp.iOS.AppBundle(PathToIPA).ApiKey("YOUR_API_KEY_HERE").StartApp();
		}
	}
}
