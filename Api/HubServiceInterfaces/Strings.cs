namespace HubServiceApi
{
    public static class Strings
    {
        #region Fields

        public static class Events
        {
            #region Properties

            public static string TimeReceived => nameof(IHubTypeOne.PublishTime);
            public static string ListOfIntReceived => nameof(IHubTypeOne.PublishListOfInt);

            #endregion
        }

        #endregion

        #region Properties

        public static string BaseUrl => "http://localhost:53353";

        public static string TestHubPath => "/hubs/test";

        public static string TestHubUrl => BaseUrl + TestHubPath;

        #endregion
    }
}