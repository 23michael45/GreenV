﻿var selectedId = "00000000-0000-0000-0000-000000000000";
$(function () {
	$("#btnQuery").click(function () { query(); });
    initTree();
});
//加载组织机构树
function initTree() {
    $.jstree.destroy();
    $.ajax({
        type: "Get",
        url: "/Department/GetTreeData?_t=" + new Date().getTime(),    //获取数据的ajax请求地址
		success: function (data) {


			$.each(data, function (index, item) {
				selectedId = item.id;

			});

			//loadTables(1, 10);

			/*
            $('#treeDiv').jstree({       //创建JsTtree
                'core': {
                    'data': data,        //绑定JsTree数据
                    "multiple": false    //是否多选
                },
                "plugins": ["state", "types", "wholerow"]  //配置信息
            })
            $("#treeDiv").on("ready.jstree", function (e, data) {   //树创建完成事件
                data.instance.open_all();    //展开所有节点
            });
            $("#treeDiv").on('changed.jstree', function (e, data) {   //选中节点改变事件
                var node = data.instance.get_node(data.selected[0]);  //获取选中的节点
                if (node) {
                    selectedId = node.id;
                    loadTables(1, 10);
                };
            });
			*/
        }
    });

}


function query() {
	var startPage = 1;
	var pageSize = 10;
	var dt = $('#reservationtime').val(); 
	var ip = $('#inputip').val();
	alert(ip);
	$.ajax({
		type: "GET",
		url: "/App_SensorData/Query?startPage=" + startPage + "&pageSize=" + pageSize + "&dt=" + dt + "&ip=" + ip,
		//url: "/App_SensorData/Query?startPage=" + startPage + "&pageSize=" + pageSize + "&dt=" + "1" + "&ip=" + "192.168.1.1",
		success: function (data) {
			
		}
	})
}

//加载用户列表数据
function loadTables(startPage, pageSize) {
    $("#tableBody").html("");
    $.ajax({
        type: "GET",
        url: "/App_SensorData/GetDataByDepartment?startPage=" + startPage + "&pageSize=" + pageSize + "&departmentId=" + selectedId + "&_t=" + new Date().getTime(),
        success: function (data) {
            $.each(data.rows, function (i, item) {
                var tr = "<tr>";
                tr += "<td>" + item.userName + "</td>";
                tr += "<td>" + (item.name == null ? "" : item.name) + "</td>";
                tr += "<td>" + (item.email == null ? "" : item.email) + "</td>";
                tr += "<td>" + (item.mobileNumber == null ? "" : item.mobileNumber) + "</td>";
                tr += "<td>" + (item.remarks == null ? "" : item.remarks) + "</td>";
                tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> 编辑 </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> 删除 </button> </td>"
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
                        loadTables(newPage, pageSize);
                    }
                }
                elment.bootstrapPaginator(options); //分页插件初始化
            }
        }
    })
};


