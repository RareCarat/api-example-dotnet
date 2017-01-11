# Rare Carat API Examples - .NET Core

This projects demonstrates a very simple example on how to communicate with the Rare Carat API, using .NET Core.

## What it includes

- Basic functions to list, create, update, and delete resources.
- Connection to a SQL database to fetch the diamonds.

## Using this demo

Simply clone using one of the following methods:

**SSH**

    git clone git@github.com:rarecarat/api-example-dotnet.git YourProjectName
    
**HTTPS**

    git clone https://github.com/rarecarat/api-example-dotnet.git YourProjectName
    
Then edit the appsettings.json file to set your connection string and API key.

## Notes

- You need to adjust the model Diamond to reflect your own database. After that, you will need to change the method MapValues() in the file \Web\Services\APIService.cs to map your values to the ones expected by Rare Carat API.
- You need to change how the diamonds are loaded from the database in the method GetAll() located in the file \Web\Services\DiamonService.cs.