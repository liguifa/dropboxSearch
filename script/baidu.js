$(document).ready(function()
{
	CreateSearchButton();
	$("#ds").ready(function()
	{
		$("#ds").click(function()
		{
			var key = $("input[name=oq]").val();
			// var url = "https://113.10.139.102/server";
			// $("#container").empty();
			// $.ajax({
			// 	url:url,
			// 	type:"post",
			// 	dataType:'jsonp',
			// 	jsonp: "jsoncallback", 
			// 	data:
			// 	{
			// 		q:key
			// 	},
            //     success:function(data) 
			// 	{  
            //     	  $("#container").append(data);
            //     },  
			// })
			var url = "http://pan.java1234.com/result.php?wp=0&op=0&ty=gn&q="+key;
			window.location.href=url;
		});	
	});
});

function CreateSearchButton() 
{
	var button = '<span style="margin:11px 0 0 10px" class="btn_wr s_btn_wr bg" id="s_btn_ds"><input type="button" value="网搜" id="ds" class="btn self-btn bg s_btn"></span>';
	$(".s_form_wrapper").append(button);
}