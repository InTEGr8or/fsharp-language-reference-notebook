---
title: FSharp Language Reference Notebook
date: 2021-05-22
author: Mark Stouffer
---

# FSharp Language Reference Notebook

An executable REPL of the [F# Language Reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference)

As I taught myself FSharp yesterday, I studied the Microsoft Docs F# Language Reference, copying the code snippets into my `dotnet fsi` REPL, which was very helpful for understanding.

Then I realized I could collect the code snippets in a `.fsx` file and run it right there for future reference as I stumble through a code project.

Then I remembered Notebooks! I modified my rudimentary code-harvesting semimanual procedure to parse the HTML into Markdown/FSharp text in Notebooks `.dib` modified and improved `.ipynb` notebook format and made a JS snippet that auto-downloads the `.dib` file to my Downloads/ when I run it in DevTools. It can also be implemented in TamperMonkey or other script automater to auto-download as you browse the site.

I tried using FSharp scraping tools like FSharp.Data and Canopy but I am an FSharp nooby so I had trouble with the AJAX navigation on the MS Docs site and decided to harvest the reference material with JS to incrementally edge closer to learn how to do it with FSharp.

Once I figure out how to scrape the site with FSharp I will add that code in here, but for now I have included the JS snippet code that you can past into a DevTools snippet and `alt+enter`.

