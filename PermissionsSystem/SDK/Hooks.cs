using s2sdk;
using static s2sdk.s2sdk;
using s2menu;
using static s2menu.s2menu;

namespace SDK
{
	public unsafe class Hooks
	{
		private nint _MenuSystem;

		public void Hook()
		{
			_MenuSystem = GetMenuSystem();

			AddConsoleCommand("print", "print information", 0, CommandCallback);
			AddConsoleCommand("vip", "call menu", ConVarFlag.ClientCanExecute, MenuCallback);
		}

		private ResultType CommandCallback(int caller, int ctx, string[] args)
		{
			PrintToServer("print command executed");
			return ResultType.Continue;
		}

		private ResultType MenuCallback(int caller, int ctx, string[] args)
		{
			Console.WriteLine("Calling Menu...");

			var style = "default";

			if (args.Length > 1)
			{
				style = args[1];
			}

			Console.WriteLine($"Style: {style}");

			var MyProfile = GetMenuProfile(GetMenuSystemProfiles(_MenuSystem), style);

			Console.WriteLine($"MyProfile: {MyProfile}");

			if (MyProfile != IntPtr.Zero)
			{
				IntPtr Menu = CreateMenu(_MenuSystem, MyProfile);

				SetMenuTitle(Menu, "[Permissions] v0.0.1");

				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 1", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 2", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				AddMenuItem(Menu, IMenuItemStyleFlags_t.MENU_ITEM_DEFAULT, "Test 3", CallBackItem, IntPtr.Zero);
				// HookMenuClose(Menu, CallBackItem);

				DisplayMenu(_MenuSystem, Menu, caller, 0, 0);
			}

			return ResultType.Continue;
		}

		private void CallBackItem(IntPtr pMenu, int aSlot, int iItem, int iItemOnPage, IntPtr pData)
		{
			Console.WriteLine("CallBackItem");
		}
	}
}