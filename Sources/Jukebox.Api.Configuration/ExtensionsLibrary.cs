
namespace Jukebox.Api.Configuration {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;

	/// <summary>Extensions library.</summary>
	public class ExtensionsLibrary {
		/// <summary>Loads the extensions from specified config.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="config">The config.</param>
		public void LoadExtensions(IJukebox jukebox, Config config) {
			foreach (var group in config.ExtensionGroups) {
				var loadGroup = ProcessRequire(group.Require, config);

				if (loadGroup) {
					LoadExtensionGroup(jukebox, @group, config);
				} else {
					_log.WriteFormat("Skiping extensions group '{0}'", group.Name);
				}
			}
		}

		/// <summary>Loads the group of extensions.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="group">The group.</param>
		/// <param name="config">The config.</param>
		public void LoadExtensionGroup(IJukebox jukebox, ExtensionGroupConfig group, Config config) {
			_log.WriteFormat("Loading extensions group '{0}'", group.Name);
			
			foreach (var extension in group.Extensions) {
				var loadExtension = 
					!_loadedExtensions.ContainsKey(extension.Name) &&
					ProcessRequire(extension.Require, config);

				if (loadExtension) {
					LoadExtension(jukebox, extension);
				}
			}
		}

		/// <summary>Loads and initializes the extension.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="extensionConfig">The extension config.</param>
		private void LoadExtension(IJukebox jukebox, ExtensionConfig extensionConfig) {
			var extension = Load(extensionConfig);
			var variables = extensionConfig.Vars.ToDictionary(cd => cd.Name, cd => cd.Value);
			extension.OnInitialize(jukebox, variables);
			jukebox.Extensions.Add(extension);
			foreach (var x in jukebox.Extensions) {
				x.OnExtensionLoaded(extension);
			}
			_loadedExtensions[extensionConfig.Name] = extension;
		}

		/// <summary>Loads extension using specified config.</summary>
		/// <param name="config">Config.</param>
		/// <returns>Extension instance.</returns>
		private IExtension Load(ExtensionConfig config) {
			_log.WriteFormat("Loading extension '{0}' from '{1}'", config.Name, config.AssemblyPath);

			var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (appPath == null) throw new InvalidOperationException("Can not determine the application execution path");
			
			var assemblyPath = Path.Combine(appPath, config.AssemblyPath);
			var assembly = Assembly.LoadFile(assemblyPath);
			
			var type = assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Any(i => i.Name == "IExtension"));
			if (type == null) throw new InvalidOperationException("There is no type implementing IExtension interface");

			var iface = (IExtension)Activator.CreateInstance(type);
			if (iface == null) throw new InvalidOperationException("Can not create instance");

			return iface;
		}

		/// <summary>Processes the require string.</summary>
		/// <param name="require">The require.</param>
		/// <param name="config">The config.</param>
		/// <returns></returns>
		private static bool ProcessRequire(string require, Config config) {
			if (require == null) return true;

			var result = false;
			var dotIdx = require.IndexOf('.');
			var eqlIdx = require.IndexOf('=');
			var extensionName = require.Substring(0, dotIdx);
			var varName = require.Substring(dotIdx + 1, eqlIdx - dotIdx - 1);
			var value = require.Substring(eqlIdx + 1);

			var extension = config.FindExtension(extensionName);
			if (extension != null) {
				var var = extension.Vars.FirstOrDefault(x => x.Name == varName);
				if (var != null) {
					result = (var.Value == value);
				}
			}

			return result;
		}

		/// <summary>The loaded extensions.</summary>
		private readonly Dictionary<string, IExtension> _loadedExtensions = new Dictionary<string, IExtension>();

		/// <summary>The log.</summary>
		private readonly IJukeboxLog _log = new JukeboxLog("core");
	}
}