﻿var selectedId = "00000000-0000-0000-0000-000000000000";


var editone = $("#editone").text();
var addone = $("#addone").text();
var deleteone = $("#deleteone").text();
var checkeone = $("#checkone").text();
var updateone = $("#updateone").text();
var startone = $("#startone").text();
var stopone = $("#stopone").text();


var deletewaring = $("#deletewaring").text();
var deleteok = $("#deleteok").text();
var deletecancel = $("#deletecancel").text();
var selecttodelete = $("#selecttodelete").text();
var deletefailed = $("#deletefailed").text();


var selectselectonedep = $("#selectonedep").text();
var sureselect = $("#sureselect").text();

var depok = $("#depok").text();
var depcancel = $("#depcancel").text();


var setactive = $("#setactive").text();

var cstartPage = 1;
var cpageSize = 10;
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
    $.jstree.destroy();
    $.ajax({
        type: "Get",
		url: "/Department/GetTreeData?_t=" + new Date().getTime(),    //获取数据的ajax请求地址
		success: function (data) {

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
			});*/
			
			selectedId = $.session.get('select_deparmentid')
			if (selectedId == undefined) {

				selectedId = data[0].id;
			}


			//setCookie('select_deparmentid', selectedId);
			loadrootTables(1, 10);
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
			tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> " + editone + " </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> " + deleteone + " </button> </td>"

		}
		else {
			tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> " + editone + " </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> " + deleteone + " </button><button class='btn btn-info btn-xs' href='javascript:;' onclick='select(\"" + item.id + "\")'><i class='fa fa-edit'></i>  " + setactive + " </button></td>"

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

//加载功能列表数据
function loadTables(startPage, pageSize) {
    $("#tableBody").html("");
    $("#checkAll").prop("checked", false);
	$.ajax({
		type: "GET",
		url: "/Department/GetChildrenByParent?startPage=" + startPage + "&pageSize=" + pageSize + "&parentId=" + selectedId + "&_t=" + new Date().getTime(),
		success: function (data) {
			$.each(data.rows, function (i, item) {
				var tr = "<tr>";
				tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.id + "'/></td>";
				tr += "<td>" + item.name + "</td>";
				tr += "<td>" + (item.code == null ? "" : item.code) + "</td>";
				tr += "<td>" + (item.manager == null ? "" : item.manager) + "</td>";
				tr += "<td>" + (item.contactNumber == null ? "" : item.contactNumber) + "</td>";
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
    });
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
//全选
function checkAll(obj) {
    $(".checkboxs").each(function () {
        if (obj.checked == true) {
            $(this).prop("checked", true)

        }
        if (obj.checked == false) {
            $(this).prop("checked", false)
        }
    });
};
//新增
function add(type) {
    if (type === 1) {
        if (selectedId === "00000000-0000-0000-0000-000000000000") {
			layer.alert(selectselectonedep);
            return;
        }
        $("#ParentId").val(selectedId);
    }
    else {
        $("#ParentId").val("00000000-0000-0000-0000-000000000000");
    }
    $("#Id").val("00000000-0000-0000-0000-000000000000");
    $("#Code").val("");
    $("#Name").val("");
    $("#Manager").val("");
    $("#ContactNumber").val("");
    $("#Remarks").val("");
    $("#Title").text(addone);
    //弹出新增窗体
    $("#addRootModal").modal("show");
};
//编辑
function edit(id) {
    $.ajax({
        type: "Get",
        url: "/Department/Get?id=" + id + "&_t=" + new Date().getTime(),
        success: function (data) {
            $("#Id").val(data.id);
            $("#ParentId").val(data.parentId);
            $("#Name").val(data.name);
            $("#Code").val(data.code);
            $("#Manager").val(data.manager);
            $("#ContactNumber").val(data.contactNumber);
            $("#Remarks").val(data.remarks);

            $("#Title").text(editone)
            $("#addRootModal").modal("show");
        }
    })
};
//保存
function save() {
    var postData = { "dto": { "Id": $("#Id").val(), "ParentId": $("#ParentId").val(), "Name": $("#Name").val(), "Code": $("#Code").val(), "Manager": $("#Manager").val(), "ContactNumber": $("#ContactNumber").val(), "Remarks": $("#Remarks").val() } };
    $.ajax({
        type: "Post",
        url: "/Department/Edit",
        data: postData,
        success: function (data) {
            debugger
            if (data.result == "Success") {
                initTree();
                $("#addRootModal").modal("hide");
            } else {
                layer.tips(data.message, "#btnSave");
            };
        }
    });
};
//批量删除
function deleteMulti() {
    var ids = "";
    $(".checkboxs").each(function () {
        if ($(this).prop("checked") == true) {
            ids += $(this).val() + ","
        }
    });
    ids = ids.substring(0, ids.length - 1);
	if (ids.length == 0) {
		layer.alert(selecttodelete);
        return;
    };
	//询问框
	layer.confirm(deletewaring, {
        btn: [deleteok, deletecancel]
    }, function () {
        var sendData = { "ids": ids };
        $.ajax({
            type: "Post",
            url: "/Department/DeleteMuti",
            data: sendData,
            success: function (data) {
                if (data.result == "Success") {
                    initTree();
                    layer.closeAll();
                }
				else {
					layer.alert(deletefailed);
                }
            }
        });
    });
};
//删除单条数据
function deleteSingle(id) {
	layer.confirm(deletewaring, {
		btn: [deleteok, deletecancel],
		title:false
    }, function () {
        $.ajax({
            type: "POST",
            url: "/Department/Delete",
            data: { "id": id },
            success: function (data) {
                if (data.result == "Success") {
                    initTree();
                    layer.closeAll();
                }
                else {
					layer.alert(deletefailed);
                }
            }
        })
    });
};

function select(id) {
	selectedId = id;
	$.session.set('select_deparmentid', selectedId);

	layer.confirm(sureselect, {
		btn: [depok, depcancel],
		title:false
	}, function () {
		$.ajax({
			type: "POST",
			url: "/Department/GetAllRoot?startPage=" + cstartPage + "&pageSize=" + cpageSize + "&_t=" + new Date().getTime(),
			success: function (data) {

				//var x = getCookie('select_deparmentid');
				//alert(x);

				layer.closeAll();
				ajaxresult(data);
			}
		})
	});
}

