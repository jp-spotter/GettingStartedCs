# GetAccessToken Sample Project

This project is a .NET 8 console application that demonstrates how to get an access token from the ThoughtSpot REST API.

## High-Level Overview

The application reads configuration settings from the `GetAccessToken/appSettings.json` file, including the ThoughtSpot cluster URL, username, and secret key. It then constructs an HTTP POST request to the ThoughtSpot authentication endpoint to retrieve an access token. The JSON response containing the access token is then printed to the console.

This project is self-contained. While it uses NuGet packages for configuration (`Microsoft.Extensions.Configuration.Json` and `Microsoft.Extensions.Configuration.Binder`), these are standard Microsoft libraries and no other third-party libraries are required.

## How to Run the Project

To run this project and see it in action, follow these steps:

1.  **Prerequisites:** Ensure you have the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.

2.  **Configure the application:**
    - Open the `GetAccessToken/appSettings.json` file.
    - Modify the values for `TsClusterBaseUrl`, `Username`, and `Secret` to match your ThoughtSpot environment and credentials.
    - The `TsUserAgent` can be any string and is required by the API.
    - The `ValidityTimeInSec` determines how long the retrieved access token will be valid (in seconds).

3.  **Run from the command line:**
    - Open a terminal or command prompt.
    - Navigate to the `GetAccessToken` directory.
    - Run the following command:
      ```
      dotnet run
      ```

After running the command, the application will make a request to the ThoughtSpot API. If successful, you will see the JSON response printed in the console, which includes the access token. If there is an error (e.g., incorrect credentials), an exception message will be displayed.
