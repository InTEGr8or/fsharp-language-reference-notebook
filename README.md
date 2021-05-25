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

Once I figure out how to scrape the site with FSharp I will add that code in here, but for now, I have included the JS snippet code that you can past into a DevTools snippet and `alt+enter`.

Now, I've implemented the scraper in F#, but I'm an F# N00b so my code is probably hideous and anti-patternal.

I am still using HTML web-scraping for the index of topics but pulling the text of the file from the https://raw.githubusercontent.com/dotnet/docs/tree/main/docs/fsharp/language-reference/ raw markdown, which is simpler to convert.

I considered (and am still considering) just using the Language Reference repo directly, by cloning or degiting it locally, but I'm also thinking about scraping other sites that are published for education. Using the GitHub repo would be very efficient, but would only work with sites or content published that way.

I added links back to the original content, which helped me verify the product and might come in handy for users.

For now I have placed all content into the root dir, but if I add other Notebooks with other content (likely) I will place the Language Reference into it's own folder.

My F# non-skills prevented clean code, but I at least got it functioning, and in fewer lines than the JS!