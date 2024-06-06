using AdventOfCode;
using AdventOfCode._2023;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IHelper, Helper>()
    .BuildServiceProvider();

var _helper = serviceProvider.GetService<IHelper>();

// 2023
var y2023 = new Y202305(_helper);
y2023.Run();
