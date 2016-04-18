var load = "<sctipt>var index = layer.load(1, {shade: [0.1,'#fff'] });<script>";
var getResoureInterval;
$(document).ready(function()
{
	CreateSearchButton();
	$("#ds").ready(function()
	{
		$("#ds").click(function()
		{
			var key = $("input[name=oq]").val();
            LoadResoure(key);
        });
    });	
});

function LoadResoure(key)
{
    var url = "https://localhost:8899?key="+key+ "&callback=?";
    var window = layer.open({
  		type: 1,
  		skin: 'layui-layer-rim', //加上边框
  		area: ['800px', '600px'], //宽高
  		content: "",
        title:"文件列表"
	});
    $("body").append("<iframe name='iframe' id='iframe' src='"+url+"' style='display:none'></iframe>");
    getResoureInterval = setInterval("GetResoure()",100);
}

function GetResoure()
{
    var data = $(window.frames["iframe"].document).find("body").text();
    if(data!="")
    {
        clearInterval(getResoureInterval);
        data = eval("("+data+")");
        var html = "";
        html += '<div data-am-widget="list_news" class="am-list-news am-list-news-default" >';
        html += '<div class="am-list-news-bd">';
        html += '<ul class="am-list">';
        for(var i in data.rows)
        {
              html += '<li class="am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-left">';
              html += '<div class="am-u-sm-4 am-list-thumb" style="width:121px;height:121px">';
              html += '<a href="pan.baidu.com" class="">';
              html += '<img src="https://ss0.bdstatic.com/-0U0bnSm1A5BphGlnYG/tam-ogel/12541d052e91cd0e4689dfeb0c32d266_121_121.jpg" style="width:121px;height:121px" alt="百度网盘"/>';
              html += '</a>';
              html += '</div>';
              html += '<div class=" am-u-sm-8 am-list-main" style="width:620px">'
              html += '<h3 class="am-list-item-hd"><a href="'+data.rows[i].Url+'" class="" target="_blank">'+data.rows[i].Title+'</a></h3>';
              html += '<div class="am-list-item-text">'+data.rows[i].Introduction+'</div>';
              html += '</div>';
              html += '</li>';
        }
        html += '</ul>';
        html += '</div></div>'
        $(".layui-layer-content").append(html);
    }
}

function CreateSearchButton() 
{
	var button = '<span style="margin:11px 0 0 10px" class="btn_wr s_btn_wr bg" id="s_btn_ds"><input type="button" value="网搜" id="ds" class="btn self-btn bg s_btn"></span>';
	$(".s_form_wrapper").append(button);
}

// chrome.extension.onRequest.addListener(
//   function(request, sender, sendResponse) {
//      LoadResoure(request.key);
//   });