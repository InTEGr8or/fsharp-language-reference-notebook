var toc = [];
Array.from(document.querySelectorAll("#title-7-1 > ul li")).forEach((item, index)=>{
    if(item.classList.contains("tree-item")){
        setTimeout(()=>{
            item.click();
        }, 300);
    }
    toc.push(item);
});
// console.dir(toc);
var markdown = "#!markdown\n\n"
var fsharp = "#!fsharp\n\n"

var result = markdown;
var mainItems = document.getElementsByTagName("main")[0].children;
var priorTag = "H1";
Array.from(mainItems).forEach((item, index)=>{
        switch(item.tagName){
            case "H1":
                if(priorTag == "PRE") result += markdown;
                result += `# ${item.innerText}\n\n`;
                break;
            case "H2":
                if(priorTag == "PRE") result += markdown;
                result += `## ${item.innerText}\n\n`;
                break;
            case "DIV":
                
                if(item.classList.contains("codeHeader")) break;
                if(priorTag == "PRE") result += markdown;
                if(item.classList.contains("alert")){
                    result += `> ${item.innerHTML
                        .substring(1)
                        .replaceAll("<code>", "`")
                        .replaceAll("</code>", "`")
                        .replaceAll(/<p.*?>/g, "")
                        .replaceAll("</p>", "")
                        }\n\n`;
                }
                if(item.classList.contains("table-scroll-wrapper")){
                    result += `${item.innerHTML.replaceAll("<code>", "`").replaceAll("</code>", "`")}\n\n`;
                }
                break;
            case "P":
                if(priorTag == "PRE") result += markdown;
                result += `${item.innerHTML.replaceAll("<code>", "`").replaceAll("</code>", "`")}\n\n`;
                break;
            case "PRE":
                result += fsharp;
                result += `${item.innerText}\n\n`;
                break;
            default:
                
                break;
        }
        priorTag = item.tagName;
})
let dataUri = 'data:application/json;charset=utf-8,'+ encodeURIComponent(result);
let topicName = window.location.href.substring(66).replaceAll("/",".");
let exportFileDefaultName = `${topicName}.dib`;

let linkElement = document.createElement('a');
linkElement.setAttribute('href', dataUri);
linkElement.setAttribute('download', exportFileDefaultName);
linkElement.click();

console.log(result);
console.log(result.length);
