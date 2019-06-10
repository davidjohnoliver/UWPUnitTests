using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.MSTestAdapter.PlatformServices;
using Microsoft.VisualStudio.TestPlatform.MSTestAdapter;
using Microsoft.VisualStudio.TestPlatform;
using System.Reflection;

namespace UWPUnitTests2
{
	public class TestRunner
	{
		public static void Run()
		{
			var emptyParams = new object[0];

			foreach (var testClass in GetAllTestClasses(typeof(TestRunner).GetTypeInfo().Assembly))
			{
				foreach (var test in GetAllTestMethods(testClass))
				{
					var instance = Activator.CreateInstance(testClass.AsType());

					test.Invoke(instance, emptyParams);
				}
			}
		}

		private static IEnumerable<TypeInfo> GetAllTestClasses(Assembly assembly) => assembly.GetTypes()
			.Select(t => t.GetTypeInfo())
			.Where(t => t.GetCustomAttribute(typeof(TestClassAttribute)) != null);

		private static IEnumerable<MethodInfo> GetAllTestMethods(TypeInfo testType) => testType.DeclaredMethods
			.Where(m => m.GetCustomAttribute(typeof(TestMethodAttribute)) != null);
	}
}
