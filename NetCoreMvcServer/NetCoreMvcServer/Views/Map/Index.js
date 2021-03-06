﻿var selectedId = "00000000-0000-0000-0000-000000000000";
var cstartPage = 1;
var cpageSize = 10;
var dname = "";
var hotspots = [];


var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext("2d");

var cw = canvas.width;
var ch = canvas.height;
var offsetX, offsetY;


$(function () {
	$("#btnAddRoot").click(function () { add(0); });
	$("#btnAdd").click(function () { add(1); });
	$("#btnSave").click(function () { save(); });
	$("#btnDelete").click(function () { deleteMulti(); });
	$("#btnLoadRoot").click(function () {
		selectedId = "00000000-0000-0000-0000-000000000000";
		loadrootTables(1, 10);
	});
	$("#checkAll").click(function () { checkAll(this) });
	initTree();
});
//加载功能树
function initTree() {

	selectedId = $.session.get('select_deparmentid')

	$.jstree.destroy();
	$.ajax({
		type: "Get",
		url: "/Department/GetAllTerminalByDepartment?departmentId=" + selectedId,    //获取数据的ajax请求地址
		success: function (data) {
			
			dname = data.departmentname;
			
			
			reOffset(canvas);
			window.onscroll = function (e) { reOffset(canvas); }
			window.onresize = function (e) { reOffset(canvas); }
			
			hotspots = [];
			$.each(data.rows, function (i, item) {
				hotspots.push({ x: item.positionX, y: item.positionY, radius: 20, tip: item.ip });
			})

			$("#myCanvas").mousemove(function (e) { handleMouseMove(e); });
			
			drawcanvas();

		
		}
	});

}


function ajaxresult(data) {
	$("#tableBody").html("");
	$.each(data.rows, function (i, item) {
		var tr = "<tr>";
		tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.id + "'/></td>";
		tr += "<td>" + item.name + "</td>";
		tr += "<td>" + (item.code == null ? "" : item.code) + "</td>";
		tr += "<td>" + (item.manager == null ? "" : item.manager) + "</td>";
		tr += "<td>" + (item.contactNumber == null ? "" : item.contactNumber) + "</td>";
		tr += "<td>" + (item.remarks == null ? "" : item.remarks) + "</td>";
		if (selectedId == item.id) {
			tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> 编辑 </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> 删除 </button> </td>"

		}
		else {
			tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> 编辑 </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> 删除 </button><button class='btn btn-info btn-xs' href='javascript:;' onclick='select(\"" + item.id + "\")'><i class='fa fa-edit'></i> 设为选中 </button></td>"

		}

		tr += "</tr>";
		$("#tableBody").append(tr);
	})
	var elment = $("#grid_paging_part"); //分页插件的容器id
	if (data.rowCount > 0) {
		var options = { //分页插件配置项
			bootstrapMajorVersion: 3,
			currentPage: startPage, //当前页
			numberOfPages: data.rowsCount, //总数
			totalPages: data.pageCount, //总页数
			onPageChanged: function (event, oldPage, newPage) { //页面切换事件
				loadrootTables(newPage, pageSize);
			}
		}
		elment.bootstrapPaginator(options); //分页插件初始化
	}

}




function loadrootTables(startPage, pageSize) {

	cstartPage = startPage;
	cpageSize = pageSize;
	$("#tableBody").html("");
	$("#checkAll").prop("checked", false);
	$.ajax({
		type: "GET",
		url: "/Department/GetAllRoot?startPage=" + startPage + "&pageSize=" + pageSize + "&_t=" + new Date().getTime(),
		success: ajaxresult
	})
}


function drawcanvas() {
	
	var path = "../wwwroot/" + dname + ".png";


	var GP = new Image();
	GP.src = "../wwwroot/GreenPoint.png";

	preImage(path, function () {
		ctx.drawImage(this, 0, 0);

		for (var i = 0; i < hotspots.length; i++) {

			var h = hotspots[i];
			ctx.beginPath();
			ctx.arc(h.x, h.y, h.radius, 0, Math.PI * 2);
			ctx.closePath();
			ctx.stroke();

			ctx.drawImage(GP, h.x - 16, h.y - 16,32,32);
		}
		
	}); 
	
	//var img = new Image();
	

	//alert(img.src);
	//ctx.drawImage(C321F1, 0, 0);
	//img.onload = function () {
	//	//draw background image
	//	ctx.drawimage(img, 0, 0);
	//	ctx.drawImage(GP, 500, 500, 32, 32);

	//	//ctx.fillStyle = "rgba(200, 0, 0, 0.5)";
	//	//ctx.fillRect(0, 0, 500, 500);

	//};

	//img.src = ;
	//ctx.drawImage(img, 0, 0);
	//ctx.drawImage(GP, 500, 500, 32, 32);
	//ctx.drawImage(GP, 500, 500, 32, 32);
	//ctx.drawImage(GP, 500, 200, 32, 32);
	//ctx.drawImage(GP, 500, 700, 32, 32);



}


function preImage(url, callback) {
	var img = new Image(); //创建一个Image对象，实现图片的预下载  
	img.src = url;

	if (img.complete) { // 如果图片已经存在于浏览器缓存，直接调用回调函数  
		callback.call(img);
		return; // 直接返回，不用再处理onload事件  
	}

	img.onload = function () { //图片下载完毕时异步调用callback函数。  
		callback.call(img);//将回调函数的this替换为Image对象  
	};
}  




function reOffset(canvas) {
	var BB = canvas.getBoundingClientRect();
	
	offsetX = BB.left;
	offsetY = BB.top;
}


function handleMouseMove(e) {
	// tell the browser we're handling this event

	e.preventDefault();
	e.stopPropagation();

	mouseX = parseInt(e.clientX - offsetX);
	mouseY = parseInt(e.clientY - offsetY);


	ctx.clearRect(0, 0, cw, ch);
	drawcanvas();


	for (var i = 0; i < hotspots.length; i++) {
		var h = hotspots[i];
		var dx = mouseX - h.x;
		var dy = mouseY - h.y;
		if (dx * dx + dy * dy < h.radius * h.radius) {
			ctx.fillText(h.tip, h.x, h.y);
		}
	}
}