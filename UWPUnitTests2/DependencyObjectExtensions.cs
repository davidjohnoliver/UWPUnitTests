using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Tests.App.Xaml
{
	public static class DependencyObjectExtensions
	{
		public static T FindFirstParent<T>(this DependencyObject dependencyObject) where T : DependencyObject
		{
			DependencyObject parent = dependencyObject;
			do
			{
				parent = (parent as FrameworkElement)?.Parent ?? VisualTreeHelper.GetParent(parent);
				if (parent is T t)
				{
					return t;
				}
			}
			while (parent != null);

			return null;
		}


		public static T FindFirstChild<T>(this DependencyObject obj) where T : DependencyObject
		{
			return obj.GetDescendants().OfType<T>().FirstOrDefault();
		}

		public static IEnumerable<DependencyObject> GetDescendants(this DependencyObject obj)
		{
			var count = VisualTreeHelper.GetChildrenCount(obj);
			var name = (obj as FrameworkElement)?.Name;

			for (int i = 0; i < count; i++)
			{
				var child = VisualTreeHelper.GetChild(obj, i);
				yield return child;

				foreach (var descendant in child.GetDescendants())
				{
					yield return descendant;
				}
			}
		}
	}
}
