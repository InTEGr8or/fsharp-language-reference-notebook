#r "nuget: FSharp.Data, 4.0.1"
open FSharp.Data
open System.IO
open System.Text.RegularExpressions

let LanguageRefUrl = "https://github.com/dotnet/docs/tree/main/docs/fsharp/language-reference"
let githubRootUrl = "https://github.com/"
let RawFileRootUrl = "https://raw.githubusercontent.com/"
let listSelector = "div.js-details-container.Details div.py-2 a.Link--primary"
let topics = HtmlDocument.Load(LanguageRefUrl).CssSelect(listSelector)

let links = topics |> List.map(fun a -> (a.AttributeValue("href").[a.AttributeValue("href").LastIndexOf("/") + 1..], a.AttributeValue("href")))

let rec ReadDocs links folder =
    for (name:string, link:string) in links do
        if link.Contains(".md") || link.Contains(".png") then
            let folderString = if String.length folder > 0 then folder + "/" else ""
            let folderPath = __SOURCE_DIRECTORY__ + folderString
            if not (Directory.Exists folderPath) then
                Directory.CreateDirectory folderPath |> ignore
                printfn "CREATING DIR: %O" folderPath
                    
            let document = Http.RequestString(RawFileRootUrl + link.Replace("blob/", ""))
            let titleStart = document.[document.IndexOf("title: ") + 7..100]
            let title = titleStart.[..titleStart.IndexOf("\n")]
            let dibDocument = $"#!markdown\n\n[{title}]({githubRootUrl + link})\n" + document.Replace("```fsharp", "#!fsharp\n").Replace("```","#!markdown\n")
            let outfile = folderPath + name.Replace(".md", ".dib") 
            printfn "Writing file: %s" outfile
            File.WriteAllText(outfile, dibDocument)
                
        else
            let folder = link.[link.LastIndexOf("/")..]
            let folderUrl = "https://github.com" + link
            printfn "Folder: %s " folderUrl
            let topics = HtmlDocument.Load(folderUrl).CssSelect(listSelector)
            let links = topics |> List.map(fun a -> (a.AttributeValue("href").[a.AttributeValue("href").LastIndexOf("/") + 1..], a.AttributeValue("href")))
            ReadDocs links folder
            // printfn "Error fetching: %s" link

ReadDocs links ""