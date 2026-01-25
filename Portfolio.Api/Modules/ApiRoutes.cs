namespace Portfolio.Api.Modules;

public static class ApiRoutes
{
    public const string V1 = "/api/v1";

    public static string V1Path(string path) => $"{V1}/{path.TrimStart('/')}";
}
