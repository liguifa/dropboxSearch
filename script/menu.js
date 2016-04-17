function Search(info, tab)
{
	var url = "http://pan.java1234.com/result.php?wp=0&op=0&ty=gn&q="+info.selectionText;
    window.open(url);
}

var selection = chrome.contextMenus.create({"title": "网盘搜索","contexts":["selection"],"onclick":Search}); 