## What is AutoPush?
AutoPush is a simple little library built to solve git push problem - getting rid of code that forget to push. AutoPush is simple, configurable and opensource.

### Where can I get it?
First, install NuGet. Then, install AutoPush from the package manager console:

```
PM> Install-Package AutoPush
```

Or from the .NET CLI as:
```
dotnet add package AutoPush 
```
### How do I get started?
First, configure AutoPush in the startup of your application:</br>
<i>set git root directory(```.git``` )</i>
```c#
if (System.Diagnostics.Debugger.IsAttached)
   GitCommand.rootPath = new Uri(Path.Combine(new string[] { System.AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\" })).AbsolutePath;
else
   GitCommand.rootPath = System.AppDomain.CurrentDomain.BaseDirectory;
```
GitCommand.Start() is used to upload local repository content to a remote repository.
```
GitCommand.Start();
```


### Do you have an issue?
First check if it is already fixed by trying the MyGet build.If you're still running into problems, file an issue.

#### For Contributors
If you want to help and provide a patch for a bugfix or new feature, please take a few minutes and e-mail us (rakib424@gmail.com). In particular check out the Coding standards and Commit Message Style Guide.

In general, fork the project, create a branch for a specific change and send a pull request for that branch. Don't mix unrelated changes. You can use the commit message as the description for the pull request.

AutoPush is Copyright © 2022 Md Rakib Hasan and other contributors under the MIT license.
