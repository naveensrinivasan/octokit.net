<Query Kind="Program">
  <Reference Relative="..\..\Octokit\bin\Release\Net45\Octokit.dll">C:\n\Documents\GitHub\octokit.net\Octokit\bin\Release\Net45\Octokit.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <NuGetReference>Octokit</NuGetReference>
  <NuGetReference>Octokit.Reactive</NuGetReference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>Octokit</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main(string[] args)
{
	//This makes discovering code fun!!
	var client = new GitHubClient(new Octokit.ProductHeaderValue("octokit"));
	var gorepos = await client.Search.SearchRepo(new SearchRepositoriesRequest()
		{Language = Language.Go});
		
	gorepos.Items.OrderByDescending (i => i.CreatedAt)
		.OrderByDescending (i => i.StargazersCount)
		.Take(50)
		.Select (i => new {
				Name = i.Name, 
				Description = i.Description ,
				LastUpdated = i.UpdatedAt,
				Url = i.HtmlUrl,
				WatchCount = i.StargazersCount
				})
		.Dump();
}