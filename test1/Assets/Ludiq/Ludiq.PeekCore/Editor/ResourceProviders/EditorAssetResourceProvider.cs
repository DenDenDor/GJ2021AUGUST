﻿using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Ludiq.PeekCore
{
	public sealed class EditorAssetResourceProvider : IResourceProvider
	{
		public string root { get; }

		public EditorAssetResourceProvider(string root)
		{
			this.root = root;
		}



		#region Filesystem

		public IEnumerable<string> GetAllFiles()
		{
			return Directory.GetFiles(root, "*.*", SearchOption.AllDirectories);
		}

		public IEnumerable<string> GetFiles(string path)
		{
			Ensure.That(nameof(path)).IsNotNull(path);

			path = NormalizePath(path);

			return Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
		}

		public IEnumerable<string> GetDirectories(string path)
		{
			Ensure.That(nameof(path)).IsNotNull(path);

			path = NormalizePath(path);

			return Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
		}

		public bool FileExists(string path)
		{
			Ensure.That(nameof(path)).IsNotNull(path);

			path = NormalizePath(path);

			return File.Exists(path);
		}

		public bool DirectoryExists(string path)
		{
			Ensure.That(nameof(path)).IsNotNull(path);

			path = NormalizePath(path);

			return Directory.Exists(path);
		}

		public string NormalizePath(string path)
		{
			Ensure.That(nameof(path)).IsNotNull(path);

			return Path.Combine(root, path);
		}

		public string DebugPath(string path)
		{
			Ensure.That(nameof(path)).IsNotNull(path);

			return NormalizePath(path);
		}

		#endregion



		#region Loading

		public T LoadAsset<T>(string path) where T : UnityObject
		{
			Ensure.That(nameof(path)).IsNotNull(path);

			path = PathUtility.FromProject(NormalizePath(path));
			
			return (T)AssetDatabase.LoadAssetAtPath<T>(path);
		}

		public Texture2D LoadTexture(string path, CreateTextureOptions options)
		{
			return LoadAsset<Texture2D>(path);
		}

		#endregion
	}
}
