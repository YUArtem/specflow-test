dotnet test
cd "bin\Debug\net5.0"
livingdoc test-assembly SpecFlowProject.dll -t TestExecution.json --output-type JSON
LivingDoc.html
curl -X POST https://studio.cucumber.io/cucumber_project/results -F messages=@"C:/Projects/SpecFlowProject/bin/Debug/net5.0/FeatureData.json" -H "project-access-token: 274261537559446913826084341512826921691327000556075304236" -H "provider: github" -H "repo: YUArtem/specflow-test" -H "branch: main" -H "revision: 61c3504" 
cmd.exe