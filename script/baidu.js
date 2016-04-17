var load = "<sctipt>var index = layer.load(1, {shade: [0.1,'#fff'] });<script>";
$(document).ready(function()
{
	CreateSearchButton();
	$("#ds").ready(function()
	{
		$("#ds").click(function()
		{
			var key = $("input[name=oq]").val();
			layer.open({
  				type: 1,
  				skin: 'layui-layer-rim', //加上边框
  				area: ['800px', '600px'], //宽高
  				content: "",
                title:"文件列表"
			});
		});	
	});
});

function CreateSearchButton() 
{
	var button = '<span style="margin:11px 0 0 10px" class="btn_wr s_btn_wr bg" id="s_btn_ds"><input type="button" value="网搜" id="ds" class="btn self-btn bg s_btn"></span>';
	$(".s_form_wrapper").append(button);
}