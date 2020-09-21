namespace ContactsLibrary.API.Helpers
{
    public static class SharedRegex
	{
		public const string OpenTextRegex = @"^[\u00C0-\u02AF\w'][^<>&%#""/$]+$";
		public const string Email = @"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$";
	}
}
