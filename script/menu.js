function Search(info, tab)
{   
    var key = info.selectionText;
    chrome.extension.sendRequest({ "key": "\""+key+"\""}, function(response) {
        console.log(response.farewell);
    });
}

var selection = chrome.contextMenus.create({"title": "文件快搜","contexts":["selection"],"onclick":Search}); 