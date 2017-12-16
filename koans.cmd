@echo off
dotnet restore
pushd FSharpKoans
dotnet watch run
popd