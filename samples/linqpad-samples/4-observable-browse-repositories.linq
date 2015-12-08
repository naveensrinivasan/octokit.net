<Query Kind="Program">
  <Reference Relative="..\..\Octokit\bin\Release\Net45\Octokit.dll">C:\n\Documents\GitHub\octokit.net\Octokit\bin\Release\Net45\Octokit.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>Octokit.Reactive</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

void Main(string[] args)
{
	var owner = string.Empty;
	
	owner = "octokit";
	
	var client = new ObservableGitHubClient(new Octokit.ProductHeaderValue("Octokit.samples"));
	client.Repository.GetAllForUser(owner).Select(r => r.Name).Dump();
}