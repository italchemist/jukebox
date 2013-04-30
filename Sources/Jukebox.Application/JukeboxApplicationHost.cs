
//using Jukebox.Api;

using Jukebox.Api;
using Jukebox.Application.Configuration;

namespace Jukebox.Application {
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Collections.Generic;

	/// <summary>Jukebox application.</summary>
	class JukeboxApplicationHost {
		/// <summary>Runs application.</summary>
		/// <param name="config">Configuration.</param>
		public void Run(Config config) {
			var jukebox = new Jukebox();

			JukeboxApplication.Configuration.VariableChanged += (sender, e) => {
				var c = config.FindExtension(e.ExtensionName);
				if (c != null) {
					var var = c.Vars.FirstOrDefault(v => v.Name == e.Variable);
					if (var == null) {
						var = new ConfigVariable { Name = e.Variable, Value = e.Value };
						c.Vars.Add(var);
					} else {
						var.Value = e.Value;
					}

					ConfigLoader.Save(config, "config.xml");
				}
			};

			JukeboxApplication.ReloadRequested += (sender, e) => LoadExtensions(jukebox, config);
#if !DEBUG
			try {
#endif
				LoadExtensions(jukebox, config);
#if !DEBUG
			} catch (Exception ex) {
				jukebox.Extensions.ForEach(x => x.OnError(ex));
			}
#endif
		}

		public void LoadExtensions(Jukebox jukebox, Config config) {
			foreach (var group in config.ExtensionGroups) {
				var groupRequire = group.Require;
				var loadGroup = true;

				if (groupRequire != null) {
					loadGroup = ProcessRequire(groupRequire, config);
				}

				if (loadGroup) {
					LoadExtensionGroup(jukebox, group, config);
				}
			}
		}

		public void LoadExtensionGroup(Jukebox jukebox, ExtensionGroupConfig group, Config config) {
			foreach (var extension in group.Extensions) {
				var require = extension.Require;
				var loadExtension = true;

				if (require != null) {
					loadExtension = ProcessRequire(require, config);
				}

				if (loadExtension) {
					loadExtension = !_loadedExtensions.ContainsKey(extension.Name);
				}

				if (loadExtension) {
					LoadExtension(jukebox, extension);
				}
			}
		}

		private void LoadExtension(Jukebox jukebox, ExtensionConfig extensionConfig) {
			var extension = Load(extensionConfig);
			var variables = extensionConfig.Vars.ToDictionary(cd => cd.Name, cd => cd.Value);
			extension.OnInitialize(jukebox, variables);
			jukebox.Extensions.Add(extension);
			jukebox.Extensions.ForEach(x => x.OnExtensionLoaded(extension));

			_loadedExtensions[extensionConfig.Name] = extension;
		}

		private static bool ProcessRequire(string require, Config config) {
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

		/// <summary>Loads extension using specified config.</summary>
		/// <param name="config">Config.</param>
		/// <returns>Extension instance.</returns>
		private static IExtension Load(ExtensionConfig config) {
			var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (dir == null) throw new Exception();

			var assemblyFullPath = Path.Combine(dir, config.AssemblyPath);
			var assembly = Assembly.LoadFile(assemblyFullPath);
			var type = assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Any(i => i.Name == "IExtension"));
			if (type == null) throw new Exception("There is no type implementing IExtension interface");

			var iface = (IExtension)Activator.CreateInstance(type);
			if (iface == null) throw new Exception("Can not create instance");

			return iface;
		}

		private readonly Dictionary<string, IExtension> _loadedExtensions = new Dictionary<string,IExtension>();
	}
}
