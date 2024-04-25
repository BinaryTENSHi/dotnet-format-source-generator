# dotnet format 'Using directive is unnecessary' false positive

This repository contains a minimal reproducible example for a false positive in `dotnet format`

## Description

The `ExampleGenerator` is a Roslyn source generator that generates `GeneratedClass` into the `Example.Generated`
namespace in the `Example` project. This generated class is used in the `SuperClass` and thus imports
the `Example.Generated` namespace with a `using` directive.

Running `dotnet format --verify-no-changes` errors out with:

```shell
$ dotnet format --verify-no-changes
/{path}/Example/Class.cs(1,1): error IDE0005: Using directive is unnecessary. [/{path}/Example/Example.csproj]
```

Running `dotnet format` removes the using which leads to a compilation error afterward:

```shell
$ dotnet format                                                                                                                                                                     main U
$ dotnet build                                                                                                                                                                     main MU
MSBuild version 17.9.8+b34f75857 for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  ExampleGenerator -> /{path}/ExampleGenerator/bin/Debug/netstandard2.0/ExampleGenerator.dll
/{path}/Example/Class.cs(3,25): error CS0246: The type or namespace name 'GeneratedClass' could not be found (are you missing a using directive or an assembly reference?) [/{path}/Example/Example.csproj]

Build FAILED.

/{path}/Example/Class.cs(3,25): error CS0246: The type or namespace name 'GeneratedClass' could not be found (are you missing a using directive or an assembly reference?) [/{path}/Example/Example.csproj]
    0 Warning(s)
    1 Error(s)

Time Elapsed 00:00:00.75
```
