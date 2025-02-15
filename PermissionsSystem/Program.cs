using System;
using System.IO;
using Plugify;
using SDK;

namespace PermissionsSystem
{
	public unsafe class PermissionsSystem : Plugin
	{
		public Hooks SDK = new();

		void OnPluginStart()
		{
			SDK.Hook();
			Console.Write($"{Name}: OnStart\n");
		}

		void OnPluginUpdate()
		{
			OnPluginStart();
		}

		void OnPluginEnd()
		{
			Console.Write($"{Name}: OnEnd\n");
		}
	}
}
