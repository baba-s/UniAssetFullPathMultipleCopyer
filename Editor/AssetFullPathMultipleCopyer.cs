using System;
using System.IO;
using System.Linq;
using UnityEditor;

namespace Kogane.Internal
{
	internal static class AssetFullPathMultipleCopyer
	{
		private const string ITEM_NAME = @"Assets/Copy Full Path (Multiple)";

		[MenuItem( ITEM_NAME )]
		private static void FromAssets()
		{
			var paths = Selection.objects
					.Select( x => AssetDatabase.GetAssetPath( x ) )
					.Select( x => Path.GetFullPath( x ) )
					.OrderBy( x => x )
				;

			var text = string.Join( Environment.NewLine, paths );

			EditorGUIUtility.systemCopyBuffer = text;
		}

		[MenuItem( ITEM_NAME, true )]
		private static bool Validate()
		{
			var objects = Selection.objects;
			return objects != null && 0 < objects.Length;
		}
	}
}