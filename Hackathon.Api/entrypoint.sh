#!/bin/sh

echo "Applying migrations..."
dotnet ef migrations add InitialCreate
dotnet ef database update

echo "Starting application..."
exec dotnet Hackathon.Api.dll
